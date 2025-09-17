using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultSkillComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var skill = context.Skills.ToList();
            return View(skill);
        }
    }
}
