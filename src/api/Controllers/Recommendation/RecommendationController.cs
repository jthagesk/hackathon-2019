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

        public RecommendationController(HotelFinder finder)
        {
            Finder = finder;
        }


        // GET api/values/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<string>> Get(string userId, double longitude, double latitude)
        {
            //find hotels nearby (longitude, latitude)
            var hotels = await Finder.Execute(longitude, latitude);
            return Ok(string.Join(", ", hotels.Select(h => h.Name)));

            //har bruker vært på hotellet
            // nærmeste han har vært på

            //har bruker vært på et hotell og i så fall romtype
            // nærmeste hotell med romtype

            //ikke vært på hotell -> mest populære hotell



            // return Ok("bla");
        }
    }
}
