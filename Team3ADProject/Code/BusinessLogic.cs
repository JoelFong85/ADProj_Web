﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Team3ADProject.Model;

namespace Team3ADProject.Code
{
    
    public class BusinessLogic
    {
        static LogicUniversityEntities context = new LogicUniversityEntities();

        public static List<spViewCollectionList_Result> ViewCollectionList()
        {
            List<spViewCollectionList_Result> list = new List<spViewCollectionList_Result>();
            return list = context.spViewCollectionList().ToList();
        }

        public static int GetDepartmentPin(string departmentname)
        {
            return (int)context.spGetDepartmentPin(departmentname).ToList().Single();
        }

        public static List<spAcknowledgeDistributionList_Result> ViewAcknowledgementList(int disbursement_list_id)
        {
            List<spAcknowledgeDistributionList_Result> list = new List<spAcknowledgeDistributionList_Result>();
            return list = context.spAcknowledgeDistributionList(disbursement_list_id).ToList();
        }
        //List all adjustment form
        public static List<adjustment> GetAdjustment()
        {
            return context.adjustments.Where(x => x.adjustment_status == "pending" && x.adjustment_price <= 250).ToList();
        }
        //Update adjustment form
        public static void Updateadj(int id, string comment)
        {
            adjustment adj = context.adjustments.Where(x => x.adjustment_id == id).First<adjustment>();
            adj.adjustment_status = "Approved";
            adj.manager_remark = comment;
            context.SaveChanges();
        }
        public static void rejectAdj(int id, string comment)
        {
            adjustment adj = context.adjustments.Where(x => x.adjustment_id == id).First<adjustment>();
            adj.adjustment_status = "Rejected";
            adj.manager_remark = comment;
            context.SaveChanges();
        }
        public static List<adjustment> Search(DateTime date)
        {
            return context.adjustments.Where(x => x.adjustment_date == date).ToList<adjustment>();
        }       
        //List purchase order
        public static List<purchase_order> GetPurchaseOrders()
        {
            return context.purchase_order.OrderBy(x=>x.suppler_id).Where(x => x.purchase_order_status == "awaiting approval").ToList();
        }
        public static inventory GetInventory(string id)
        {
            return context.inventories.Where(i => i.item_number == id).ToList<inventory>()[0];
        }
        public static List<supplier_itemdetail> GetSupplier(string id)
        {
            return context.supplier_itemdetail.Where(i => i.item_number == id).OrderBy(i => i.priority).ToList<supplier_itemdetail>();
        }
        public static List<inventory> GetActiveInventories()
        {
            return context.inventories.Where(x => x.item_status.ToLower() == "active").ToList();
        }
        public static List<inventory> GetAllInventories()
        {
            return context.inventories.ToList();
        }
        public static List<supplier> GetActiveSuppliers()
        {
            return context.suppliers.Distinct().Where(s => s.supplier_status.ToLower() == "active").ToList();
        }
        public static List<string> GetCategories()
        {
            return context.inventories.OrderBy(x=>x.category).Select(x=> x.category).Distinct().ToList();
        }
        public static int ReturnPendingPOqtyByStatus(inventory item, string status)
        {
            var q = context.purchase_order_detail.Where(x => x.item_purchase_order_status.ToLower().Trim() == "pending" 
            && x.purchase_order.purchase_order_status.ToLower().Trim() == status);
            int qty = 0;
            foreach(var a in q)
            {
                if (a.item_number.ToLower().Trim().Equals(item.item_number.ToLower().Trim()))
                {
                    qty += a.item_purchase_order_quantity;
                }
            }
            return qty; 
        }
        public static int ReturnPendingAdjustmentQty(inventory item)
        {
            var q = context.adjustments.Where(x=>x.adjustment_status.ToLower().Trim() == "pending");
            int qty = 0;
            foreach(var a in q)
            {
                if (a.item_number.ToLower().Trim().Equals(item.item_number.ToLower().Trim()))
                {
                    qty += a.adjustment_quantity;
                }
            }
            return qty;
        }
        public static List<inventory> GetInventoriesByCategory(string category)
        {
            return context.inventories.Where(x => x.category.Trim().ToLower() == category.Trim().ToLower()).ToList();
        }
    }
}