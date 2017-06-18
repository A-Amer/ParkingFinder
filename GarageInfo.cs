using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parking_Finder
{
    public partial class GarageInfo : Form
    {
        Controller controllerobj;
        int spotid;
        public GarageInfo(int S_ID)
        {
            InitializeComponent();
            controllerobj = new Controller();
            spotid = S_ID;
            decimal x=controllerobj.getRatingsavrg(S_ID);
            DataTable dt = controllerobj.GetGarageInfo(S_ID);
            label1.Text = dt.Rows[0]["GARAGE_NAME"].ToString();
            label5.Text = dt.Rows[0]["STREET"].ToString();
            label9.Text = dt.Rows[0]["AREA"].ToString();
            label15.Text = dt.Rows[0]["DISTRICT"].ToString();
            label12.Text = dt.Rows[0]["CITY"].ToString();
            if(x!=0){
                label14.Text = x.ToString(); 
            }
            else{
                label14.Text = "Not Yet Rated";
                }
            textBox1.Text = dt.Rows[0]["Pay_Rate"].ToString();
            textBox2.Text = dt.Rows[0]["Overtime_Rate"].ToString();

        }

        private void GarageInfo_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void GarageInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerobj.TerminateConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||Convert.ToInt16(textBox1.Text) < 0 || Convert.ToInt16(textBox2.Text) < 0)
            {
                new ErrorMessage().Show();
                return;
            }
            int x = controllerobj.UpdatePayAndOvertimeRates(Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text), spotid);
            if (x==1)
                new Done().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void GarageInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            controllerobj.TerminateConnection();
        }
    }
}
