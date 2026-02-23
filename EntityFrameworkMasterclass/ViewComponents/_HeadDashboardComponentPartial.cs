using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _HeadDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
