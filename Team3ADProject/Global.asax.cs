﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Team3ADProject.Code;
using Team3ADProject.Model;

namespace Team3ADProject
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["RequestID"] = 25;
        }


        void Session_Start(object sender, EventArgs e)
        {

            // Tharrani start
            Session["username"] = "lina"; //System.Web.HttpContext.Current.User.Identity.Name;
            employee emp = BusinessLogic.GetEmployeeByUserID((string)Session["username"]);
            Session["Employee"] = emp.employee_id;
            Session["Department"] = emp.department_id;
            Session["role"] = "employee";//Roles.GetRolesForUser((string)Session["username"]);
            department dep = BusinessLogic.GetDepartmenthead((string)Session["Department"]);
            Session["Head_id"] = dep.head_id;
            Session["supervisor_id"] = emp.supervisor_id;
            // Tharrani end

            //alan--start
            Session["role"] = "11";


            //alan-> need to code this using in User is in role after IIS setup
            /*if (User.IsInRole("storemanager"))
            {
                Session["role"] = "storemanager";

            }
            else if (User.IsInRole("storesup"))
            {
                Session["role"] = "storesup";
            }*/
            //alan-- end

        }



    }
}