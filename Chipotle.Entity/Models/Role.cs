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
    using Repository;
    using System;
    using System.Collections.Generic;

    using System.Runtime.Serialization;

    [DataContract]
    public partial class Role : EntityBase
    {
        public Role ()
        {
            this.Users = new HashSet<User>();
        }
        [DataMember]
        public int RoleId { get; set; }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsEnabled { get; set; }
        [DataMember]
        public Nullable<int> ModifiedBy { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public virtual ICollection<User> Users { get; set; }
    }
}