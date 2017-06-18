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
    public partial class cancel_reason : Form
    {
        private Controller controllerObj;
        private int? res_ID;
        public int? resID { get { return res_ID; } } 
        public cancel_reason(int resID)
        {
            InitializeComponent();
            res_ID = resID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime systemDate = DateTime.Now;
           
            int result2 = controllerObj.addtoRefund2(systemDate,reasonofcancel.Text,controllerObj.getRefundAmount(res_ID.GetValueOrDefault()),controllerObj.getclientID(res_ID.GetValueOrDefault()),controllerObj.getgarageID(res_ID.GetValueOrDefault()));
            int result = controllerObj.CancelReservation(res_ID.GetValueOrDefault());
            MessageBox.Show("Reservation Cancelled with refund");
            this.Close();
        }

        private void cancel_reason_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
        }

        private void cancel_reason_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void reasonofcancel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
