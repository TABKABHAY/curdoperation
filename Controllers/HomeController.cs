using curdoperation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperation.Controllers
{
    public class HomeController : Controller
    {
        readonly masterContext _auc;
        readonly masterContext db = new masterContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(masterContext auc, ILogger<HomeController> logger)
        {

            _auc = auc;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index2()
        {
            var crd = db.Curds.ToList();
            List<curdoperation.Models.Curd> result = new List<Curd>();
            foreach (Curd temp in crd)
            {
                result.Add(temp);
            }
            return View(result);
        }


        public IActionResult Index( int pageNumber=1,int pageSize=1)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            var crd = db.Curds.ToList();
            List<curdoperation.Models.Curd> result = new List<Curd>();
            foreach (Curd temp in crd)
            {
                result.Add(temp);
            }
            return View(result);
        }















        [HttpPost]
        public IActionResult Newent(Curd crd)
        {
            _auc.Add(crd);
            _auc.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Getcurd()
        {
            int? Id = HttpContext.Session.GetInt32("Newid");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["Newid"]);
            }
            Curd crd = db.Curds.FirstOrDefault(x => x.Newid == Id);
            return new JsonResult(crd);

        }

        [HttpPost]
        public IActionResult UpdateCurd(Curd curd)
        {
            Curd u = db.Curds.FirstOrDefault(x=> x.Newid == curd.Newid);
            if (u != null)
            {
                u.Firstname = curd.Firstname;
                u.Lastname = curd.Lastname;
                u.Mobileno = curd.Mobileno;
                u.Zodiac = curd.Zodiac;
                u.Birthdate = curd.Birthdate;
                u.Email = curd.Email;
                var result = db.Curds.Update(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _auc.Add(curd);
                _auc.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult adddata(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {

                Curd obj = db.Curds.Where(x => x.Newid == id).FirstOrDefault();
                return View(obj);
            }
        }
        [HttpGet]
        public IActionResult delt(int id)
        {
            Curd obj = db.Curds.Where(x => x.Newid == id).FirstOrDefault();
            return View(obj);
        }



        [HttpPost]
        public IActionResult Delt(Curd del)
        {

            Curd obj = db.Curds.Where(x => x.Newid == del.Newid).FirstOrDefault();
            db.Curds.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
