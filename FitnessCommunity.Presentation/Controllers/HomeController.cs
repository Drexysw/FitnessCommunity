using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCommunity.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            
        }
        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
