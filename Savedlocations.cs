using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Parking_Finder
{
    public partial class Savedlocations : Form
    {
        string user;
        int cid;
        Controller controllerObj;
        public Savedlocations(string un)
        {
            user = un;
            InitializeComponent();
            controllerObj = new Controller();
           int ci= controllerObj.getClientID(un);
           cid = ci;
          
           
        }
        private int updatesaved()
        {
            DataTable dt = controllerObj.getsavedLoc(cid);
            if(  dt!=null  )
            {
            Locations.DataSource = dt;
            Locations.DisplayMember = "savedlocation";
            Locations.ValueMember = "ID";
        
            Locations.Update();
            return 1;
            }
            else
            {
                MessageBox.Show("You Have No Saved Locations");
                return 0;
            }
        }

       

       
        public void updategarages()
        {
            int li = (int)Locations.SelectedValue;
            DataTable dt=controllerObj.getlocga((int)Locations.SelectedValue);
            Garages.DataSource = dt;
            Garages.DisplayMember = "SNAME";
            Garages.ValueMember = "gi";


        }

        private void Locations_DoubleClick(object sender, EventArgs e)
        {
            
            updategarages();
            Garages.Update();
        }

        private void Garages_DoubleClick(object sender, EventArgs e)
        {
            int garage_id = (int)Garages.SelectedValue;
            View_Garage G = new View_Garage(garage_id,user);
            G.Show();

        }

        private void Savedlocations_Load(object sender, EventArgs e)
        {
            if (updatesaved() == 0)
            {
                this.Close();
            }
        }

        private void Savedlocations_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        
        

      
    }



}
