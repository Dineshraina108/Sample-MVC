using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.ViewModels
{
    public class Evaluation
    {
        public List<quiz1vm> Questions { set; get; }
        public Evaluation()
        {
            Questions = new List<quiz1vm>();
        }
    }
}