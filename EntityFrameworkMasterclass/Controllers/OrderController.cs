using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Entities;
using EntityFrameworkMasterclass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace EntityFrameworkMasterclass.Controllers
{
    public class OrderController : Controller
    {
        private readonly EfContext _context;

        public OrderController(EfContext context)
        {
            _context = context;
        }

        public IActionResult AllCountSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderStockCount)
            {
                ViewBag.v = "Tüm siparişler 5 adetten küçüktür";
            }
            else
            {
                ViewBag.v = "Tüm siparişler 5 adetten büyüktür!";
            }
            return View();
        }
        public IActionResult OrderListFilter(string text)
        {
            var allValues = _context.Orders.Include(x => x.Product).Include(x => x.Customer).ToList();
            var values = _context.Orders
                .Include(x => x.Product)
                .Include(x => x.Customer)
                .Where(x =>
                x.Status.Contains(text) ||
                x.Customer.CustomerName.Contains(text) ||
                x.Customer.CustomerSurname.Contains(text) ||
                x.Product.ProductName.Contains(text)
                ).ToList();
            if (!values.Any())
            {
                ViewBag.a = "Bu status ile ilgili veri bulunamadı!";
            }
            else
            {
                return View(values);
            }
            return View(allValues);
        }

        public IActionResult OrderListSearch(string name, string filterType)
        {
            if (filterType == "start")
            {
                var values = _context.Orders.Include(x => x.Product).Include(x => x.Customer).Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (filterType == "end")
            {
                var values = _context.Orders.Include(x => x.Product).Include(x => x.Customer).Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            var ordvalues = _context.Orders.Include(x => x.Product).Include(x => x.Customer).ToList();
            return View(ordvalues);
        }

        public async Task<IActionResult> OrderListAsyncMethod()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(z => z.Customer).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products = await _context.Products
                            .Select(x => new SelectListItem
                            {
                                Text = x.ProductName,
                                Value = x.ProductId.ToString()
                            }).ToListAsync();
            ViewBag.products = products;

            var customers = await _context.Customers
                            .Select(x => new SelectListItem
                            {
                                Text = x.CustomerName + " " + x.CustomerSurname,
                                Value = x.CustomerId.ToString()
                            }).ToListAsync();
            ViewBag.customers = customers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Sipariş Alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsyncMethod");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsyncMethod");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var products = await _context.Products
                            .Select(x => new SelectListItem
                            {
                                Text = x.ProductName,
                                Value = x.ProductId.ToString()
                            }).ToListAsync();
            ViewBag.products = products;

            var customers = await _context.Customers
                            .Select(x => new SelectListItem
                            {
                                Text = x.CustomerName + " " + x.CustomerSurname,
                                Value = x.CustomerId.ToString()
                            }).ToListAsync();
            ViewBag.customers = customers;

            var value = await _context.Orders.FindAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsyncMethod");
        }
        public IActionResult OrderListWithCustomerGroup()
        {
            var result = from customer in _context.Customers
                         join o in _context.Orders
                         on customer.CustomerId equals o.CustomerId
                         into orderGroup
                         select new CustomerOrderViewModel
                         {
                             CustomerName = customer.CustomerName +" "+customer.CustomerSurname,
                             Orders = orderGroup.ToList()
                         };
            return View(result.ToList());
        }
    }
}
