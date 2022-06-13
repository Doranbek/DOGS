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
    public class DaaryController : Controller
    {
        private readonly ILogger<DaaryController> _logger;
        private readonly AppDbContext db;
        private Guid dogId;
        private Guid id;

        public DaaryController(ILogger<DaaryController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DaaryController
        public async Task<ActionResult> Index(Guid id)
        {
            dogId = id;
            var listModel = await db.DogDaarys.Where(p=>p.DogId==id).ToListAsync();
            return View(listModel);
        }

        // GET: DaaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public IActionResult Create(Guid id)
        {
            dogId = id;
           //var  DrugItems = db.Drugs.Select(p => new SelectListItem()
           var  DrugItems =(from DrugModelID in db.Drugs select new SelectListItem()
                {
                    Text = DrugModelID.Name,
                    Value = DrugModelID.Id.ToString()
                }).ToList();
            DrugItems.Insert(0, new SelectListItem()
            {
                Text="-Выбрать лекарство-",
                Value=string.Empty 
            });
            ViewBag.ListDrugIdOff = DrugItems;
            return View();
            
        }
        //public IActionResult ReIndex()
        //{
        //    //var viewmodelDrug = new DrugModel();
        //    var  items = db.Drugs.Select(p => new SelectListItem()
        //    {
        //        Value = p.Id.ToString(),
        //        Text = p.Name
        //    }).ToList();
            
        //    return View(items);
        //    //return View();
        //}


        // POST: DaaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DogDaaryModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var DogDaary = new DogDaary
            {
                DogId = id,
                //PersonId = model.PersonId,
                Date = DateTime.UtcNow,
                Disease = model.Disease,
                Dose  = model.Dose,
                DrugId =model.DrugId,
                Description = model.Description                
            };

            db.Add(DogDaary);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }

        // GET: DaaryController/Edit/5
        public async Task <ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogdaary = await db.DogDaarys.FindAsync(id);

            if (dogdaary == null)
            {
                return NotFound();
            }
            return View(dogdaary);

            //var DrugItems2 = (from DrugModelID in db.Drugs
            //                 select new SelectListItem()
            //                 {
            //                     Text = DrugModelID.Name,
            //                     Value = DrugModelID.Id.ToString()
            //                 }).ToList();
            //DrugItems2.Insert(0, new SelectListItem()
            //{
            //    Text = "-Выбрать лекарство-",
            //    Value = string.Empty
            //});
            //ViewBag.ListDrugIdOff = DrugItems2;
            //return View();
        }

        // POST: DaaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, DogDaary dogdaary)
        {
            if (id != dogdaary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(dogdaary);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(dogdaary);
        }

        // GET: DaaryController/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daary = await db.DogKaroos.FirstOrDefaultAsync(m => m.Id == (Guid)id);
            if (daary == null)
            {
                return NotFound();
            }

            return View(daary);
        }

        // POST: DaaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Deldaary = await db.DogDaarys.FindAsync(id);
            db.DogDaarys.Remove(Deldaary);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
