using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WEBDOG.Data;

namespace WEBDOG.Controllers
{
    public class DaaryController : Controller
    {
        private readonly ILogger<DaaryController> _logger;
        private readonly AppDbContext db;

        public DaaryController(ILogger<DaaryController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DaaryController
        public async Task<ActionResult> Index()
        {
            var listModel = await db.DogDaarys.ToListAsync();
            return View(listModel);
        }


        // GET: DaaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DaaryController/Create
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

        // GET: DaaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DaaryController/Edit/5
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

        // GET: DaaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DaaryController/Delete/5
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
