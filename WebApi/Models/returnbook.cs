//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class returnbook
    {
        public int Id { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Book { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<int> DaysElapse { get; set; }
        public Nullable<int> Fine { get; set; }
    }
}
