using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobileshop.Models;
namespace Mobileshop.Controllers
{
    public class ProductController : Controller
    {
        MobileshopEntities db = new MobileshopEntities();
        ProductEntities pro = new ProductEntities();
        // GET: Product
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult home()
        {
            return View();
        }
        public ActionResult loginlist(string search)
        {
            List<Login> LoginList = db.Logins.ToList();
            return View(db.Logins.Where(x => x.Username == search || search == null).ToList());
            //pass the StudentList list object to the view.  
            //return View(LoginList);
            //var userId =Convert.ToInt32(Session["userId"].ToString());
            //  return View(db.Logins.Where(t => t.Id == userId).ToList());
            /*   if (option=="Username")
               { 
                   //Index action method will return a view with a student records based on what a user specify the value in textbox  
                   return View(db.Logins.Where(x => x.Username == search || search == null).ToList());
               }
              else if(option=="Password")
               {
                   return View(db.Logins.Where(x => x.Password == search || search == null).ToList());
               }
               else
               {
                   return View(LoginList);
               }*/
           }
        public ActionResult imgemodel()
           {
            return View();
           }
        public ActionResult Product()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Product(Product p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pro.Products.Add(p);
                    pro.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }
        }
    }
   }
