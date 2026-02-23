using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents
{
    public class _MessageOnNavbarComponentPartial : ViewComponent
    {
        private readonly EfContext _context;

        public _MessageOnNavbarComponentPartial(EfContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.OrderByDescending(x => x.MessageId).Where(y => y.IsRead == false).Take(3).ToList();
            ViewBag.messageCount = _context.Messages.Where(x => x.IsRead == false).Count();
            return View(values);
        }
    }
}
