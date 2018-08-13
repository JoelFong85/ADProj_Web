using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Team3ADProject.Model;

namespace Team3ADProject.Protected
{
    public partial class ChartForStoreManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var context = new LogicUniversityEntities();
                Departments.DataSource = context.departments.Where(x => x.department_id != "STOR").Select(x => new { x.department_name, x.department_id }).ToList();
                Departments.DataTextField = "department_name";
                Departments.DataValueField = "department_id";
                Departments.DataBind();
                foreach (ListItem chkitem in Departments.Items)
                {
                    chkitem.Selected = true;
                }

                ChangeROGraph();
            }
            
        }

        protected void ChangeROGraph()
        {
            List<string> departmentcode = new List<string>();
            var context = new LogicUniversityEntities();

            var result = context.requisition_order.Where(x => (x.requisition_status == "Approved")).ToList();
            foreach (requisition_order dept in result)
            {
                departmentcode.Add(dept.requisition_id.Substring(0, 4));
            }
            var query = departmentcode.GroupBy(s => s).Select(g => new { Dept = g.Key, Count = g.Count() });


            Series series = getROBasedDepartmentAndTime.Series["Series1"];

            foreach (var r in query)
            {
                series.Points.AddXY(r.Dept, r.Count);
            }
        }

        public DateTime fromDate, toDate;
        public List<string> dept;
        protected void ChangeROGraph(object sender, EventArgs e) 
        {

           if (DateTime.TryParse(From.Text, out fromDate)&& DateTime.TryParse(To.Text, out toDate))
           {
                if (DateTime.Compare(fromDate, toDate) <= 0)
                {
                    string selectedItem = String.Join(" ", Departments.Items.OfType<ListItem>().Where(r => r.Selected).Select(r => r.Value));


                    LoadROGraph(selectedItem, fromDate, toDate);
                }
                else
                {
                    ErrorMSg.Text = "please choose beginning date smaller";
                }

            }
            else
            {
               ErrorMSg.Text = "Please re-select the dates";
            }
           
        }

        protected void LoadROGraph(string selectedDepartment,DateTime From, DateTime To)
        {
            List<string> departmentcode = new List<string>();
            var context = new LogicUniversityEntities();

            var result = context.requisition_order.Where(x => (x.requisition_status == "Approved")&&(x.requisition_date >= From)&&(x.requisition_date<=To)).ToList();
            foreach (requisition_order dept in result)
            {
                departmentcode.Add(dept.requisition_id.Substring(0, 4));
            }
            var query = departmentcode.GroupBy(s => s).Select(g => new { Dept = g.Key, Count = g.Count() });
            Series series = getROBasedDepartmentAndTime.Series["Series1"];

            Departments.ClearSelection();

            foreach (var r in query)
            { 
                if ((r.Count !=0)&&(selectedDepartment.Contains(r.Dept)))
                {
                    Departments.Items.FindByValue(r.Dept).Selected = true;
                    series.Points.AddXY(r.Dept, r.Count);
                }

            }

            if (getROBasedDepartmentAndTime != null)
            {
                ErrorMSg.Visible = false;
            }
            else
            {
                ErrorMSg.Text = "Please make other selection";

            }



        }
    }
}