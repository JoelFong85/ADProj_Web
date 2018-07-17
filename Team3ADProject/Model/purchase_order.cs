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
    
    public partial class purchase_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchase_order()
        {
            this.purchase_order_detail = new HashSet<purchase_order_detail>();
        }
    
        public int purchase_order_number { get; set; }
        public System.DateTime purchase_order_required_date { get; set; }
        public System.DateTime purchase_order_date { get; set; }
        public string suppler_id { get; set; }
        public int employee_id { get; set; }
        public string purchase_order_status { get; set; }
    
        public virtual employee employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_order_detail> purchase_order_detail { get; set; }
        public virtual supplier supplier { get; set; }
    }
}
