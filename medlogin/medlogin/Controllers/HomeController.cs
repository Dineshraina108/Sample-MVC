using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medlogin.Models;
namespace medlogin.Controllers
{
    public class HomeController : Controller
    {
        medicalLoginEntities db = new medicalLoginEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";     
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lda)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                var error = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                if (ModelState.IsValid)
                {
                    var dt = db.Logins.Where(a => a.Username.Equals(lda.Username) && a.Password.Equals(lda.Password)).FirstOrDefault();
                    if (dt != null)
                    {
                        Session["Username"] = dt.Username.ToString();
                        return RedirectToAction("Doctorlist","Doctor");
                    }
                    else
                    {
                        ViewBag.Message = "User not exist";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "error";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reg(Login data)
        {
            try
            {
                if(ModelState.IsValid)
                {                
                    db.Logins.Add(data);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Login","Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("reg");
            }
        }
        public ActionResult Cancel()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Home");
          
        }
    }
}