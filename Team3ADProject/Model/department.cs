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
    
    public partial class department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public department()
        {
            this.budgets = new HashSet<budget>();
            this.department_rep = new HashSet<department_rep>();
            this.collections = new HashSet<collection>();
        }
    
        public string department_id { get; set; }
        public int head_id { get; set; }
        public Nullable<int> temp_head_id { get; set; }
        public int department_pin { get; set; }
        public string department_name { get; set; }
        public string contact_name { get; set; }
        public int phone_number { get; set; }
        public int fax_number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<budget> budgets { get; set; }
        public virtual employee employee { get; set; }
        public virtual employee employee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department_rep> department_rep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<collection> collections { get; set; }
    }
}
