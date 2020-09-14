using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models
{
    public class mvcCategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(4)]
        public string Status { get; set; }
    }
}