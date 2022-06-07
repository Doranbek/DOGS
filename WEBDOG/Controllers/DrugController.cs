using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WEBDOG.Data;
using WEBDOG.Models;

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

        // GET: DrugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrugModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var Drug = new Drug
            {
                Name = model.Name,
                SerialNumber = model.SerialNumber,
                ExpirationDate = model.ExpirationDate,
                Description = model.Description
            };

            db.Add(Drug);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: DrugController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await db.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        // POST: DrugController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Drug drug)
        {

            if (id != drug.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(drug);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(drug);
        }

        // GET: DrugController/Delete/5
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await db.Drugs.FirstOrDefaultAsync(m => m.Id == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // POST: DrugController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var Drug = await db.Drugs.FindAsync(id);
            db.Drugs.Remove(Drug);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
