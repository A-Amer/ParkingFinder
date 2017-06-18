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
    public partial class Client_Form : Form
    {
        string un;
        Controller controllerObj;
        public Client_Form(string username)
        {
            InitializeComponent();
            un = username;
            controllerObj=new Controller();
            controllerObj.user_name=un;
            
        }


        private void Client_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controllerObj.CreditClient(controllerObj.getClientID(un)))
            {
                Cancel_Make_Reservation cmr = new Cancel_Make_Reservation(un);
                cmr.Show();
            }
            else {
                MessageBox.Show("Please add your credit card number to your info to access this privlige");
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Garages_Options v = new Garages_Options(un);
            if(v!=null)
              v.Show(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
           UpdateInfo up=new UpdateInfo(un);
            if(up!=null)
            up.Show(this);
        }

        private void Saved_Click(object sender, EventArgs e)
        {
            Savedlocations sl = new Savedlocations(un);
            if(sl!=null)
            sl .Show(this);
    
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Locations l = new Locations(un);
            if(l!=null)
              l.Show(this);
        }

        private void Client_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
