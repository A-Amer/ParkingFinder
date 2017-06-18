using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Parking_Finder
{
    public partial class Employees : Form
    {
        Controller controllerObj;
        int spotid;
        public Employees(int id,int sid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            spotid = sid;
            DataTable dt = controllerObj.SelectEmpNameSSN(sid); 
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "EName";
            comboBox1.ValueMember = "Employee_ID"; 
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new InsertEmployee(spotid).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                new ErrorMessage().Show();
                return;
            } 
            int x = controllerObj.UpdateSalary(Convert.ToInt16(comboBox1.SelectedValue), Convert.ToInt32(textBox2.Text));
            if (x == 1)
            {
                new Done().Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           int y = 0;
           int x = controllerObj.DeleteAccount(Convert.ToInt16(comboBox1.SelectedValue));
           if (x == 1)
           {
               y = controllerObj.DeleteEmp(Convert.ToInt16(comboBox1.SelectedValue));
           }
           if (x == 1 && y == 1)
           {
               new Done().Show();
               
           }
           DataTable t = controllerObj.SelectEmpNameSSN(spotid);
           comboBox1.DataSource = t;
           comboBox1.DisplayMember = "EName";
           comboBox1.ValueMember = "Employee_ID"; 
        }

        private void Employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
