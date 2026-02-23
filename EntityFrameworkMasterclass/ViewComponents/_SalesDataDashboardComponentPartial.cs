using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _SalesDataDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _SalesDataDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Orders.Include(x => x.Customer).Include(x => x.Product).OrderByDescending(x => x.OrderId).Take(5).ToList();
            return View(values);
        }
    }
}
