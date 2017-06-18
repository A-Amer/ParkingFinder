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
   
    public partial class Change_Reservation : Form
    {
        private Controller controllerObj;
        private int? res_ID;
        public int? resID { get { return res_ID; } }
        

        public Change_Reservation(int resID)
        {
            
            InitializeComponent();
            res_ID = resID;
           
        }
        private int getparkedhours(DateTime arr, DateTime dept)
        {
            TimeSpan diff = dept - arr;
            return (int)Math.Ceiling(diff.TotalHours); //rounding up hours
           
        }
        public float calculateDeposit(int spot_ID)
        {
            float payrate = controllerObj.getgaragePayRateDeposit(spot_ID);
            int hours = getparkedhours(arrivalDT2.Value, departureDT2.Value);
            float deposit = (payrate * (float)hours) / 2;
            return deposit;
        }
        private void Change_Reservation_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            UpdategarageComboBox();
            
            if (res_ID != null)
            {
                UpdateData();
            }
            
        }
        private void UpdategarageComboBox()
        {
            garagecombobox2.DisplayMember = "SName";
            garagecombobox2.ValueMember = "Spot_ID";
            garagecombobox2.DataSource = controllerObj.getGaragesnamesbyID(controllerObj.Selectfreegarages(controllerObj.Selectfreeandcurrent(res_ID.GetValueOrDefault())));
            garagecombobox2.Update();
        }
        private void UpdatefloorsComboBox()
        {
            floorcombobox2.DisplayMember = "Floor";
            floorcombobox2.ValueMember = "Floor";
            floorcombobox2.DataSource = controllerObj.Selectfreefloors(controllerObj.Selectfreeandcurrent(res_ID.GetValueOrDefault()), (int)garagecombobox2.SelectedValue);
            floorcombobox2.Update();
        }
        private void UpdatesectionsComboBox()
        {
            
            sectioncombobox2.DisplayMember = "Section";
            sectioncombobox2.ValueMember = "Section";
            sectioncombobox2.DataSource = controllerObj.Selectfreesections(controllerObj.Selectfreeandcurrent(res_ID.GetValueOrDefault()), (int)garagecombobox2.SelectedValue, (int)floorcombobox2.SelectedValue);
            sectioncombobox2.Update();
        }
        private void UpdatelanesComboBox()
        {
            
            lanecombobox2.DisplayMember = "Lane";
            lanecombobox2.ValueMember = "Lane";
            lanecombobox2.DataSource = controllerObj.Selectfreelanes(controllerObj.Selectfreeandcurrent(res_ID.GetValueOrDefault()), (int)garagecombobox2.SelectedValue, (int)floorcombobox2.SelectedValue, sectioncombobox2.SelectedValue.ToString());///msh mota2akeda mn rabe3 parameter ento kda haywsal sa7
            lanecombobox2.Update();
        }

        //viewing reservation info
        public void UpdateData()
        {
            DataRow Reservation = controllerObj.SelectReservationbyID(res_ID.GetValueOrDefault()).Rows[0];
            arrivalDT2.Value = (DateTime)Reservation["ArrDT"];
            departureDT2.Value = (DateTime)Reservation["DepDT"];
            garagecombobox2.SelectedValue = Reservation["Spot_ID"];
            sectioncombobox2.SelectedItem = Reservation["Section"];
            floorcombobox2.SelectedItem = Reservation["Floor"];
            lanecombobox2.SelectedItem = Reservation["Lane"];
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (arrivalDT2.Value < DateTime.Now)
            {
                MessageBox.Show("Arrival Time has passed!");
                return;
            }
            if (arrivalDT2.Value < departureDT2.Value)
            {
                if (res_ID != null)
                {
                    int result = controllerObj.ChangeReservation(
                        res_ID.GetValueOrDefault(),
                        arrivalDT2.Value,
                        departureDT2.Value,
                        (float)calculateDeposit((int)garagecombobox2.SelectedValue),
                        (int)floorcombobox2.SelectedValue,
                        (int)lanecombobox2.SelectedValue,
                        sectioncombobox2.SelectedValue.ToString(),
                        (int)garagecombobox2.SelectedValue
                        );

                    if (result > 0)

                        MessageBox.Show("Reservation changed");

                    else
                        MessageBox.Show("Change Failed");
                }
            }
            else
                MessageBox.Show("Change Failed, make sure that your departure is after your arrival");
        }

        private void garagecombobox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatefloorsComboBox();
        }

        private void floorcombobox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatesectionsComboBox();
        }

        private void sectioncombobox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatelanesComboBox();
        }

        private void Change_Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }
    }
}
