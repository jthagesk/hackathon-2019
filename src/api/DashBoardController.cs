using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api
{
    public class DashBoardController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
