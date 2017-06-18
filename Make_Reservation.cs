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
    public partial class Make_Reservation : Form
    {
        private Controller controllerObj;
        private int? res_ID;
        public int? resID { get { return res_ID; } }

        public Make_Reservation(string user,int garage=0)
        {
            InitializeComponent();
            res_ID = resID;
            controllerObj = new Controller();
            controllerObj.user_name = user;
            UpdategarageComboBox();
            UpdatefloorsComboBox();
            UpdatesectionsComboBox();
            UpdatelanesComboBox();
            if (garage != 0) {
                garage_combobox.SelectedValue = garage;
                UpdatefloorsComboBox();
                UpdatesectionsComboBox();
                UpdatelanesComboBox();
            }
        }
        private int getparkedhours(DateTime arr,DateTime dept)
        {
            TimeSpan diff = dept - arr;
            return (int)Math.Ceiling(diff.TotalHours);
        }
        public float calculateDeposit(int spot_ID)
        {
           float payrate= controllerObj.getgaragePayRateDeposit(spot_ID);
           int hours = getparkedhours(arrivalDT.Value, departureDT.Value);
           float deposit = (payrate * (float)hours) / 2;
           return deposit;
        }
        
        private void Make_Reservation_Load(object sender, EventArgs e)
        {
            
            
           
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (arrivalDT.Value < DateTime.Now) {
                MessageBox.Show("Arrival Time has passed!");
                return;
            }


            TimeSpan diff = departureDT.Value - arrivalDT.Value;
            int limit=(int)Math.Ceiling(diff.TotalHours);
            if (limit>0)
            {
                int result = controllerObj.addReservation(
                        arrivalDT.Value,
                        departureDT.Value,
                        (float)calculateDeposit((int)garage_combobox.SelectedValue),
                        (int)floor_combobox.SelectedValue,
                        (int)lane_combobox.SelectedValue,
                        section_combobox.SelectedValue.ToString(),
                        controllerObj.getClientID(),
                        (int)garage_combobox.SelectedValue
                        );

                if (result > 0)
                {
                    MessageBox.Show("Reservation Succeeded");
                    this.Close();
                    
                }
                else
                    MessageBox.Show("Reservation Failed");
            }
            else
            {
                MessageBox.Show("Reservation Failed,Make sure the departure time is after the arrival time");
            }
        }
      
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void garage_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatefloorsComboBox();
        }
        private void UpdategarageComboBox()
        {
            garage_combobox.DisplayMember = "SName";
            garage_combobox.ValueMember = "Spot_ID";
            garage_combobox.DataSource = controllerObj.getGaragesnamesbyID(controllerObj.Selectfreegarages(controllerObj.Selectfreeplaces()));
            garage_combobox.Update();
        }
        private void UpdatefloorsComboBox()
        {
            floor_combobox.DisplayMember = "Floor";
            floor_combobox.ValueMember = "Floor";
            floor_combobox.DataSource = controllerObj.Selectfreefloors(controllerObj.Selectfreeplaces(),(int)garage_combobox.SelectedValue);
            floor_combobox.Update();
        }
        private void UpdatesectionsComboBox()
        {
            section_combobox.DisplayMember = "Section";
            section_combobox.ValueMember = "Section";
            section_combobox.DataSource = controllerObj.Selectfreesections(controllerObj.Selectfreeplaces(), (int)garage_combobox.SelectedValue, (int)floor_combobox.SelectedValue);
            section_combobox.Update();
        }
        private void UpdatelanesComboBox()
        {
            lane_combobox.DisplayMember = "Lane";
            lane_combobox.ValueMember = "Lane";
            lane_combobox.DataSource = controllerObj.Selectfreelanes(controllerObj.Selectfreeplaces(), (int)garage_combobox.SelectedValue,(int)floor_combobox.SelectedValue,section_combobox.SelectedValue.ToString());
            lane_combobox.Update();
        }
        
        private void floor_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatesectionsComboBox();
        }

        private void section_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelanesComboBox();
        }

        private void SavedGarages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Make_Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void lane_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
