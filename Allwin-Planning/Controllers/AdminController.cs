using Microsoft.AspNetCore.Mvc;

namespace Allwin_Planning.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
