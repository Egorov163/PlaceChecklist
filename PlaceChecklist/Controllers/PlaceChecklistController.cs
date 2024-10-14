using Microsoft.AspNetCore.Mvc;

namespace PlaceChecklist.Controllers
{
    public class PlaceChecklistController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
