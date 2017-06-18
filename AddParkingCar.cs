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
    public partial class AddParkingCar : Form
    {
        int spotid;
        int resid;
        Controller controllerObj;
        string dep;
        public AddParkingCar(int sid, int reid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            spotid = sid;
            dep = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatefloorsComboBox();
            comboBox5.DataSource = controllerObj.SelectAlC();
            comboBox5.ValueMember = "Client_ID";
            comboBox5.DisplayMember = "Client_ID";
            DataTable e = controllerObj.SelectAllParking(spotid, -1);
            comboBox1.DataSource = e;
            comboBox1.ValueMember = "Plates_Number";
            comboBox1.DisplayMember = "Plates_Number";
            resid = reid;
        }
        private void UpdatefloorsComboBox()
        {
            comboBox4.DisplayMember = "Floor";
            comboBox4.ValueMember = "Floor";
            comboBox4.DataSource = controllerObj.Selectfreefloors(controllerObj.Selectfreeforparkingnow(dep), spotid);
            comboBox4.Update();
        }
        private void UpdatesectionsComboBox()
        {
            comboBox3.DisplayMember = "Section";
            comboBox3.ValueMember = "Section";
            comboBox3.DataSource = controllerObj.Selectfreesections(controllerObj.Selectfreeforparkingnow(dep), spotid, (int)comboBox4.SelectedValue);
            comboBox3.Update();
        }
        private void UpdatelanesComboBox()
        {
            comboBox2.DisplayMember = "Lane";
            comboBox2.ValueMember = "Lane";
            comboBox2.DataSource = controllerObj.Selectfreelanes(controllerObj.Selectfreeforparkingnow(dep), spotid, (int)comboBox4.SelectedValue, comboBox3.SelectedValue.ToString());
            comboBox2.Update();
        }


        private void AddParkingCar_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!controllerObj.IsFree(spotid))
            {
                MessageBox.Show("No Parking Spot Available");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Plates Number");
                return;
            }
            if (comboBox3.SelectedIndex==-1)
            {
                MessageBox.Show("Enter Section");
                return;
            }
            if(textBox4.TextLength<6){
                MessageBox.Show("Invalid Plates Number");
                return;
            }
            DataTable d = controllerObj.SelectAllParking(-1, Convert.ToInt32(textBox4.Text));
            if (d != null)
            {
                MessageBox.Show("Invalid Plates Number");
                return;
            }
            DateTime arr = DateTime.Now;
            if (resid < 0)
            {
                DateTime depar = Convert.ToDateTime(dep);
                if (depar < arr)
                {
                    MessageBox.Show("Invalid Departure Time. Please try again");
                    return;
                }
                int y = controllerObj.InsertParkingCar(arr, depar, Convert.ToInt32(textBox4.Text), Convert.ToInt16(comboBox4.SelectedValue), Convert.ToInt16(comboBox2.SelectedValue), Convert.ToChar(comboBox3.SelectedValue), Convert.ToInt16(comboBox5.SelectedValue), spotid, (float)0);
                if (y == 0)
                {
                    MessageBox.Show("Insertion Failed");
                    return;
                }
                MessageBox.Show("Car Added");
                DataTable rr = controllerObj.SelectAllParking(spotid, -1);
                comboBox1.DataSource = rr;
                comboBox1.ValueMember = "Plates_Number";
                comboBox1.DisplayMember = "Plates_Number";
                return;
            }
            DataTable xx = controllerObj.SelectAllReservationbyID(resid);
            DateTime departu = Convert.ToDateTime(xx.Rows[0]["DepDT"]);
            float depositee = (float)xx.Rows[0]["Deposit"];
            int cid = Convert.ToInt16(xx.Rows[0]["Client_ID"]);
            int m = controllerObj.InsertParkingCar(arr, departu, Convert.ToInt32(textBox4.Text), Convert.ToInt16(comboBox4.SelectedValue), Convert.ToInt16(comboBox2.SelectedValue), Convert.ToChar(comboBox3.SelectedValue), cid, spotid, depositee);
            if (m == 0)
            {
                MessageBox.Show("Insertion Failed");
                return;
            }
            MessageBox.Show("Car Added");
            DataTable rx = controllerObj.SelectAllParking(spotid, -1);
            comboBox1.DataSource = rx;
            comboBox1.ValueMember = "Plates_Number";
            comboBox1.DisplayMember = "Plates_Number";
            return;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelanesComboBox();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatesectionsComboBox();
        }
        private void AddParkingCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dep = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatefloorsComboBox();
        }

        private void AddParkingCar_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable temp = controllerObj.SelectAllParking(spotid, Convert.ToInt32(comboBox1.SelectedValue));

            DateTime depar = Convert.ToDateTime(dep);
            DateTime arr = Convert.ToDateTime(temp.Rows[0]["Arrival"]);
            if (depar < arr)
            {
                MessageBox.Show("Invalid Departure Time. Please try again");
                return;
            }
            DataTable d = controllerObj.checkeditdep(spotid, Convert.ToInt16(temp.Rows[0]["Lane"]), Convert.ToChar(temp.Rows[0]["Section"]), Convert.ToInt16(temp.Rows[0]["Floor"]), dep);

            if (d != null)
            {
                MessageBox.Show("Departure Time intersecting with reservation");
                return;
            }
            int m = controllerObj.UpdateDepTime(Convert.ToInt32(comboBox1.SelectedValue), dep);
            if (m == 1)
                MessageBox.Show("Update done");
            else
                MessageBox.Show("update failed");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = controllerObj.SelectAllParking(spotid, Convert.ToInt32(comboBox1.SelectedValue));
            label10.Text = Convert.ToString(d.Rows[0]["Floor"]);
            label9.Text = Convert.ToString(d.Rows[0]["Section"]);
            label8.Text = Convert.ToString(d.Rows[0]["Lane"]);
            DateTime w = Convert.ToDateTime(d.Rows[0]["Expected_Dep"]);
            label11.Text = w.ToString("yyyy-MM-dd HH:mm:ss");
            label12.Text = Convert.ToString(d.Rows[0]["Client_ID"]);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dep = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatefloorsComboBox();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int m = controllerObj.UpdateLocationParkingCar(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt16(comboBox4.SelectedValue), Convert.ToChar(comboBox3.SelectedValue), Convert.ToInt16(comboBox2.SelectedValue));
            if (m == 1)
                MessageBox.Show("Update done");
            else
                MessageBox.Show("update failed");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DataTable temp = controllerObj.SelectAllParking(spotid, Convert.ToInt32(comboBox1.SelectedValue));
            dep = Convert.ToDateTime(temp.Rows[0]["Expected_Dep"]).ToString("yyyy-MM-dd HH:mm:ss");
            UpdatefloorsComboBox();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int m = controllerObj.UpdateClientIDParkingCar(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt16(comboBox5.SelectedValue));
            if (m == 1)
                MessageBox.Show("Update done");
            else
                MessageBox.Show("update failed");

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Plates Number");
                return;
            }
            if (textBox4.TextLength < 6)
            {
                MessageBox.Show("Invalid Plates Number");
                return;
            }
            int m = controllerObj.UpdatePlatesNumber(Convert.ToInt32(textBox4.Text), Convert.ToInt32(comboBox1.SelectedValue));
            if (m == 1)
            {
                MessageBox.Show("Update done");
                DataTable rr = controllerObj.SelectAllParking(spotid, -1);
                comboBox1.DataSource = rr;
                comboBox1.ValueMember = "Plates_Number";
                comboBox1.DisplayMember = "Plates_Number";
            }
            else
                MessageBox.Show("update failed");
        }
    }
}
