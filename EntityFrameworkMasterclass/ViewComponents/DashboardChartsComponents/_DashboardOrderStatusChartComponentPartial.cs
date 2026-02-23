using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents.DashboardChartsComponents
{
    public class _DashboardOrderStatusChartComponentPartial : ViewComponent
    {
        private readonly EfContext _context;

        public _DashboardOrderStatusChartComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result = _context.Orders.GroupBy(x => x.Status).Select(g => new OrderStatusChartViewModel
            {
                Status = g.Key,
                Count = g.Count()
            }).ToList();
            return View(result);
        }
    }
}
