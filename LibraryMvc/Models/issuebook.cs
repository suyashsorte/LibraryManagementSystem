//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class issuebook
    {
        public int Id { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string BookName { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    }
}
