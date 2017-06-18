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
    public partial class Garages_Options : Form
    {
        private Controller controllerObj;
        string user;
        public Garages_Options(string un)
        {
            InitializeComponent();
            controllerObj = new Controller();
            controllerObj.user_name = un;
            user = un;
        }

        private void Garage_List_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private void Garages_Options_Load(object sender, EventArgs e)
        {
            Ratingscombobox.SelectedIndex = 0;
            UpdateGarageList();
            Citycombobox();
           
           

        }
        private void UpdateGarageList()
        {

            Garages_List.DataSource = controllerObj.SelectGaragesNames();
            Garages_List.ValueMember = "Spot_ID";
            Garages_List.DisplayMember = "SName";
            Garages_List.Refresh();

        }
        private void Citycombobox()
        {
            DataTable dt = controllerObj.SelectAllCity();
            CitycomboBox.DataSource = dt;
            CitycomboBox.DisplayMember = "CITY";
            CitycomboBox.Update();
            AreacomboBox.Enabled = false;
            District.Enabled = false;
           

        }
        private void Garage_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int garage_id = (int)Garages_List.SelectedValue;
            View_Garage G = new View_Garage(garage_id,user);
            G.Show();
        }

        private void Garages_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Spot_ID = (int)Garages_List.SelectedValue;
            int cid = controllerObj.getClientID(user);
            int result = controllerObj.SaveGarage(cid, Spot_ID);//put controllerObj.getClientID() instead of 7
            if (result>0)
                MessageBox.Show("Garage Saved");
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (controllerObj.getSavedGarages(controllerObj.getClientID()) != null)
            {
                Saved_Garages sg = new Saved_Garages(user);
                if (sg != null)
                    sg.Show();
            }
            else
            {
                MessageBox.Show("You Have No Saved Garages");

            }
        }

        private void Rate_Click(object sender, EventArgs e)
        {
            if (Ratingscombobox.SelectedIndex != 0)
            {
                int Spot_ID = (int)Garages_List.SelectedValue;
                int cid = controllerObj.getClientID(user);//check if to update or insert
              int r= controllerObj.Rate(Ratingscombobox.SelectedIndex, Spot_ID, cid);
              if (r == 0)//then this user wants to enter a new rating for same grage
              {
                  controllerObj.UpdateRating(Ratingscombobox.SelectedIndex, Spot_ID, cid);
                  MessageBox.Show("Your rating  updated successfully");
              }
              
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Review_Click(object sender, EventArgs e)
        {
            int Spot_ID = (int)Garages_List.SelectedValue;
            int cid = controllerObj.getClientID(user);
            controllerObj.Rate(Ratingscombobox.SelectedIndex, Spot_ID, cid);
            int r=controllerObj.review(cid, Spot_ID, DateTime.Now, richTextBox1.Text);

        }

        private void SaveLocation_Click(object sender, EventArgs e)
        {
            int cid = controllerObj.getClientID(user);
            int lid = controllerObj.LocationID(CitycomboBox.Text, AreacomboBox.Text, District.Text);
            int r = controllerObj.Bookmark(cid, lid);
            if(r>0)
                MessageBox.Show(" A new location saved successfully");
            else
                MessageBox.Show(" Location already saved before");
        }
   

      
        private void UpdateArea()
        {
           
            DataTable dt = controllerObj.SelectDistinctArea(CitycomboBox.Text);
            AreacomboBox.DataSource = dt;
            AreacomboBox.DisplayMember = "AREA";
            AreacomboBox.ValueMember = "Location_ID";
            AreacomboBox.Update();
            
        }
        private void UpdateDistrict()
        {
            DataTable dt = controllerObj.selectDistinctDistrict(AreacomboBox.Text,CitycomboBox.Text);
            District.DataSource = dt;
            District.DisplayMember = "District";
            District.ValueMember = "Location_ID";

        }
        private void CitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            AreacomboBox.Enabled = true;
            UpdateArea();
          
        }

        private void AreacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            District.Enabled = true;
            UpdateDistrict();
            District.Update();
        }

        private void Garages_Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

       

    }
}
