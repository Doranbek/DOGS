using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WEBDOG.Data;

namespace WEBDOG.Controllers
{
    public class KarooController : Controller
    {
        private readonly ILogger<KarooController> _logger;
        private readonly AppDbContext db;

        public KarooController(ILogger<KarooController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: KarooController
        public async Task<ActionResult> Index(Guid id)
        {
            var listModel = await db.DogKaroos.FirstOrDefaultAsync(m => m.Id == id);
            return View(listModel);
        }

        // GET: KarooController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KarooController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KarooController/Create
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

        // GET: KarooController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KarooController/Edit/5
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

        // GET: KarooController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KarooController/Delete/5
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
