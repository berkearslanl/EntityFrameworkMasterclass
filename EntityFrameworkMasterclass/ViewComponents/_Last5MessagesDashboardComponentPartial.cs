using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _Last5MessagesDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _Last5MessagesDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.OrderBy(x => x.MessageId).ToList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
