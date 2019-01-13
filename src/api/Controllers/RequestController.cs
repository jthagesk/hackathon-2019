using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return api.Count.getValue().ToString();
        }
    }
}
