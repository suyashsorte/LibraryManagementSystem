using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace LibraryMvc.Models
{

    public class mvcBookModel
    {
        public int Id { get; set; }
        [Display(Name = "Book")]
        public string BookName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> PublisherId { get; set; }
        public string Contents { get; set; }
        public Nullable<int> Pages { get; set; }
        public string Edition { get; set; }

        public virtual author author { get; set; }
        public virtual category category { get; set; }
        public virtual publisher publisher { get; set; }
    }
}