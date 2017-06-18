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
    public partial class ParkingCars : Form
    {
        Controller controllerobj;
        int spotid;
        public ParkingCars(int sid)
        {
            InitializeComponent();
            controllerobj = new Controller();
            spotid = sid;
            DataTable dt = controllerobj.SelectAllParking(spotid, -1);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Client_Name";
            comboBox2.ValueMember = "Client_ID";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ParkingCars_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddParkingCar(spotid,-1).Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable   dt = controllerobj.SelectAllParking(spotid, Convert.ToInt32(comboBox1.SelectedValue));
            if (dt == null)
                MessageBox.Show("Parking Car(s) not Found");
            else
                dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ParkingCars_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerobj.TerminateConnection();
        }

        private int getparkedhours(DateTime arr, DateTime dept)
        {
            TimeSpan diff = dept - arr;
            return (int)Math.Ceiling(diff.TotalHours);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = controllerobj.SelectAllParking(spotid, Convert.ToInt32(comboBox1.SelectedValue));
            
            DateTime arr, dep, expdep;
            float pay,deposite;
            string method;
            int cid,sid;
            int hexp, hext;

            Int32 platesno = Convert.ToInt32(dt.Rows[0]["Plates_Number"]);
            sid = spotid;
            cid = Convert.ToInt16(dt.Rows[0]["Client_ID"]);
            deposite=(float) dt.Rows[0]["Deposit"];
            if (deposite == 0)
                method = "Cash";
            else
                method ="Credit";
            arr = Convert.ToDateTime(dt.Rows[0]["Arrival"]);
            expdep = Convert.ToDateTime(dt.Rows[0]["Expected_Dep"]);

            dep = DateTime.Now;
            
            float payrate = controllerobj.getGaragePayRate(spotid);
            hext = getparkedhours(dep, expdep);
            hexp = getparkedhours(arr, expdep);
            if (hext < 0)
            {

                pay = (float)hexp * payrate - deposite;

            }
            else
            {
                float overtime = controllerobj.getGarageOverRate(spotid);
                pay = (float)hexp * payrate + (float)hext * overtime * (float)-1 - deposite;
                
            }
            pay = (float)Math.Ceiling(pay);

            int c = controllerobj.InsertTransaction(arr, dep, pay, method, cid, sid, deposite);
            if (c == 1)
            {
                int m = controllerobj.DeleteParkingCar(platesno);
                if (m==1)
                    MessageBox.Show("Moved to Transactions");
           }
            else
                MessageBox.Show("could not move to transaction");
            DataTable t = controllerobj.SelectAllParking(spotid, -1);
            comboBox2.DataSource = t;
            comboBox2.DisplayMember = "Client_Name";
            comboBox2.ValueMember = "Client_ID";
            comboBox2.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.SelectAllParking(spotid, -1);
            if (dt == null)
                MessageBox.Show("Parking Car(s) not Found");
            else
                dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.SelectParkingOfClient(spotid,Convert.ToInt16(comboBox2.SelectedValue));
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Plates_Number";
            comboBox1.ValueMember = "Plates_Number";
            comboBox1.Update();
        }

        private void ParkingCars_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            controllerobj.TerminateConnection();
        }
    }
}
