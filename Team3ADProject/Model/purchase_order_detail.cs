//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team3ADProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class purchase_order_detail
    {
        public int purchase_order_number { get; set; }
        public string item_number { get; set; }
        public int item_purchase_order_quantity { get; set; }
        public int item_accept_quantity { get; set; }
        public double item_purchase_order_price { get; set; }
        public string purchase_order_item_remark { get; set; }
        public string item_purchase_order_status { get; set; }
        public Nullable<System.DateTime> item_accept_date { get; set; }
    
        public virtual inventory inventory { get; set; }
        public virtual purchase_order purchase_order { get; set; }
    }
}
