using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _SalesStatusDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _SalesStatusDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Customers.GroupBy(x => x.CustomerCity).Select(g => new CustomerCityChartViewModel
            {
                City = g.Key,
                Count = g.Count()
            }).ToList();
            return View(data);
        }
    }
}
