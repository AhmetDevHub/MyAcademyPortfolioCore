using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.skillAverage = context.Skills.Any() ? context.Skills.Average(x=>x.Percentage).ToString("00.00") :0.0.ToString("00.00");
            ViewBag.unreadMessageCount = context.UserMessage.Count(x => x.IsRead == false);
            ViewBag.lastMessageOwner = context.UserMessage.OrderByDescending(x => x.UserMessageId).Select(x => x.Name).FirstOrDefault();

            var StartYear = context.Experiences.Min(x => x.StartYear);         
            ViewBag.experienceYear = DateTime.Now.Year - StartYear;

            ViewBag.companyCount = context.Experiences.Select(x => x.Company).Distinct().Count();

            ViewBag.reviewAverage = context.Testimonials.Any() ? context.Testimonials.Average
                (x => x.Review).ToString("0.0") : "Değerlendirme Yapılmadı";

            ViewBag.maxRevierOwner = context.Testimonials.OrderByDescending(x => x.Review).Select
                (x => x.Name).FirstOrDefault();
            return View();
        }
    }
}
