//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chipotle.Entity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginAudit
    {
        public int AuditId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> LoggedInOn { get; set; }
        public Nullable<System.DateTime> LoggedOutOn { get; set; }
        public long LogInStatus { get; set; }
        public string FailureDetails { get; set; }
    
        public virtual User User { get; set; }
    }
}