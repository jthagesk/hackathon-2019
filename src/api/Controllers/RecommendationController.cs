using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<string>> Get(string userId)
        {
            return Ok("bla");
        }
    }
}
