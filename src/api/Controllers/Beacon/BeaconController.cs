using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Beacon
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeaconController : ControllerBase
    {
        private HotelFinder Finder { get; }
        public BeaconController(HotelFinder finder)
        {
            Finder = finder;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> Get(string id)
        {
            if (id == "B9407F30-F5F8-466E-AFF9-25556B57FE6D")
                return Ok(await Finder.Execute("OSLSTO"));
            return NotFound();
        }
    }
}
