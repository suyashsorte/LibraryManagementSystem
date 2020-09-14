using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models
{
    public class mvcMemberModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255)]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(10)]
        public string PhoneNo { get; set; }
    }
}