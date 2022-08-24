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
        public async Task<ActionResult> Index(Guid id)
        {            
            var listModel = await db.DogDaarys.Where(p => p.DogId == id).Join(db.Drugs, d => d.DrugId, p => p.Id, (d, p) => new DogDaary
            {
                Id = d.Id,
                DogId = d.DogId,
                Date = d.Date,
                Dose = d.Dose,
                //NameDar = p.Name,
                Description = d.Description

            }).ToListAsync();

            return View(listModel);
        }

        // GET: DaaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //-----------------------------------------------Начало добавление нового запися-----------------------------------------------
        //------------------------------

        public IActionResult CreateNew()
        {

            return View();
        }

        //------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(NewDaaryModel modelnew)
        {
            if (!ModelState.IsValid) return View(modelnew);
            var modelDNew = await db.Dogs.Where(m => m.TagNumber == modelnew.TagNumber).FirstAsync();

            var DogDaary = new DogDaary
            {
                DogId = modelDNew.id,
                Date = modelnew.Date,
                Dose = modelnew.Dose,
                DrugId = 2,
                Description = modelnew.Description
            };

            db.Add(DogDaary);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        //-----------------------------------------------Конец добавление нового запися-----------------------------------------------

        public async Task<IActionResult> Create(Guid Id)
        {
            var modelF = await db.DogDaarys.Where(m => m.Id == Id).FirstAsync();

            DogDaaryModel model = new DogDaaryModel();
            model.DogId = modelF.DogId;
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
            return View(model);
            
        }    

        // POST: DaaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DogDaaryModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var DogDaary = new DogDaary
            {
                DogId = model.DogId,
                Date = model.Date,
                Dose  = model.Dose,
                DrugId = 2,
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

        }

        // POST: DaaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, DogDaary dogdaary)
        {
            var DogDaaryCreate = new DogDaary
            {
                Id = dogdaary.Id,
                DogId = dogdaary.DogId,
                Date = dogdaary.Date,
                Dose = dogdaary.Dose,
                DrugId = 2,
                Description = dogdaary.Description
            };


            db.Update(DogDaaryCreate);
                    await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: DaaryController/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var daary = await db.DogDaarys.FirstOrDefaultAsync(m => m.Id == (Guid)id);
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
