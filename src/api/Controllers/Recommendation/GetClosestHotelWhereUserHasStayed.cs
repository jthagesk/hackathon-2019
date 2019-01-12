using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace api.Controllers.Recommendation
{
    public class GetClosestHotelWhereUserHasStayed
    {
        private string ConnectionString { get; }

        public GetClosestHotelWhereUserHasStayed(string connectionString)
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

        public async Task<Hotel> Execute(string userId, IEnumerable<Hotel> hotels)
        {
            var reservations = await GetReservationsForUser(userId);
            foreach(var h in hotels)
            {
                var r = reservations.FirstOrDefault(res => res.HotelCode == h.HotelCode);
                if (r != null)
                    return h;
            }
            return null;
        }

        private async Task<IEnumerable<Reservation>> GetReservationsForUser(string userId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT TOP 1000 
                            GUEST_NAME_ID AS UserId, 
                            RESORT AS HotelCode, 
                            ROOM_LABEL AS RoomCode
                            FROM reservations
                            WHERE GUEST_NAME_ID = @userId";

                conn.Open();
                var result = (await conn.QueryAsync<Reservation>(sQuery, new { userId })).ToArray();
                return result;
            }
        }
    }
}
