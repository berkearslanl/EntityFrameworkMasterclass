using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMasterclass.Controllers
{
    public class MessageController : Controller
    {
        private readonly EfContext _context;

        public MessageController(EfContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.AsNoTracking().ToList();
            return View(values);
        }
    }
}
