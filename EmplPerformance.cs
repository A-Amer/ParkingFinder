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
    public partial class EmplPerformance : Form
    {
        Controller controllerObj;
        int spotid;
        public EmplPerformance(int sid)
        {
            InitializeComponent();
            chart1.Hide();
            button2.Hide();
            controllerObj = new Controller();
            spotid = sid;
            DataTable dt = controllerObj.SelectEmpNameSSN(sid);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "EName";
            comboBox1.ValueMember = "Employee_ID";
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = controllerObj.Performance(Convert.ToInt16(comboBox1.SelectedValue));
            chart1.DataSource = reader;
            chart1.Series[0].YValueMembers = "Monthly_Worked_Hours";
            chart1.Series[1].YValueMembers = "Average_Worked";
            chart1.DataBind();
            chart1.Show();
            button2.Show();
            comboBox1.Hide();
            button1.Hide();
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Hide();
            button2.Hide();
            comboBox1.Show();
            button1.Show();

        }

        private void EmplPerformance_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
