//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Answer
    {
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Display(Name = "Enter option 1")]
        public int AnsId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ans1 { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Display(Name = "Enter option 2")]
        public string ans2 { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Display(Name = "Enter option 3")]
        public string ans3 { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Display(Name = "Enter option 4")]
        public string ans4 { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Display(Name = "Enter Correct option")]
        public string Correctans { get; set; }
    }
}
