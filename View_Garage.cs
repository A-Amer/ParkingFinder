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
    public partial class View_Garage : Form
    {
        private Controller controllerObj;
        private int? garage_ID;
        public int? garageID { get { return garage_ID; } }
        string username;
        public View_Garage(int garageid,string un)
        {
            InitializeComponent();
            garage_ID = garageid;
            username = un;
            controllerObj = new Controller();
            controllerObj.user_name=un;
            int id = controllerObj.getClientID();
           dataGridView1.DataSource= controllerObj.ClientRev(garageid);
           if (controllerObj.IsFree(garageid))
               ovalShape1.FillColor = Color.Green;
           else
               ovalShape1.FillColor = Color.Red;
           if (!controllerObj.CreditClient(id)) {
               button1.Enabled = false;
           }
        }

        private void View_Garage_Load(object sender, EventArgs e)
        {
            
            updateViewGarage();
        }
        private void updateViewGarage()
        {
            if (garage_ID != null)
            {
                float avrgRate;
                avrgRate =(float) controllerObj.getRatingsavrg(garage_ID.GetValueOrDefault());
                garagename.Text = controllerObj.getGarageName(garage_ID.GetValueOrDefault());
                payrate.Value = (decimal)controllerObj.getGaragePayRate(garage_ID.GetValueOrDefault());
                overtimerate.Value = (decimal)controllerObj.getGarageOverRate(garage_ID.GetValueOrDefault());
                numfloors.Value = controllerObj.getNo_Floors(garage_ID.GetValueOrDefault());
                numsections.Value = controllerObj.getNo_Sections(garage_ID.GetValueOrDefault());
                numlanes.Value = controllerObj.getNo_Lanes(garage_ID.GetValueOrDefault());
                city.Text = controllerObj.getCity(garage_ID.GetValueOrDefault());
                area.Text = controllerObj.getArea(garage_ID.GetValueOrDefault());
                district.Text = controllerObj.getDistrict(garage_ID.GetValueOrDefault());
                street.Text = controllerObj.getStreet(garage_ID.GetValueOrDefault());
                avrgrate.Value = (decimal)avrgRate;

                
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void View_Garage_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            new Make_Reservation(username, garage_ID.Value).Show();
        }
    }
}
