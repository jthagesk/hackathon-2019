using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alexa.NET;
using Amazon.Lambda.Core;

namespace Api.Controllers.Alexa
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            return new string[] { "" };
        }
        [HttpGet("{somId}")]
        public async Task<ActionResult> Get(string someId)
        {
            return Ok("");
        }

    }
}