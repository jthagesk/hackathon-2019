using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Controllers.Recommendation
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

        public async Task<IEnumerable<Hotel>> Execute(double longitude, double latitude)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT DISTINCT TOP 10
                                    h.HotelCode,
                                    h.[Name],
                                    h.[City],
                                    (geography::Point(@latitude, @longitude, 4326).STDistance(h.[Position])) as DISTANCE
                                FROM [dbo].[hotels] h
                                order by DISTANCE asc";

                                //latitude: '58.145626'
                                //longitude: '7.996038'
                conn.Open();
                var result = (await conn.QueryAsync<Hotel>(sQuery, new { latitude, longitude })).ToArray();
                return result;
            }
        }
    }
}
