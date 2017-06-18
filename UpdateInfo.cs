using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking_Finder
{
    public partial class UpdateInfo : Form
    {

        Controller controllerObj;
        int eid;
        public UpdateInfo(string un,int id=0)
        {
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = un;
            
            if (id== 0)
            {
                DataTable dt = controllerObj.SelectAllClient();
                textBox1.Text = dt.Rows[0]["CName"].ToString();
                textBox2.Text = dt.Rows[0]["username"].ToString();
                textBox3.Text = dt.Rows[0]["telephone"].ToString();
                dt = controllerObj.getcard(controllerObj.getClientID());
                if(dt!=null)
                 textBox4.Text = dt.Rows[0]["credit_card_No"].ToString();
                eid=0;
            }
            else {
                label4.Hide();
                textBox4.Hide(); textBox4.Enabled = false;
                button4.Hide(); button4.Enabled = false;
                eid = id;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                controllerObj.ChangeName(Convert.ToString(textBox1.Text),eid);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePassword c= new ChangePassword(controllerObj.user_name);
            c.Show();
        }

        private void UpdateInfo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = controllerObj.ChangeUserName(Convert.ToString(textBox2.Text));
            if (r > 0)
            {
                MessageBox.Show("User Name changed successfully");
                if (eid == 0)
                {
                    Owner.Close();
                    this.Close();
                    
                }
                else {
                    controllerObj.user_name = textBox2.Text;
                }
            }
            else
                MessageBox.Show("Choose another User name");
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox3.TextLength <11) {
                MessageBox.Show("Invalid Mobile number");
                return;
            }
                controllerObj.ChangeMobile(Convert.ToInt32(textBox3.Text),eid);
           
        }

        private void UpdateInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox4.TextLength <13){
                MessageBox.Show("Invalid Credit Card number");
                return;
            }
            int i = controllerObj.getClientID(controllerObj.user_name);
            int r;
            if (controllerObj.CreditClient(i))
            {
                 r = controllerObj.Updatecreditcard(i, Convert.ToInt64(textBox4.Text));
            }
            else {
                r = controllerObj.Insert_Card(Convert.ToInt64(textBox4.Text), i);
            }
            if (r != 0) {
                MessageBox.Show("Credit card successfully added");
            }
        }
    }
}
