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
    public partial class InsertEmployee : Form
    {
        int spotid;
        Controller controllerObj;
        Controller c;
        public InsertEmployee(int sid)
        {
            InitializeComponent();
            controllerObj = new Controller();
            c = new Controller();
            spotid = sid;
        }

        private void InsertEmployee_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""||textBox2.TextLength<9)
            {
                new ErrorMessage().Show();
                return;
            }
            if(textBox2.TextLength<9){
                MessageBox.Show("Invalid SSN");
                return;
            }
            DataTable dt = c.FindEmp(Convert.ToInt64(textBox2.Text));
            if (dt != null)
            {
                new ErrorMessage().Show();
                return;
            }
            DataTable d = controllerObj.FindUsername(textBox5.Text);
            if (d != null)
            {
                new UsedUserName().Show();
                return;
            }
            int y = 0;
            int x = controllerObj.InsertAccount(textBox5.Text, textBox6.Text,"employee");
            if (x == 1)
            {
                if (textBox3.Text != "")
                {
                    y = controllerObj.InsertEmpl(textBox1.Text, Convert.ToInt64(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text, spotid);
                }
                else {
                    y = controllerObj.InsertEmpl(textBox1.Text, Convert.ToInt64(textBox2.Text), 0, Convert.ToInt32(textBox4.Text), textBox5.Text, spotid);
                }
            }
            if (x == 1 && y == 1)
            {
                new Done().Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void InsertEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
