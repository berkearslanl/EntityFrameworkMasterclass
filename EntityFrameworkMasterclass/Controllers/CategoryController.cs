using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EfContext _context;

        public CategoryController(EfContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        public IActionResult ReverseCategory()
        {
            var categoryValue = _context.Categories.First();
            ViewBag.categoryValue = categoryValue.CategoryName;

            var categoryValue2 = _context.Categories.SingleOrDefault(x => x.CategoryName == "Anne ve Bebek Ürünleri");
            ViewBag.categoryValue2 = categoryValue2.CategoryStatus+"-"+categoryValue2.CategoryId.ToString();

            var values = _context.Categories.OrderBy(x => x.CategoryId).Reverse().ToList();
            return View(values);
        }
    }
}
