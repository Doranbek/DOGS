using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WEBDOG.Data;
using WEBDOG.Models;


namespace WEBDOG.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        private readonly ILogger<DogController> _logger;
        private readonly AppDbContext db;
        //private string userlogin
            public string userlogin
        {
            get
            {
                string userLogin = User.Identity.Name;
                return userLogin;
            }
        }

        public DogController(ILogger<DogController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: DogController
        //public async Task<ActionResult> Index(int page = 1)
        //{
        //    int pageSize = 50;
        //    var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
        //    IQueryable<ViewDog> source = db.ViewDogs.Where(m => m.OrganizationId == orgModel.id);
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        //    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
        //    IndexViewModel viewModel = new IndexViewModel
        //    {
        //        PageViewModel = pageViewModel,
        //        ViewDogs = items
        //    };
        //    return View(viewModel);
        //}
        public async Task<ActionResult> Index(int page = 1, string SearchDogs = default)
        {
            int pageSize = 50;
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);

            //var orgModel = db.Organizations.Where(m => m.Login == userlogin).ToListAsync();
            IQueryable<ViewDog> source = db.ViewDogs.Where(m => m.OrganizationId == orgModel.id).OrderByDescending(m => m.CreatedDate);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            if (!String.IsNullOrEmpty(SearchDogs))
            {
                items = await db.ViewDogs.Where(s => s.TagNumber.Contains(SearchDogs)&& s.OrganizationId == orgModel.id).ToListAsync();
                //return View(viewModel);

            }
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                ViewDogs = items
            };

            return View(viewModel);

            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //var listModel = await db.ViewDogs.Where(m => m.OrganizationId == orgModel.Id).ToListAsync();
            //return View(listModel);
        }
        //public ActionResult Index(string SearchDogs)
        //{
        //    //var TagNumberSearch = from m in db.ViewDogs
        //    //             select m;
        //    var TagNumberSearch;
        //    if (!String.IsNullOrEmpty(SearchDogs))
        //    {
        //        var TagNumberSearch = await db.ViewDogs.Where(s => s.TagNumber.Contains(SearchDogs)).ToListAsync();
        //        return View(TagNumberSearch);

        //    }
        //    return View(viewModel);

        //}
        // GET: DogController/Create
        public async Task<ActionResult> Create()
        {
            var orgModelCoat = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            var selectCoats = (from coats in db.Coats.Where(m=>m.OrgIdCoats== orgModelCoat.id)
                               select new SelectListItem()
                               {
                                   Text = coats.Name,
                                   Value = coats.Id.ToString()
                               }).ToList();
            selectCoats.Insert(0, new SelectListItem()
            {
                Text = "-Выбрать населенный пункт-",
                Value = string.Empty
            });
            ViewBag.ListCoatIdOff = selectCoats;

            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]     
        public async Task<IActionResult> Create(DogModel model)
        {
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            if (!ModelState.IsValid) return View(model);

            var Dog = new Dog
            {
                CoatoId = model.CoatoId,
                OrganizationId = orgModel.id,
                TagNumber = model.TagNumber,
                CreatedDate = model.CreatedDate,
                Owner = model.Owner,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                DogName = model.DogName, 
                Colour = model.Colour,
                Gender = model.Gender,
                BirthYear = model.BirthYear,
                Breed = model.Breed,
                Description = model.Description,
                IsAlive = model.IsAlive

            };

            db.Add(Dog);

            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: DogController/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var dog = await db.Dogs.FirstOrDefaultAsync(m => m.id == (Guid)id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Deldog = await db.Dogs.FindAsync(id);
            db.Dogs.Remove(Deldog);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editDog = await db.Dogs.FindAsync(id);
            if (editDog == null)
            {
                return NotFound();
            }
            return View(editDog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Dog model)
        {
            if (id != model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(model);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}