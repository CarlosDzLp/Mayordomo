using Microsoft.AspNetCore.Mvc;

namespace Mayordomo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
