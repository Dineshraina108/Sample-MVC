using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using first.Models;

namespace first.Controllers
{
    public class secondController : Controller
    {
        // GET: second
        IList<Student> studentList = new List<Student>() {
                    new Student(){ StudentId=1, StudentName="John", Age = 18 },
                    new Student(){ StudentId=2, StudentName="Steve", Age = 21 },
                    new Student(){ StudentId=3, StudentName="Bill", Age = 25 },
                    new Student(){ StudentId=4, StudentName="Ram", Age = 20 },
                    new Student(){ StudentId=5, StudentName="Ron", Age = 31 },
                    new Student(){ StudentId=6, StudentName="Chris", Age = 17 },
                    new Student(){ StudentId=7, StudentName="Rob", Age = 19 }
                };
        public ActionResult Index()
        {
            return View(studentList);
        }
        public ActionResult userreg()
        {
            dineshrainashopEntities db = new dineshrainashopEntities();
            //return View(from userreg in db.userregs.Take(10)
            //           select userreg);
            return View(db.userregs.ToList());
        }
        public ActionResult Edit(int Id=2)
        {
            //Get the student from studentList sample collection for demo purpose.
            //Get the student from the database in the real application
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            
            //write code to update student 
            var id = std.StudentId;
            var name = std.StudentName;
            var age = std.Age;

            return RedirectToAction("Index");
        }
        public ActionResult studcreate()
        {
            return View();
        }
    }
}