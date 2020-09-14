//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace LibraryMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Book")]
        public string BookName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> PublisherId { get; set; }
        public string Contents { get; set; }
        public Nullable<int> Pages { get; set; }
        public string Edition { get; set; }
    
        public virtual author author { get; set; }
        [Display(Name = "Category")]
        public virtual category category { get; set; }
        public virtual publisher publisher { get; set; }
    }
}