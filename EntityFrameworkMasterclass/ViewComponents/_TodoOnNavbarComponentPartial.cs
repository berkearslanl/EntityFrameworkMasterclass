using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _TodoOnNavbarComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _TodoOnNavbarComponentPartial(EfContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.Where(y=>y.Status==false).OrderByDescending(x => x.TodoId).Take(5).ToList();
            ViewBag.todoCount = _context.Todos.Count();
            return View(values);
        }
    }
}
