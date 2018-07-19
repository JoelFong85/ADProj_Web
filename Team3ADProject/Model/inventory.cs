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
    
    public partial class inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inventory()
        {
            this.adjustments = new HashSet<adjustment>();
            this.requisition_order_detail = new HashSet<requisition_order_detail>();
            this.supplier_itemdetail = new HashSet<supplier_itemdetail>();
            this.purchase_order_detail = new HashSet<purchase_order_detail>();
        }
    
        public string item_number { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string unit_of_measurement { get; set; }
        public int current_quantity { get; set; }
        public int reorder_level { get; set; }
        public int reorder_quantity { get; set; }
        public string item_bin { get; set; }
        public string item_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<adjustment> adjustments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<requisition_order_detail> requisition_order_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supplier_itemdetail> supplier_itemdetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_order_detail> purchase_order_detail { get; set; }
    }
}
