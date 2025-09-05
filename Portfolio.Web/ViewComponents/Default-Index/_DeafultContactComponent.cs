using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DeafultContactComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contacts = context.ContactInfo.ToList();
            return View(contacts);
        }
    }
}
