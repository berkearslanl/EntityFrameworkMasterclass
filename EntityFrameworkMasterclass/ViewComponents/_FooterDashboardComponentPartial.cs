using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _FooterDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
