using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace class_list
{
   

    public partial class class_list : System.Web.UI.Page
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int salary { get; set; }
        }

        List<Employee> emplist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emplist = new List<Employee>();
                Session["emplist"] = emplist;
            }
            Page.UnobtrusiveValidationMode=UnobtrusiveValidationMode.None;
        }

        protected void Btn_sub_Click(object sender, EventArgs e)
        {
            emplist = (List<Employee>)Session["emplist"];
            Employee emp=new Employee
            {
                ID = int.Parse(txtid.Text),
                Name = txtname.Text,
                salary=int.Parse(txtsalary.Text),
            };

            emplist.Add(emp);
            //var res=emplist.ToList(); for without where , show all data

            var result=emplist.Where(i => i.salary>30000).ToList();
            foreach (var i in result)
            {
                lstLabel.Text += "ID:" + i.ID + "Name:" + i.Name + "Salary:" + i.salary;
            }

        }
    }
}