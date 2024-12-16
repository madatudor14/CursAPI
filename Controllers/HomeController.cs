using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
