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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> PublisherId { get; set; }
        public string Contents { get; set; }
        public Nullable<int> Pages { get; set; }
        public string Edition { get; set; }

        [JsonIgnore]
        public virtual author author { get; set; }
        [JsonIgnore]
        public virtual category category { get; set; }
        [JsonIgnore]
        public virtual publisher publisher { get; set; }
    }
}
