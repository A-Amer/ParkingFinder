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
    public partial class Locations : Form
    {
        private Controller controllerObj;
        string user;
        public Locations(string un)
        {
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = un;
            user = un;
        }

        private void Locations_Load(object sender, EventArgs e)
        {
            Citycombobox();
        }
        private void Citycombobox()
        {
            DataTable dt = controllerObj.SelectAllCity();
            City.DataSource = dt;
            City.DisplayMember = "CITY";
            
            City.Update();
            Area.Enabled = false;
            District.Enabled = false;


        }
        private void UpdateArea()
        {

            DataTable dt = controllerObj.SelectDistinctArea(City.Text);
            Area.DataSource = dt;
            Area.DisplayMember = "AREA";
            Area.ValueMember = "Location_ID";
            Area.Update();

        }
        private void UpdateDistrict()
        {
            DataTable dt = controllerObj.selectDistinctDistrict(Area.Text, City.Text);
            District.DataSource = dt;
            District.DisplayMember = "District";
            District.ValueMember = "Location_ID";

        }

        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            Area.Enabled = true;
            UpdateArea();
          
        }

        private void Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            District.Enabled = true;
            UpdateDistrict();
            District.Update();
        }
        public void updategarages()
        {
            int lid = controllerObj.LocationID(City.Text, Area.Text, District.Text);
            DataTable dt = controllerObj.getlocga(lid);
            Garages.DataSource = dt;
            Garages.DisplayMember = "SNAME";
            Garages.ValueMember = "gi";


        }
        private void Search_Click(object sender, EventArgs e)
        {
            updategarages();
            Garages.Update();

        }
        private void Garages_DoubleClick(object sender, EventArgs e)
        {
            int garage_id = (int)Garages.SelectedValue;
            View_Garage G = new View_Garage(garage_id, user);
            G.Show();

        }

        private void Locations_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
