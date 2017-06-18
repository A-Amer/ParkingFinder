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
    public partial class Employee_Form : Form
    {
        int id,spotid;
        Controller controllerObj;
        
        public Employee_Form(string username)
        {
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = username;
            id = controllerObj.RetrieveEmployeeID();
            spotid = controllerObj.RetrieveEmployeeSpotID();
            controllerObj.SetArrival(id);
            DataTable dt = controllerObj.EmployeeInfo(id);
            if (dt != null)
            {
                label1.Text = dt.Rows[0].ItemArray[0].ToString();
                label2.Text = dt.Rows[0].ItemArray[1].ToString();
                label5.Text = dt.Rows[0].ItemArray[2].ToString();
            }
            else{
                dt = controllerObj.InfoNoAvg(id);
                label1.Text = dt.Rows[0].ItemArray[0].ToString();
                label2.Text = dt.Rows[0].ItemArray[1].ToString();
                label5.Text = "Not Rated yet";
            }
           
            if (Login.type == "employee") {
                button9.Enabled = false;
                button7.Enabled = false;
                button3.Enabled = false;
                button8.Enabled = false;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateInfo up = new UpdateInfo(controllerObj.user_name,id);
            if(up!=null)
            up.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Employee_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.SetDep(id);
            controllerObj.TerminateConnection();
            if (e.CloseReason == CloseReason.UserClosing)
                Owner.Show();
            
        }

        private void Employee_Form_Load(object sender, EventArgs e)
        {

            
        }

        private void Statstics_Click(object sender, EventArgs e)
        {
            new Statstics(id,spotid).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Employees(id, spotid).Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new GarageInfo(spotid).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ReviewReply(spotid).Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable dt = controllerObj.SelectClientFromReservation(spotid);
            if (dt != null)
            {
                new Reservations(spotid).Show();
            }
            else {
                MessageBox.Show("You have no reservations!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ParkingCars(spotid).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Transactions(spotid).Show();
        }
    }
}
