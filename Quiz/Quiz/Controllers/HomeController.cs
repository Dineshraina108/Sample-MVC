using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Models;
using Quiz.ViewModels;

namespace Quiz.Controllers
{
    public class HomeController : Controller
    {
        QuestionEntities qb = new QuestionEntities();
        AnswerEntities ab = new AnswerEntities();
        ChoiceEntities ch = new ChoiceEntities();
        vmquan vm = new vmquan();
        public ActionResult Index()
        {
            List<Question> Book = qb.Questions.ToList();
            List<choice> Customer = ch.choices.ToList();
            //var Book = new List<Question>()
            //{
            //    new Question {QuestionId=1, Question1 = "Programming in C#"},
            //    new Question {QuestionId=2,Question1 = "Programming in C++"},
            //    new Question {QuestionId=3,Question1 = "Programming in Java"}
            //};

            //var Customer = new List<Answer>()
            //{
            //    new Answer {QuestionId=1,AnsId=1, ans1 = "Zain",ans2 = "Hassan",ans3= "Syed",ans4= "ram",Correctans="Zain"},
            //    new Answer {QuestionId=2,AnsId=2,ans1 = "Hassan",ans2 = "Zain",ans3= "Syed",ans4= "ram",Correctans="Zain"},
            //    new Answer {QuestionId=3,AnsId=3,ans1= "Syed",ans2 = "Hassan",ans3= "Zain",ans4= "ram",Correctans="Zain" }
            //};

            var CustomerViewModel = new sample
            {
                Books = Book,
                Customers = Customer
            };

            return View(CustomerViewModel);
          
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string option)
        {
           // ViewBag:Message = "Your contact page.";
           if(option=="apps")
            {
                return RedirectToAction("apps");
            }  
           else if (option == "tech")
            {
                return RedirectToAction("Technical");
            }
           else
            {
                return View();
            }
           
        }
        public ActionResult apps()
        {
            return View();
        }
        [HttpPost]
        public ActionResult apps(Question data)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    qb.Questions.Add(data);
                    qb.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("apps");
            }
        
        }
        public ActionResult Technical()
        {
            return View();
        }
        public ActionResult anscreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult anscreate(Answer data)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    ab.Answers.Add(data);
                    ab.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("apps");
            }

        }
        public ActionResult Quizpage1()
        {
            var evalVM = new Evaluation();

            //the below is hardcoded for DEMO. you may get the data from some  
            //other place and set the questions and answers

            var q1 = new quiz1vm { ID = 1, QuestionText = "What is your favourite language" };
            q1.Answers.Add(new answvm { ID = 12, AnswerText = "PHP" });
            q1.Answers.Add(new answvm { ID = 13, AnswerText = "ASP.NET" });
            q1.Answers.Add(new answvm { ID = 14, AnswerText = "Java" });
            evalVM.Questions.Add(q1);

            var q2 = new quiz1vm { ID = 2, QuestionText = "What is your favourite DB" };
            q2.Answers.Add(new answvm { ID = 16, AnswerText = "SQL Server" });
            q2.Answers.Add(new answvm { ID = 17, AnswerText = "MyQL" });
            q2.Answers.Add(new answvm { ID = 18, AnswerText = "Oracle" });
            evalVM.Questions.Add(q2);

            return View(evalVM);
        }
        [HttpPost]
        public ActionResult Quizpage1(Evaluation model)
        {
            if (ModelState.IsValid)
            {
                foreach (var q in model.Questions)
                {
                    var qId = q.ID;
                    var selectedAnswer = q.SelectedAnswer;
                    // Save the data 
                }
                return RedirectToAction("ThankYou"); //PRG Pattern
            }
            //to do : reload questions and answers
            return View(model);
        }
        public ActionResult Quizpage2()
        {
            List<Question> ql = qb.Questions.ToList();
            return View(ql);
        }
       
        public ActionResult Quizpage3()
        {
            List<Answer> al = ab.Answers.ToList();
            return View(al);
        }
        public ActionResult Quizpage4()
        {
            return View();
        }

    }
}