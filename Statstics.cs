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
    public partial class Statstics : Form
    {

        Controller controllerObj;
        int sid;
        public Statstics(int id,int spotid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MySqlDataReader reader = controllerObj.Performance(id);
            chart1.DataSource = reader;
            chart1.Series[0].YValueMembers = "Monthly_Worked_Hours";
            chart1.Series[1].YValueMembers = "Average_Worked";
            chart1.DataBind();
            reader.Close();
            int[] s = new int[2];
            s[0] = controllerObj.Occupied(spotid);
            s[1] = 100 - s[0];
            chart2.Series[0].Points.DataBindY(s);
            chart2.Series[0].Points[1].LegendText = "Unoccupied%";
            chart2.Series[0].Points[0].LegendText = "Occupied%";
            reader.Close();
            sid = spotid;
            if (Login.type == "employee") {
                chart2.Hide();
                button1.Hide();
                button1.Enabled = false;
                button2.Hide();
                button2.Enabled = false;
            }
        }

        private void Statstics_Load(object sender, EventArgs e)
        {

            
        }

        private void Statstics_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1 f= new Form1(sid);
           f.Show();
           this.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EmplPerformance(sid).Show();
            this.Close();
        }

    }
}
