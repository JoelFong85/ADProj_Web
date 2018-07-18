﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LogicUniversityEntities : DbContext
    {
        public LogicUniversityEntities()
            : base("name=LogicUniversityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adjustment> adjustments { get; set; }
        public virtual DbSet<budget> budgets { get; set; }
        public virtual DbSet<collection> collections { get; set; }
        public virtual DbSet<collection_detail> collection_detail { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<department_rep> department_rep { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<purchase_order> purchase_order { get; set; }
        public virtual DbSet<purchase_order_detail> purchase_order_detail { get; set; }
        public virtual DbSet<requisition_disbursement_detail> requisition_disbursement_detail { get; set; }
        public virtual DbSet<requisition_order> requisition_order { get; set; }
        public virtual DbSet<requisition_order_detail> requisition_order_detail { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<supplier_itemdetail> supplier_itemdetail { get; set; }
    

        public virtual ObjectResult<spViewCollectionList_Result> spViewCollectionList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewCollectionList_Result>("spViewCollectionList");
        }
    
        public virtual ObjectResult<Nullable<int>> spGetDepartmentPin(string departmentname)
        {
            var departmentnameParameter = departmentname != null ?
                new ObjectParameter("departmentname", departmentname) :
                new ObjectParameter("departmentname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetDepartmentPin", departmentnameParameter);
        }

        public virtual ObjectResult<spAcknowledgeDistributionList_Result> spAcknowledgeDistributionList(Nullable<int> disbursementlistid)
        {
            var disbursementlistidParameter = disbursementlistid.HasValue ?
                new ObjectParameter("disbursementlistid", disbursementlistid) :
                new ObjectParameter("disbursementlistid", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAcknowledgeDistributionList_Result>("spAcknowledgeDistributionList", disbursementlistidParameter);
        }

        public virtual ObjectResult<getPurchaseQuantityByItemCategory_Result> getPurchaseQuantityByItemCategory(Nullable<int> monthsBack)
        {
            var monthsBackParameter = monthsBack.HasValue ?
                new ObjectParameter("MonthsBack", monthsBack) :
                new ObjectParameter("MonthsBack", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPurchaseQuantityByItemCategory_Result>("getPurchaseQuantityByItemCategory", monthsBackParameter);
        }
    
        public virtual ObjectResult<getRequisitionQuantityByDepartment_Result> getRequisitionQuantityByDepartment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getRequisitionQuantityByDepartment_Result>("getRequisitionQuantityByDepartment");

        }
    }
}
