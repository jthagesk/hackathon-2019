using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers.Recommendation
{
    public class HotelFinder
    {
        
        public async Task<IEnumerable<Hotel>> Execute(double longitude, double latitude)
        {
            return new Hotel[0];
        }
    }
}
