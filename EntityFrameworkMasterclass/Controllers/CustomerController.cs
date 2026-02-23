using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Entities;
using EntityFrameworkMasterclass.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.Controllers
{
    public class CustomerController : Controller
    {
        private readonly EfContext _context;

        public CustomerController(EfContext context)
        {
            _context = context;
        }

        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName).ToList();
            return View(values);
        }
        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _context.Customers.Any(x => x.CustomerCity == city);
            if (exist)
            {
                ViewBag.message = $"{city} şehrinde en az 1 tane müşteri var!";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok!";
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerListByCity()
        {
            var value = _context.Customers
                .ToList()
                .GroupBy(x => x.CustomerCity)
                .ToList();
            return View(value);
        }
        public IActionResult CustomerByCityCount()
        {
            var query =
                from c in _context.Customers
                group c by c.CustomerCity into g
                select new CustomerCityGroup
                {
                    City = g.Key,
                    CustomerCount = g.Count()
                };
            var model = query.OrderByDescending(x => x.CustomerCount).ToList();
            return View(model);
        }
        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result = customers
                         .AsParallel()
                         .Where(x => x.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                         .ToList();
            return View(result);

        }
        public IActionResult CustomerListExceptCityIstanbul()
        {
            var allCustomers = _context.Customers.ToList();
            var customersListInIstanbul = _context.Customers
                                                  .Where(x => x.CustomerCity == "Istanbul")
                                                  .Select(x => x.CustomerId)
                                                  .ToList();
            var result = allCustomers.ExceptBy(customersListInIstanbul, c => c.CustomerId).ToList();

            return View(result);
        }

        public IActionResult CustomersListWithDefaultIfEmpty()
        {
            var values = _context.Customers.ToList();
            var customers = _context.Customers.Where(x => x.CustomerDistrict == null).ToList().DefaultIfEmpty(new Customer
            {
                CustomerDistrict = "Merkez"
            }).ToList();
            return View(customers);
        }
        public IActionResult CustomerIntersectByCity()
        {
            var city1 = _context.Customers.Where(y => y.CustomerCity == "Istanbul")
                .Select(x => x.CustomerName + " " + x.CustomerSurname).ToList();
            var city2 = _context.Customers.Where(y => y.CustomerCity == "Antalya")
                .Select(x => x.CustomerName + " " + x.CustomerSurname).ToList();

            var intersectValues = city1.Intersect(city2).ToList();
            return View(intersectValues);
        }
        public IActionResult CustomerCastExample()
        {
            var values = _context.Customers.ToList();
            ViewBag.v = values;
            return View();
        }
        public IActionResult CustomerListWithIndex()
        {
            var customers = _context.Customers.ToList().Select((c, index) => new
            {
                SiraNo = index + 1,
                c.CustomerName,
                c.CustomerSurname,
                c.CustomerCity
            }).ToList();
            return View(customers);
        }
    }
}
