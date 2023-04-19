using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WEBDOG.Data;

namespace WEBDOG.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {

        private readonly ILogger<ReportController> _logger;
        private readonly AppDbContext db;
        private string userlogin
        {
            get
            {
                string userLogin = User.Identity.Name;
                return userLogin;
            }
        }

        public ReportController(ILogger<ReportController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }
        // GET: ReportController
        [HttpPost]
        public async Task<ActionResult> Index(int toExpr1)
        {
            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //toExpr1 = 2018;
            //var listModel = await db.View_SvodDaary.Where(m => m.Expr1 == toExpr1).ToListAsync();
            //return View(listModel);
            var listModel = await db.View_SvodDaary.Where(m => m.myear == toExpr1).Select(m => new View_SvodDaary
            {
                myear = m.myear,
                OrdName2 = m.OrdName2,
                kolSobak = m.kolSobak,
                QvarK1 = m.QvarK1,
                QvarK2 = m.QvarK2,
                QvarK3 = m.QvarK3,
                QvarK4 = m.QvarK4,
                KolDos = m.KolDos
            }).ToListAsync();
            return View(listModel);

        }

        [HttpPost]
        public async Task<ActionResult> SvodAimakD(int toExpr1)
        {
            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //toExpr1 = 2018;
            //var listModel = await db.View_SvodDaary.Where(m => m.Expr1 == toExpr1).ToListAsync();
            //return View(listModel);
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            var listModel = await db.ViewSvodAimaksD.Where(m => m.OrganizationId == orgModel.id && m.myear == toExpr1).Select(m => new ViewSvodAimaksD
            {
                myear = m.myear,
                OrdName2 = m.OrdName2,
                Name = m.Name,
                kolSobak = m.kolSobak,
                QvarK1 = m.QvarK1,
                QvarK2 = m.QvarK2,
                QvarK3 = m.QvarK3,
                QvarK4 = m.QvarK4,
                KolDos = m.KolDos
            }).ToListAsync();
            return View(listModel);

        }



        [HttpPost]
        public async Task<ActionResult> Svod(int toMyear)
        {
            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //var listModel = await db.View_SvodDogKaroos.Where(m => m.myear == toMyear).ToListAsync();
            //return View(listModel);

            var listModel = await db.View_SvodDogKaroo.Where(m => m.myear == toMyear).Select(m => new View_SvodDogKaroo
            {   OrdName = m.OrdName,
                kolSobak=m.kolSobak,
                myear=m.myear,
                QvartK1=m.QvartK1,
                QvartK2=m.QvartK2,
                QvartK3=m.QvartK3,
                QvartK4=m.QvartK4,
                srKolTab=m.srKolTab,
                SumTabl=m.SumTabl 
            }).ToListAsync();
            return View(listModel);
        }

        [HttpPost]
        public async Task<ActionResult> SvodAimak(int toMyear)
        {
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //var listModel = await db.View_SvodDogKaroos.Where(m => m.myear == toMyear).ToListAsync();
            //return View(listModel);

            var listModel = await db.ViewSvodAimak.Where(m => m.OrganizationId == orgModel.id && m.myear == toMyear).Select(m => new ViewSvodAimak
            {
                OrdName = m.OrdName,
                Name = m.Name,
                kolSobak = m.kolSobak,
                myear = m.myear,
                QvartK1 = m.QvartK1,
                QvartK2 = m.QvartK2,
                QvartK3 = m.QvartK3,
                QvartK4 = m.QvartK4,
                srKolTab = m.srKolTab,
                SumTabl = m.SumTabl
            }).ToListAsync();
            return View(listModel);
        }

        [HttpPost]
        public async Task<ActionResult> SvodRegion(int toMyear)
        {
            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //var listModel = await db.View_KarooDaarys.Where(m => m.OrganizationId == orgModel.Id && m.myear == toMyear).ToListAsync();
            //return View(listModel);
            var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            var listModel = await db.View_KarooDaary.Where(m => m.OrganizationId == orgModel.id && m.myear == toMyear).Select(m=> new View_KarooDaary
            {
                OrdName=m.OrdName, 
                Name=m.Name,
                TagNumber=m.TagNumber,
                PhoneNumber=m.PhoneNumber,
                Owner=m.Owner,
                Address=m.Address,
                DogName=m.DogName,
                Colour=m.Colour,
                Gender=m.Gender,
                BirthYear=m.BirthYear,
                Breed=m.Breed,
                CreatedDate=m.CreatedDate,
                IsAlive=m.IsAlive,
                DateOfDeath = m.DateOfDeath,
                myear =m.myear,
                QvartK1=m.QvartK1,
                QvartK2=m.QvartK2,
                QvartK3=m.QvartK3,
                QvartK4=m.QvartK4,
                SumWeght=m.SumWeght,
                KolTab=m.KolTab,
                Expr1=m.Expr1,
                Qvar1=m.Qvar1,
                Qvar2=m.Qvar2,
                Qvar3=m.Qvar3,
                Qvar4=m.Qvar4,
                DoseSum=m.DoseSum
            }).ToListAsync();
            return View(listModel);
        }

        [HttpPost]
        public async Task<ActionResult> ReportDog(string toTagNumber)
        {
            //var listModel = await db.View_KarooDaarys.Where(m => m.TagNumber == toTagNumber).ToListAsync();
            var listModel = await db.View_KarooDaary.Where(m => m.TagNumber == toTagNumber).Select(m => new View_KarooDaary
            {
                OrdName = m.OrdName,
                Name = m.Name,
                TagNumber = m.TagNumber,
                PhoneNumber = m.PhoneNumber,
                Owner = m.Owner,
                Address = m.Address,
                DogName = m.DogName,
                Colour = m.Colour,
                Gender = m.Gender,
                BirthYear = m.BirthYear,
                Breed = m.Breed,
                CreatedDate = m.CreatedDate,
                IsAlive = m.IsAlive,
                DateOfDeath = m.DateOfDeath,
                myear = m.myear,
                QvartK1 = m.QvartK1,
                QvartK2 = m.QvartK2,
                QvartK3 = m.QvartK3,
                QvartK4 = m.QvartK4,
                SumWeght = m.SumWeght,
                KolTab = m.KolTab,
                Expr1 = m.Expr1,
                Qvar1 = m.Qvar1,
                Qvar2 = m.Qvar2,
                Qvar3 = m.Qvar3,
                Qvar4 = m.Qvar4,
                DoseSum = m.DoseSum
            }).ToListAsync();
             
            return View(listModel);
        }



    }
}
