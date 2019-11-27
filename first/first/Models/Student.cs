using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace first.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string subject { get; set; }
    }
    public enum subject
    {
        Tamil,
        English,
        Maths,
        Science,
        Socialscience
    }
}