using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _TodoDashboardComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _TodoDashboardComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderByDescending(x => x.TodoId).Take(6).ToList();
            return View(values);
        }
    }
}
