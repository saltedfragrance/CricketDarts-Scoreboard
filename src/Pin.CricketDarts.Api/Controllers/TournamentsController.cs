using Microsoft.AspNetCore.Mvc;

namespace Pin.CricketDarts.Api.Controllers
{
    public class TournamentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
