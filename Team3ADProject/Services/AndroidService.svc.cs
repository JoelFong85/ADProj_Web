﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;
using Team3ADProject.Model;
using Team3ADProject.Code;

namespace Team3ADProject.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AndroidService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AndroidService.svc or AndroidService.svc.cs at the Solution Explorer and start debugging.
    public class AndroidService : IAndroidService
    {
        // Template for working with Android services
        public string Hello(string token)
        {
            // If token is valid, do stuff
            if (AuthenticateToken(token))
            {
                return "hello!";
            }

            // If token is invalid, return null
            else
            {
                return null;
            }
        }

        /* Token methods ===========================*/


        // Authenticates a token
        // Returns true if token exists in employee table
        // Returns false if token doesn't exist in employee table
        protected bool AuthenticateToken(String token)
        {
            var context = new LogicUniversityEntities();
            var query = from x in context.employees where x.token == token select x;

            if (query.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Generates a token.
        // This token is unique, and contains the time created in the token itself.
        // To get the time created of the token, use the GetTokenCreation time method.
        protected string GenerateToken()
        {
            string key = Guid.NewGuid().ToString();
            string token = key;

            return token;
        }


        /* Service methods =========================================*/

        // Fetches an employee by using a token.
        public WCF_Employee GetEmployeeByToken(String token)
        {
            if (AuthenticateToken(token))
            {
                var context = new LogicUniversityEntities();
                var query = from x in context.employees where x.token == token select x;

                // If there exists the token for a user, create a wcf employee and return it
                if (query.Count() != 0)
                {
                    var first = query.First();
                    String role = null;

                    role = Roles.GetRolesForUser(first.user_id).FirstOrDefault();

                    return new WCF_Employee(first.employee_id, first.employee_name, first.email_id, first.user_id, first.department_id, first.supervisor_id, first.token, role);
                }

                else
                {
                    return null;
                }
            }
            return null;
        }

        // Takes username and password in
        // Returns a token and employee data if there is one for the user, null if there is none.
        public WCF_Employee Login(string username, string password)
        {
            WCF_Employee wcfEmployee = null;

            // If login succeeds, fetch the token, otherwise, return null
            // Validate username and password
            if (Membership.ValidateUser(username, password))
            {
                // Fetch or generate token
                var context = new LogicUniversityEntities();
                var query = from x in context.employees where x.user_id == username select x;
                var result = query.ToList();

                if (query.Any())
                {
                    // Generate a token for the resulting employee.
                    String token = GenerateToken();

                    // Store token in database
                    var first = result.First();
                    first.token = token;
                    System.Diagnostics.Debug.WriteLine(context.SaveChanges());

                    // Pass the token to the service consumer
                    wcfEmployee = new WCF_Employee(first.employee_id, first.employee_name, first.email_id, username, first.department_id, first.supervisor_id, token, Roles.GetRolesForUser(username).FirstOrDefault());
                }
            }

            // Return the token to user
            return wcfEmployee;
        }

        // Query with the token, and set it to null
        public string Logout(string token)
        {
            var context = new LogicUniversityEntities();
            var query = from x in context.employees where x.token == token select x;

            var result = query.First();
            result.token = null;

            context.SaveChanges();

            return "done";
        }



        //JOEL START

        //CollectionList
        public List<WCF_CollectionItem> getCollectionList()
        {
            List<WCF_CollectionItem> wcfList = new List<WCF_CollectionItem>();

            var result = BusinessLogic.GetCollectionList();

            foreach (var i in result)
            {
                wcfList.Add(new WCF_CollectionItem(i.item_number.Trim(), i.description.Trim(), (int)i.quantity_ordered, i.current_quantity, i.unit_of_measurement.Trim()));
            }

            return wcfList;
        }

        //CollectionList
        public void SortCollectedGoods(WCF_CollectionItem ci)
        {
            List<CollectionListItem> allDptCollectionList = new List<CollectionListItem>();
            allDptCollectionList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));

            BusinessLogic.SortCollectedGoods(allDptCollectionList);
        }

        //CollectionList
        public void DeductFromInventory(WCF_CollectionItem ci)
        {
            List<CollectionListItem> allDptCollectionList = new List<CollectionListItem>();
            allDptCollectionList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));

            BusinessLogic.DeductFromInventory(allDptCollectionList);
        }



        //Disbursement Sorting
        public List<WCF_DepartmentList> DisplayListofDepartmentsForCollection()
        {
            List<WCF_DepartmentList> wcfList = new List<WCF_DepartmentList>();
            var result = BusinessLogic.DisplayListofDepartmentsForCollection();

            foreach (var i in result)
            {
                wcfList.Add(new WCF_DepartmentList(i.ToString().Trim()));
            }
            return wcfList;
        }

        //Disbursement Sorting
        public string GetDptIdFromDptName(string dptName)
        {
            string dptID;
            return dptID = BusinessLogic.GetDptIdFromDptName(dptName.Trim()).Trim();
        }

        //Disbursement Sorting
        public List<WCF_SortingItem> GetSortingListByDepartment(string dpt_Id)
        {
            List<WCF_SortingItem> wcfList = new List<WCF_SortingItem>();
            var result = BusinessLogic.GetSortingListByDepartment(dpt_Id);

            foreach (var i in result)
            {
                wcfList.Add(new WCF_SortingItem(i.item_number.Trim(), i.description.Trim(), (int)i.required_qty, (int)i.supply_qty, (int)i.item_pending_quantity));
            }

            return wcfList;
        }

        //Disbursement Sorting
        public int GetPlaceIdFromDptId(string dptId)
        {
            int placeId;
            return placeId = BusinessLogic.GetPlaceIdFromDptId(dptId);
        }

        //Disbursement Sorting
        public void InsertCollectionDetailsRow(WCF_CollectionDetail cd)
        {
            BusinessLogic.InsertCollectionDetailsRow(cd.PlaceId, DateTime.Parse(cd.CollectionDate), cd.DepartmentId);
        }

        //Disbursement Sorting
        public void InsertDisbursementListROId(string dptId)
        {
            BusinessLogic.InsertDisbursementListROId(dptId);
        }

        //ViewRO
        public List<WCF_CollectionItem> GetRODetailsByROId(string roId)
        {
            List<WCF_CollectionItem> wcfList = new List<WCF_CollectionItem>();

            var result = BusinessLogic.GetRODetailsByROId(roId);
            foreach (var i in result)
            {
                wcfList.Add(new WCF_CollectionItem(i.requisition_id.Trim(), i.item_number.Trim(), i.description.Trim(), i.unit_of_measurement.Trim(), (int)i.item_requisition_quantity, (int)i.current_quantity, (int)i.item_pending_quantity));
            }

            return wcfList;
        }

        //ViewRO
        public void SpecialRequestReadyUpdatesCDRDD(WCF_CollectionDetail cd)
        {
            BusinessLogic.SpecialRequestReadyUpdatesCDRDD(cd.PlaceId, DateTime.Parse(cd.CollectionDate), cd.RoId.Trim(), cd.DepartmentId.Trim());
        }

        //ViewRO
        public void ViewROSpecialRequestUpdateRODTable(WCF_CollectionItem ci)
        {
            List<CollectionListItem> clList = new List<CollectionListItem>();
            clList.Add(new CollectionListItem(ci.ItemNumber.Trim(), ci.Description.Trim(), ci.UnitOfMeasurement.Trim(), ci.QuantityOrdered, ci.CurrentInventoryQty, ci.CollectedQty));
            string roid = ci.RequisitionId.Trim();

            BusinessLogic.ViewROSpecialRequestUpdateRODTable(clList, roid);

        }


        //JOEL END



        //Tharrani - start
        //return active inventory list
        public List<WCF_Inventory> GetActiveInventory(string token)
        {
            //if (AuthenticateToken(token))
            //{
            List<inventory> i = BusinessLogic.GetActiveInventory();
            List<WCF_Inventory> list = new List<WCF_Inventory>();
            foreach (inventory x in i)
            {
                list.Add(new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim()));
            }
            return list;
            //}
            //else
            //{
            //   return null;
            //}
        }

        //return inventory matching search criteria
        public List<WCF_Inventory> SearchInventory(string token, string search)
        {
            //if (AuthenticateToken(token))
            //{
            List<WCF_Inventory> list = new List<WCF_Inventory>();
            List<inventory> i = BusinessLogic.SearchActiveInventory(search);
            foreach (inventory x in i)
            {
                list.Add(new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim()));
            }
            return list;
            //}
            //else
            //{
            //  return null;
            // }
        }

        public WCF_Inventory GetSelectedInventory(string token, string id)
        {
            //if (AuthenticateToken(token))
            //{
            inventory x = BusinessLogic.GetInventoryById(id);
            return new WCF_Inventory(x.item_number.Trim(), x.description.Trim(), x.category.Trim(), x.unit_of_measurement.Trim(), x.current_quantity.ToString(), x.reorder_level.ToString(), x.reorder_quantity.ToString(), x.item_bin.Trim(), x.item_status.Trim());
            //}
            //else
            //{
            //  return null;
            // }
        }

        //Add new requisition order
        public string AddNewRequest()
        {
            //if (AuthenticateToken(token))
            //{
            //WCF_Employee emp = GetEmployeeByToken(token);
            int emp_id = 16; //Convert.ToInt32(emp.EmployeeId);
            string Depid = "ENGL"; //emp.DepartmentId;
            DateTime d = DateTime.Now.Date;
            unique_id u = BusinessLogic.getlastrequestid(Depid);
            int i = (int)u.req_id + 1;
            string id = Depid + "/" + DateTime.Now.Year.ToString() + "/" + i;
            BusinessLogic.AddNewRequisitionOrder(id, emp_id, d);
            BusinessLogic.updatelastrequestid(Depid, i);
            return id;
            // }

            //else
            //   return null;
        }

        //Add new requisition order detail
        public void AddNewRequestDetail(WCF_ReqCart r)
        {
            int q = r.q;
            string id = r.Id.Replace(@"\", "");
            inventory inv = BusinessLogic.GetInventoryById(r.getI.Trim()); ;
            cart c = new cart(inv, q);
            BusinessLogic.AddRequisitionOrderDetail(c, id);
        }

        public WCF_Inventory GetInventoryByItemNumber(string ItemNumber)
        {

            inventory inv = BusinessLogic.GetInventoryById(ItemNumber);
            return new WCF_Inventory(inv.item_number, inv.description, inv.category, inv.unit_of_measurement, inv.current_quantity.ToString(), inv.reorder_level.ToString(), inv.requisition_order_detail.ToString(), inv.item_bin, inv.item_status);

        }

        //Tharrani – End


    }
}


