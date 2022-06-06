using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WEBDOG.Data;

namespace WEBDOG.Controllers
{
    [Authorize]
    public class DrugController : Controller
    {
        private readonly ILogger<DrugController> _logger;
        private readonly AppDbContext db;

        public DrugController(ILogger<DrugController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DrugController
        public async Task<ActionResult> Index()
        {
            var listModel = await db.Drugs.ToListAsync();
            return View(listModel);
        }

        // GET: DrugController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugController/Create
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

        // GET: DrugController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrugController/Edit/5
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

        // GET: DrugController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrugController/Delete/5
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
