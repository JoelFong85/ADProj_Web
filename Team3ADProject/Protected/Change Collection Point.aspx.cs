﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team3ADProject.Code;

//sruthi
namespace Team3ADProject.Protected
{
    public partial class Change_Collection_Point : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Visible = false;
				//to get the collection locations
                DropDownList1.DataSource = BusinessLogic.GetCollection();
                DropDownList1.DataTextField = "collection_place";
                DropDownList1.DataValueField = "place_id";
                DropDownList1.DataBind();
            }
            int employeeid = Convert.ToInt32(Session["Employee"]);
            string user = BusinessLogic.GetUserID(employeeid);
            string dept = BusinessLogic.getdepartment(user);
			//to get department history of the collection
            var q = BusinessLogic.getdepartmentcollection(dept).ToList();
            GridView1.DataSource = q;
            GridView1.DataBind();
        }

		//code for change collection
        protected void Button1_Click(object sender, EventArgs e)
        {
            int employeeid = Convert.ToInt32(Session["Employee"]);
            string user = BusinessLogic.GetUserID(employeeid);
            string dept = BusinessLogic.getdepartment(user);//to get the department
            int i = Convert.ToInt32(DropDownList1.SelectedValue);
			//update the collection location for the department
            BusinessLogic.updatecollectionlocation(dept, i);
            Label2.Text = "Location is changed to " + DropDownList1.SelectedItem.ToString();
            Label2.Visible = true;

        }
    }
}