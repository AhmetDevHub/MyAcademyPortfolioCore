using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutScriptComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
