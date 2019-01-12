using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Recommendation
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private HotelFinder Finder { get; }
        private GetClosestHotelWhereUserHasStayed ClosestHotelWhereUserHasStayed { get; }

        public RecommendationController(HotelFinder finder,
                GetClosestHotelWhereUserHasStayed closestHotelWhereUserHasStayed)
        {
            Finder = finder;
            ClosestHotelWhereUserHasStayed = closestHotelWhereUserHasStayed;
        }


        // GET api/values/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<Hotel>> Get(string userId, double longitude, double latitude)
        {
            Count.inc();
            //find hotels nearby (longitude, latitude)
            var hotels = await Finder.Execute(longitude, latitude);

            //har bruker vært på hotellet
            // nærmeste han har vært på
            var h = await ClosestHotelWhereUserHasStayed.Execute(userId, hotels);
            if (h != null)
                return Ok(h);

            //har bruker vært på et hotell og i så fall romtype
            // nærmeste hotell med romtype
            // var userRooms = GetHotelsForUser(userId);
            // var h = GetClosestHotelWithRoomTypes(hotels, userRooms);

            //ikke vært på hotell -> mest populære hotell

            return Ok(hotels.FirstOrDefault());
        }
    }
}
