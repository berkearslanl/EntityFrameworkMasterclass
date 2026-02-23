using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarTodoListComponentPartial:ViewComponent
    {
        private readonly EfContext _context;

        public _RightSidebarTodoListComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderBy(x => x.TodoId).ToList().TakeLast(15).ToList();
            return View(values);
        }
    }
}
