using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
