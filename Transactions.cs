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
    public partial class Transactions : Form
    {
        Controller controllerObj;
        int spotid;
        public Transactions(int sid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            spotid = sid;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            DataTable dt = controllerObj.SelectAllTrans(spotid);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember ="Client_ID";
            comboBox1.DisplayMember = "Client_Name";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Transactions_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controllerObj.SelectAllTrans(spotid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="") {
                MessageBox.Show("Select Amount to be searched");
                return;
            }
            dataGridView1.DataSource = controllerObj.SelectTrans(spotid, Convert.ToDouble(textBox1.Text), 0, (comboBox2.SelectedIndex + 1), Convert.ToInt16(comboBox3.SelectedItem));
           
           }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Select Amount to be searched");
                return;
            }
            dataGridView1.DataSource = controllerObj.SelectTrans(spotid, Convert.ToDouble(textBox1.Text), -1, (comboBox2.SelectedIndex + 1), Convert.ToInt16(comboBox3.SelectedItem));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Select Amount to be searched");
                return;
            }
            dataGridView1.DataSource = controllerObj.SelectTrans(spotid, Convert.ToDouble(textBox1.Text), 1, (comboBox2.SelectedIndex + 1), Convert.ToInt16(comboBox3.SelectedItem));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controllerObj.SelectTransClient(spotid, Convert.ToInt16(comboBox1.SelectedValue),(comboBox2.SelectedIndex+1), Convert.ToInt16(comboBox3.SelectedItem));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Transactions_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Transactions_Load(object sender, EventArgs e)
        {

        }
    }
}
