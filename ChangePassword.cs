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
    public partial class ChangePassword : Form
    {
        Controller controllerObj;
        public ChangePassword(string un)
        {
            
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = un;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                DataTable dt = controllerObj.CheckPasswordc();
                if (dt.Rows[0]["password"].Equals(textBox1.Text) && textBox2.Text == textBox3.Text)
                {
                    controllerObj.ChangePassword(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Wrong password or mismatched passwords!");
                }
            }
            else {
                MessageBox.Show("Please enter all values");
            }
            



            

        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
