using curdoperation.Context;
using curdoperation.Models;
using Dapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperation.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly IDbConnection db2;
       
        Adio_CRUD_DAL dbContex = new Adio_CRUD_DAL();

        readonly masterContext _auc;
        readonly masterContext db = new masterContext();
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration config ,masterContext auc, ILogger<HomeController> logger, IConfiguration configuration)
        {
             db2 = new SqlConnection(configuration.GetConnectionString("connection"));

            configuration = config;
            _auc = auc;
            _logger = logger;
        }


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var sql = "SELECT * FROM Curd";
        //    List<Curd> result = db2.Query<Curd>(sql).ToList();
        //    return View(result);
        //}


        [HttpGet]
        public IActionResult Index()
        {
            var getdata = new Adio_CRUD_DAL();

            List<Curd> result = dbContex.GetAllStudent().ToList();
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            if (id == null) return NotFound();
            Curd curd = dbContex.GetStudentById(id);
            if(curd == null)
            {
                return NotFound();
            }
            return View(curd);

        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdateCurd(int sd, Curd curd)
        //{
        //    try
        //    {
        //        sd = curd.Newid;
        //        if (sd != null)
        //        {

        //            var ID = curd.Newid;

        //            var sql = "UPDATE Curd SET firstname = @Firstname, lastname = @Lastname, Birthdate = @Birthdate, zodiac = @Zodiac ," +
        //                "mobileno = @Mobileno, email= @Email WHERE newid = @Newid";

        //            db2.Execute(sql, curd);

        //            return View("Index");
        //        }
        //        return View("Index");
        //    }

        //    catch (Exception cd)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View("Index");
        //}


















        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult UpdateCurd(int sd ,Curd curd)
        //{
        //    try
        //    {
        //        sd = curd.Newid;
        //        if (sd != null)
        //        {

        //            var ID = curd.Newid;

        //            var sql = "UPDATE Curd SET firstname = @Firstname, lastname = @Lastname, Birthdate = @Birthdate, zodiac = @Zodiac ," +
        //                "mobileno = @Mobileno, email= @Email WHERE newid = @Newid";

        //            db2.Execute(sql, curd);

        //            return View("Index");
        //        }
        //        return View("Index");
        //    }

        //    catch (Exception cd)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View("Index");
        //}




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCurd(int sd, [Bind] Curd curd)
        {

            try
            {

                if (sd != null)
                {
                    dbContex.CreateStudent(curd);
                    return RedirectToAction("Index", "Home");

                }


                //else
                //{
                //    sd = curd.Newid;
                //    curd.Newid = sd;
                //    dbContex.UpdateStudent(curd);
                //    return RedirectToAction("Index", "Home");


                //}
                return View("Index");

            }

            catch (Exception cd)
            {

                dbContex.UpdateStudent(curd);
                return RedirectToAction("Index", "Home");

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }



        }

        [HttpPost]
        public IActionResult UiipdateCurd(Curd curd)
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
                ViewBag.Message = "Adduser";
                return View();
            }
            else
            {
                ViewBag.Message = "Edit";

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


        //[HttpPost]
        //public IActionResult Delt(Curd id)
        //{
        //    try
        //    {
        //        var sql = "DELETE FROM Curd WHERE newid = @Newid";

        //       db2.Execute(sql, new { @Id = id });

        //        return RedirectToAction("Index");
        //    }

        //    catch (Exception cd)
        //    {
        //        return View("Index");
        //    }
        //}




        [HttpPost]

        public IActionResult Delt(Curd del)
        {
            try
            {
                dbContex.DeleteStudent(del.Newid);
                return RedirectToAction("Index");
            }
            catch (Exception cd)
            {
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
