using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rating.Models;
using Rating.ViewModels;
using System.Data.Entity;
using System.Net;

namespace Rating.Controllers
{
    public class RatingController : Controller
    {
        RatingEntities db = new RatingEntities();
        ActrateEntities ab = new ActrateEntities();
        vmrating rt = new vmrating();
        ActorEntities a = new ActorEntities();
        dropactEntities drate = new dropactEntities();
        AratingEntities ard = new AratingEntities();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reg(reg data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Session["UserId"] = data.UserId;
                    Session["Mobileno"] = data.Mobileno;
                    Session["Emailid"] = data.Emailid;
                    db.regs.Add(data);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Loginreg", "Rating");
                }
                else
                {
                    return View();
                }
               
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Loginreg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginreg(Login ldata)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
            var error = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            try
            {
                if (ModelState.IsValid)
                {
                    Session["Username"] = ldata.Username.ToString();
                    db.Logins.Add(ldata);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Login", "Rating");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login ldata)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                var error = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                if (ModelState.IsValid)
                {
                    var dt = db.Logins.Where(a => a.Username.Equals(ldata.Username) && a.Password.Equals(ldata.Password)).FirstOrDefault();
                    if (dt != null)
                    {
                        Session["Username"] = dt.Username.ToString();
                        return RedirectToAction("Index");
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
        public ActionResult ac()
        {
            var items = ard.Anamevs.ToList();
            if (items != null)
            {
                ViewBag.data = items;
                //Session["items"] = items;
            }
            List<Arating> actr = ard.Aratings.ToList();
            var order = from s in ard.Aratings select s;
            order = order.OrderByDescending(s => s.Arate);
            actr = order.ToList();
            var CustomerViewModel = new vmrating
            {
                ra = actr

            };
            return View(CustomerViewModel);
        }
        public ActionResult act(string Actorname, string star)
        {
            int id = Convert.ToInt32(Actorname);
            int rat = Convert.ToInt32(star);
            ModelState.Clear();
            var b = ard.Aratings.Where(a => a.RId.Equals(id)).FirstOrDefault();
           
            // ard.Aratings.Add(b); 
            // ard.SaveChanges();
            ModelState.Clear();
            if (b != null)
            {
                b.Arate = (b.Arate + rat);
                ard.Entry(b).State = EntityState.Modified;
                ard.SaveChanges();
            }
            var order = from s in ard.Aratings select s;
            order = order.OrderByDescending(s => s.Arate);
             //return View(order.ToList());
            //Session["rate"] = b.Arate;
            //return RedirectToAction("edit", "Rating", new { id = id });
            return RedirectToAction("ac");
        }
        public ActionResult edit(int id)
        {
            var Studentdata = ard.Aratings.Where(x => x.RId == id).FirstOrDefault();
            if (Studentdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Studentdata);
            }
            return View();
            //return View(id);
        }
        [HttpPost]
        public ActionResult edit(Arating obj)
        {
            try
            {
                Int32 StudentId = (int)TempData["StudentId"];
                var StudentData = ard.Aratings.Where(x => x.RId == StudentId).FirstOrDefault();
                if (StudentData != null)
                {
                    StudentData.Aname = obj.Aname;
                    StudentData.Arate = obj.Arate;
                    ard.Entry(StudentData).State = EntityState.Modified;
                    ard.SaveChanges();
                }
                return RedirectToAction("det");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Rate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Rate(Actrate r)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    ab.Actrates.Add(r);
                    ab.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Rating");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult result()
        {
            var items = a.actnameviews.ToList();
            if (items != null)
            {
                ViewBag.data = items;
                //Session["items"] = items;
            }
            List<Actrate> actr = ab.Actrates.ToList();
            return View();
        }
        public ActionResult detail(int id)
        {
            var Studentdata = ard.Aratings.Where(x => x.RId == id).FirstOrDefault();
            if (Studentdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Studentdata);
            }
            return View();
        }
        [HttpPost]
        public ActionResult detail(Arating id)
        {
            var Studentdata = ard.Aratings.Where(x => x.RId == id.RId).FirstOrDefault();
            if (Studentdata != null)
            {
                TempData["StudentID"] = id;
                TempData.Keep();
                return View(Studentdata);
            }
            return View();
           // Session["id"] = id;
            //return View("detail",id);
        }
        public ActionResult detailname(Arating a)
        {
           /* int id = 0;
            try
            {
                var acname = ard.Aratings.Where(x => x.Aname == name.Aname).FirstOrDefault();
                if(acname!=null)
                {
                    id = acname.RId;
                    return RedirectToAction("detail","Rating",new { id = id });
                }
                else
                {
                    return RedirectToAction("detail", "Rating", new { id = 0 });
                }
            }
            catch
            {*/
                return View();
           // }
          
        }
        public ActionResult detailrate(string Arate)
        {
            int id = 0;
            int r = Convert.ToInt32(Arate);
            try
            {
                var acrate = ard.Aratings.Where(x => x.Arate == r).FirstOrDefault();
                if (acrate != null)
                {
                    id = acrate.RId;
                    return RedirectToAction("detail", "Rating", new { id = id });
                }
                else
                {
                    return RedirectToAction("detail", "Rating", new { id = 0 });
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult det()
        {
            return View(ard.Aratings.ToList());
        }
        public ActionResult delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arating rd = ard.Aratings.Find(id);
            if (rd == null)
            {
                return HttpNotFound();
            }
            return View(rd);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult delete(int id)
        {
            Arating rd= ard.Aratings.Find(id);
            ard.Aratings.Remove(rd);
            ard.SaveChanges();
            return RedirectToAction("ac");
        }
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(Arating obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ard.Aratings.Add(obj);
                    ard.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("ac", "Rating");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}