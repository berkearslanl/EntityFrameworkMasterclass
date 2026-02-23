using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarMessageCompoınentPartial : ViewComponent
    {
        private readonly EfContext _context;

        public _RightSidebarMessageCompoınentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(x=>x.IsRead==false).ToList();
            return View(values);
        }
    }
}
