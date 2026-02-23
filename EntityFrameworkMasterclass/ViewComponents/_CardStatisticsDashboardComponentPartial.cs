using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _CardStatisticsDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.customerCount = _context.Customers.Count();
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.productCount = _context.Products.Count();
            ViewBag.avgBalance = _context.Customers.Average(x => x.CustomerBalance);
            ViewBag.orderCount = _context.Orders.Count();
            ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount);
            return View();
        }
    }
}
