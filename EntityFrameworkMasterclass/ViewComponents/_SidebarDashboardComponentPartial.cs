using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _SidebarDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
