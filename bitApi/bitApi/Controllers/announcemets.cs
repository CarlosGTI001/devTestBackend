using bitApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bitApi.Controllers
{
    public class announcemets : Controller
    {
        bitApiContext _context;
        // GET: announcemets
        public void announcement(bitApiContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: announcemets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: announcemets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: announcemets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: announcemets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: announcemets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: announcemets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: announcemets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
