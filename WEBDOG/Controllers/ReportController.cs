using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WEBDOG.Data;

namespace WEBDOG.Controllers
{
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
        //[HttpPost]
        public async Task<ActionResult> Index(int toExpr1)
        {
            //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //toExpr1 = 2018;
            //var listModel = await db.View_SvodDaary.Where(m => m.Expr1 == toExpr1).ToListAsync();
            //return View(listModel);
            var listModel = await db.View_SvodDaary.Where(m => m.Expr1 == toExpr1).Select(m => new View_SvodDaary
            {
                Expr1 = m.Expr1,
                OrdName = m.OrdName,
                kolSobak = m.kolSobak,
                QvarK1 = m.QvarK1,
                QvarK2 = m.QvarK2,
                QvarK3 = m.QvarK3,
                QvarK4 = m.QvarK4,
                KolDos = m.KolDos
            }).ToListAsync();
            return View(listModel);

        }



            //[HttpPost]
            //public async Task<ActionResult> Svod(int toMyear)
            //{
            //    //var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //    var listModel = await db.View_SvodDogKaroos.Where(m => m.myear == toMyear).ToListAsync();
            //    return View(listModel);
            //}

            //[HttpPost]
            //public async Task<ActionResult> SvodRegion(int toMyear)
            //{
            //    var orgModel = await db.Organizations.FirstAsync(m => m.Login == userlogin);
            //    var listModel = await db.View_KarooDaarys.Where(m => m.OrganizationId == orgModel.Id && m.myear == toMyear).ToListAsync();
            //    return View(listModel);
            //}

            //[HttpPost]
            //public async Task<ActionResult> ReportDog(string toTagNumber)
            //{
            //    var listModel = await db.View_KarooDaarys.Where(m =>m.TagNumber == toTagNumber).ToListAsync();
            //    return View(listModel);
            //}


        
    }
}
