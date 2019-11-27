using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using first.Models;

namespace first.Controllers
{
    public class firstController : Controller
    {
        // GET: first
        public string Index()
        {
            return "this is my page";
        }
        public string Welcome(string name="dinesh", int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
        }
        public ActionResult Wel(string name="dinesh", int numTimes = 2)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
      
    }
}