using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents.DashboardChartsComponents
{
    public class _DashboardOrderDateChartComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _DashboardOrderDateChartComponentPartial(EfContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Orders.GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    RawDate=g.Key,
                    Count=g.Count()
                })
                .OrderBy(o => o.RawDate)
                .ToList()
                .Select(x=>new OrderDateViewModel
                {
                    Date=x.RawDate.ToString("yyyy mm dd"),
                    Count=x.Count
                }).ToList();
            return View(data);
        }
    }
}
