using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _ChartDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
