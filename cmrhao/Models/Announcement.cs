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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Announcement
    {
        public int AId { get; set; }
        [DisplayName("Announcement")]
        [Required(ErrorMessage = "This field is required.")]
        public string Announcement1 { get; set; }
        public Nullable<System.DateTime> ADate { get; set; }
        [DisplayName("Order")]
        [Required(ErrorMessage = "This field is required.")]
        public int aOrder { get; set; }
    }
}
