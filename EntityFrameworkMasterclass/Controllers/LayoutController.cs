using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
