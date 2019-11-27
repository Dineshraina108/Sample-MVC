using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz.ViewModels;
using Quiz.Models;

namespace Quiz.ViewModels
{
    public class quiz1vm
    {
        public int ID { set; get; }
        public string QuestionText { set; get; }
        public List<answvm> Answers { set; get; }
        public string SelectedAnswer { set; get; }
        public quiz1vm()
        {
            Answers = new List<answvm>();
        }
    }
}