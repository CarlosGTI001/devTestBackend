using Client.Data;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ClientContext _context;
        public HomeController(ILogger<HomeController> logger, ClientContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string s)
        {
            if (s == null)
            {
                return View(_context.announcement.OrderByDescending(a => a.date));
            }
            else
            {
                ViewBag.s = s;
                return View(_context.announcement.Where(a => a.title.Contains(s) || a.content.Contains(s)).OrderByDescending(a => a.date));
            }
        }

        public IActionResult ViewArticle(int id)
        {
            var article = _context.announcement.Where(a => a.id == id).FirstOrDefault();
            if (article != null)
            {
                return View(article);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}