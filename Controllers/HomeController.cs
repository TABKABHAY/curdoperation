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

        public IActionResult Index()
        {
            return View();
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
            int? Id = HttpContext.Session.GetInt32("Newid");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["Newid"]);
            }
            Curd u = db.Curds.FirstOrDefault(x => x.Newid == Id);
            u.Firstname = curd.Firstname;
            u.Lastname = curd.Lastname;
            u.Mobileno = curd.Mobileno;
            u.Zodiac = curd.Zodiac;
            u.Birthdate = curd.Birthdate;
            u.Email = curd.Email;

            var result = db.Curds.Update(u);
            db.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
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
