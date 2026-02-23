using EntityFrameworkMasterclass.Context;
using EntityFrameworkMasterclass.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.Controllers
{
    public class TodoController : Controller
    {
        private readonly EfContext _context;

        public TodoController(EfContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TodoList()
        {
            var values = _context.Todos.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDo()
        {
            var todos = new List<Todo>
            {
                new Todo {Description="Mail gönder",Status=true,Priority="Birincil" },
                new Todo {Description="Rapor hazırla",Status=true,Priority="İkincil" },
                new Todo {Description="Toplantıya katıl",Status=false,Priority="Birincil" }
            };

            _context.Todos.AddRange(todos);
            _context.SaveChanges();

            return View();
        }
        public IActionResult TodoAggreagatePriority()
        {
            var priorityFirstlyTodo = _context.Todos
                                        .Where(x => x.Priority == "Birincil")
                                        .Select(x => x.Description)
                                        .ToList();
            string result = priorityFirstlyTodo.Aggregate(string.Empty, (acc, desc) => acc + $"<li>{desc}</li>");
            ViewBag.result = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos
                                 .Where(x => !x.Status)
                                 .Select(y => y.Description)
                                 .ToList()
                                 .Prepend("Gün başında tüm görevleri kontrol etmeyi unutmayın!")
                                 .ToList();
            return View(values);
        }
        public IActionResult TodoChunk()
        {
            var values = _context.Todos
                                 .Where(x => x.Status == false)
                                 .ToList()
                                 .Chunk(2)
                                 .ToList();
            return View(values);
        }
        public IActionResult TodoConcat()
        {
            var values = _context.Todos
                                 .Where(x => x.Priority == "Birincil")
                                 .ToList()
                                 .Concat
                                 (
                                    _context.Todos.Where(y => y.Priority == "İkincil").ToList()
                                 ).ToList();
            return View(values);
        }
        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList();
            var values2 = _context.Todos.Where(x => x.Priority == "İkincil").ToList();

            var result = values.UnionBy(values2,x=>x.Description).ToList();
            return View(result);
        }
    }
}
