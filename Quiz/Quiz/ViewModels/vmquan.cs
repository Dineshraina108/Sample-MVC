using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.ViewModels
{
    public class vmquan
    {
        public class Questionvm
        {
            public int ID { set; get; }
            public string QuestionText { set; get; }
            public List<Answervm> Answers { set; get; }
            public string SelectedAnswer { set; get; }
            public Questionvm()
            {
                Answers = new List<Answervm>();
            }
        }
        public class Answervm
        {
            public int ID { set; get; }
            public string AnswerText { set; get; }
        }
        public class Evaluation
        {
            public List<Questionvm> Questions { set; get; }
            public Evaluation()
            {
                Questions = new List<Questionvm>();
            }
        }
    }
}