using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBDOG.Data;
using WEBDOG.Models;

namespace WEBDOG.Controllers
{
    public class KarooController : Controller
    {
        private readonly ILogger<KarooController> _logger;
        private readonly AppDbContext db;
        private  Guid _id;

        public KarooController(ILogger<KarooController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        //GET: KarooController
        public async Task<ActionResult> Index(Guid id)
        {
            _id = id;
            var listModel = await db.DogKaroos.Where(m => m.DogId == id).ToListAsync();
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
        public async Task<IActionResult> Create(DogKarooModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var DogKaroo = new DogKaroo
            {
                DogId = _id,
                Date = model.Date,
                DrugId = 2,
                Weight = model.Weight,
                QuantityDrug = model.QuantityDrug,
                Description = model.Description
            };

            db.Add(DogKaroo);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: KarooController/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogkaroo = await db.DogKaroos.FindAsync(id);
            if (dogkaroo == null)
            {
                return NotFound();
            }
            return View(dogkaroo);
        }

        // POST: KarooController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, DogKaroo dogkaroo)
        {
            if (id != dogkaroo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(dogkaroo);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(dogkaroo);
        }

        // GET: KarooController/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var karoo = await db.DogKaroos.FirstOrDefaultAsync(m => m.Id == (Guid)id);
            if (karoo == null)
            {
                return NotFound();
            }

            return View(karoo);
        }

        // POST: KarooController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Delkaroo = await db.DogKaroos.FindAsync(id);
            db.DogKaroos.Remove(Delkaroo);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
