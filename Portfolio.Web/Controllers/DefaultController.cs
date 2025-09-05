using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class DefaultController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(UserMessage message)
        {
            context.UserMessage.Add(message);
            context.SaveChanges();
            await Task.Delay(2000);
            return RedirectToAction("Index");
        }
    }
}
