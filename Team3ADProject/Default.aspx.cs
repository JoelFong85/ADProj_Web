﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team3ADProject.Model;
using Team3ADProject.Code;
using System.Web.Security;

namespace Team3ADProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            // Setup the session variables
            Session["username"] = HttpContext.Current.User.Identity.Name;
            employee emp = BusinessLogic.GetEmployeeByUserID((string)Session["username"]);
            Session["Employee"] = emp.employee_id;
            Session["Department"] = emp.department_id.Trim();
            Session["role"] = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name).FirstOrDefault();
            department dep = BusinessLogic.GetDepartmenthead(emp.department_id.Trim());
            Session["Head_id"] = dep.head_id;
            Session["supervisor_id"] = emp.supervisor_id;

            // Redirect users to their dashboard
            Response.Redirect(ResolveUrl("~/Protected/Dashboard"));
        }
    }
}