using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Controllers.Beacon
{
    public class HotelFinder
    {
        private string ConnectionString { get; }

        public HotelFinder(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public async Task<Hotel> Execute(string hotelCode)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT TOP 1
                                    h.HotelCode,
                                    h.[Name],
                                    h.[City]
                                FROM [dbo].[hotels] h
                                WHERE h.HotelCode = @hotelCode";

                conn.Open();
                var result = (await conn.QueryAsync<Hotel>(sQuery, new { hotelCode })).ToArray();
                return result.FirstOrDefault();
            }
        }
    }
}
