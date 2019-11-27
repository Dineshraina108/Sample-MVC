using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medlogin.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace medlogin.Controllers
{
    public class DoctorController : Controller
    {
        DoctorEntities db = new DoctorEntities();
        ComplaintEntities com = new ComplaintEntities();
        medallEntities med = new medallEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Doctorcreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Doctorcreate(Doctorlist dl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Doctorlists.Add(dl);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Doctorlist", "Doctor");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Doctorlist(string search, string text)
        {
            List<Doctorlist> List = db.Doctorlists.ToList();
            //return View(List);
            // Session["Doctorname"] = search;
            // return RedirectToAction("Complaint");
            if (search != "" && text != "")
            {
                ModelState.Clear();
                return View(db.Doctorlists.Where(x => x.Doctorname == search || search == null || x.Specialist == text || text == null).ToList());
            }
            else if(search!="")
            {
                ModelState.Clear();
                return View(db.Doctorlists.Where(x => x.Doctorname == search || search == null).ToList());
            }
            else if(text!="")
            {
                ModelState.Clear();
                return View(db.Doctorlists.Where(x => x.Specialist == text || text == null).ToList());
            }
            else             
            {
                return View(List);
            }
            //var names= db.Doctorlists.Where(x => x.Doctorname == search || search == null).ToList()
            // return Json(names, JsonRequestBehavior.AllowGet);
            //if (option == "Doctorname")
            //{
            //    Session["Doctorname"] = search;
            //    //return View(db.Doctorlists.Where(x => x.Doctorname == search || search == null).ToList());
            //    return RedirectToAction("Complaint");
            //}
            //else if (option == "Specialist")
            //{
            //    return View(db.Doctorlists.Where(x => x.Specialist == search || search == null).ToList());
            //}
            //else
            //{
            //    return View(List);
            //}
        }
        public ActionResult Complaint()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complaint(Patient p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    com.Patients.Add(p);
                    com.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Search(string term)
        {
            var names = db.Doctorlists.Where(p => p.Doctorname.Contains(term)).Select(p => p.Doctorname).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }
       /* public ActionResult spec()
        {
          //  List<Doctorlist> List = db.Doctorlists.ToList();
           // Session["Doctorname"] = search;
            //return View(List);
            return View();
        }*/

        [HttpGet]
        public ActionResult spec()
        {
            string constr = ConfigurationManager.ConnectionStrings["medicaldb"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("Select DoctorId,Specialist From Doctorlist", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.CityList = ToSelectList(_dt, "DoctorId", "Specialist");
            return View();
        }

        private dynamic ToSelectList(DataTable _dt, string v1, string v2)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[v2].ToString(),
                    Value = row[v1].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        [HttpPost]
        public ActionResult spec(Doctorlist _member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Doctorlists.Add(_member);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Doctorlist", "Doctor");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Studins()
        {
            return View();
        }
        public ActionResult Cancel()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Doctor");
        }
    }
}