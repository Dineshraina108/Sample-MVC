using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobileshop.Models;
using System.Data.SqlClient;
namespace Mobileshop.Controllers
{
    public class HomeController : Controller
    {
        MobileshopEntities db = new MobileshopEntities();
        MobileshopEntities1 db1 = new MobileshopEntities1();
        userregEntities use = new userregEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login data)
        {
           try
            {
                if(ModelState.IsValid)
                {
                    //db.Logins.Add(data);
                    // db.SaveChanges();
                    var dt=db.Logins.Where(a => a.Username.Equals(data.Username) && a.Password.Equals(data.Password)).FirstOrDefault();
                    if (dt != null)
                    {
                        Session["UserID"] = dt.Id.ToString();
                        Session["Username"] = dt.Username.ToString();
                        ModelState.Clear();
                        //Response.Write("<script>alert('Login sucessfully')</script>");
                        return RedirectToAction("Index", "Product");
                     
                    }
                }
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                return RedirectToAction("Login");
            }        
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
              
                return View();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }
        public ActionResult Lreg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lreg(Lreg data)
        {
            string user = data.Username;
            string pass = data.Password;
            try
            { 
                if (ModelState.IsValid)
                {   
                    var dt = db1.Lregs.Where(a => a.Username.Equals(data.Username) && a.Password.Equals(data.Password)).FirstOrDefault();
                      if (dt == null)
                      {
                        db1.Lregs.Add(data);
                        db1.SaveChanges();
                        int c = db.Logins.Count();
                        Login l = new Login();
                        l.Id = c + 1;
                        l.Username = user;
                        l.Password = pass;
                        db.Logins.Add(l);
                        db.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Login");
                      }
                      else
                      {
                        ModelState.Clear();
                        return View(new Lreg());
                      
                      }
                   
                }
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                return RedirectToAction("Lreg");
            }
        }
       
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Userreg regdata)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    use.Userregs.Add(regdata);
                    use.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Lreg");
                }
                ModelState.Clear();
                return View();
            } 
           catch (Exception e)
            {
                ModelState.Clear();
                return RedirectToAction("Login");
            }
          
        }
        public ActionResult Cancel()
        {
            ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}