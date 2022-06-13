using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
        private string userlogin
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
        public async Task<ActionResult> Index()
        {
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            var listModel = await db.ViewDogs.Where(m => m.OrganizationId == orgModel.Id).ToListAsync();
            return View(listModel);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]     
        public async Task<IActionResult> Create(DogModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var Dog = new Dog
            {
                CoatoId = model.CoatoId,
                OrganizationId = model.OrganizationId,
                TagNumber = model.TagNumber,
                CreatedDate = DateTime.UtcNow,
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
    }
}