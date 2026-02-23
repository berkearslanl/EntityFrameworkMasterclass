using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _ActivityDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _ActivityDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Activities.OrderByDescending(x=>x.ActivityTime).Take(5).ToList();
            return View(values);
        }
    }
}
