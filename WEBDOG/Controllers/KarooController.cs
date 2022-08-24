using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class KarooController : Controller
    {
        private readonly ILogger<KarooController> _logger;
        private readonly AppDbContext db;

        public KarooController(ILogger<KarooController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        //GET: KarooController
        public async Task<ActionResult> Index(Guid id)
        {
            var model = await db.DogKaroos.Where(m => m.DogId == id).ToListAsync();            
            return View(model);
        }

        // GET: KarooController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //---------------------------------------------------Новый запись------------------------------------------
        //public IActionResult SearchKaroo()
        //{
        //    return View();
        //}
        //------------------------------

        public IActionResult CreateNew()
        {   

            return View();
        }

        //------------------------------

        // POST: KarooController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(NewKarooModel model0)
        {
            if (!ModelState.IsValid) return View(model0);
            var modelFNew = await db.Dogs.Where(m => m.TagNumber == model0.TagNumber).FirstAsync();

            var DogKaroo = new DogKaroo
            {   
                DogId = modelFNew.id,
                Date = model0.Date,
                DrugId = 2,
                Weight = model0.Weight,
                QuantityDrug = model0.QuantityDrug,
                Description = model0.Description
            };

            db.Add(DogKaroo);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //---------------------------------------------------Конец новый запись------------------------------------

        //---------------------------------------------------------------------------------------------------------
        /// Начало заполнение если есть у собаки история 
      
        // GET: KarooController/Create
        public async Task<ActionResult> Create(Guid Id)
        {
            var modelF = await db.DogKaroos.Where(m => m.Id == Id).FirstAsync();
            DogKarooModel model = new DogKarooModel();
            model.DogId = modelF.DogId;
            model.Weight = modelF.Weight;
            return View(model);
        }

        // POST: KarooController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DogKarooModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var DogKaroo = new DogKaroo
            {
                DogId = model.DogId,
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
            if (ModelState.IsValid)
            {
               
                    db.Update(dogkaroo);
                    await db.SaveChangesAsync();              

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
