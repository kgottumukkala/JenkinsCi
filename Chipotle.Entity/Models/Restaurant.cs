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
    
    public partial class Restaurant
    {
        public Restaurant()
        {
            this.ItemStocks = new HashSet<ItemStock>();
            this.Orders = new HashSet<Order>();
        }
    
        public int RestaurantNo { get; set; }
        public string RestaurantName { get; set; }
        public string Market { get; set; }
        public string Region { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string MakeLineFaxNo { get; set; }
        public string EmailId { get; set; }
        public System.DateTime OpenedDate { get; set; }
        public Nullable<System.DateTime> RolloutDate { get; set; }
        public Nullable<int> CateringTier { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> Bracket { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual ICollection<ItemStock> ItemStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}