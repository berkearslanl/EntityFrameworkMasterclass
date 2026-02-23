using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _Last5ProductDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _Last5ProductDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(x => x.ProductId).ToList().SkipLast(5).ToList().TakeLast(7).ToList();
            return View(values);
        }
    }
}
