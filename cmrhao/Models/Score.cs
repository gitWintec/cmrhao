//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cmrhao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public decimal Score1 { get; set; }
    
        public virtual User User { get; set; }
    }
}
