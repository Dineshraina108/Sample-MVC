//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace Mobileshop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Productname required")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Brand required")]
        public string Brand { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Model required")]
        public string Model { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price required")]
        public string Price { get; set; }
    }
}