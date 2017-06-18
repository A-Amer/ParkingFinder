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
    public partial class Login : Form
    {
        Controller controllerObj= new Controller(); 
        private bool _loggedin = false;
        public static string type;
        public Login()
        {
            InitializeComponent();
             
        }

   

        

        private void button1_Click(object sender, EventArgs e)
        {

          
            DataTable check = controllerObj.SelectUsername(TxtBx_username.Text,textBox2.Text);

            if (check!=null)  
              {


                 //Login successful
                 _loggedin = true;
                 controllerObj.user_name = TxtBx_username.Text; //saving current User name in controller
                

             
           //HERE SHOULD OPEN APPROPRIATE FORM FOR USER ACCORDING TO HIS /HER TYPE (MANAGER,EMPLOYEE,CLIENT)
             DataRow dr = check.Rows[0];
             type = dr["type"].ToString();
                    if(type=="client")
                    {
                        Client_Form func = new Client_Form(controllerObj.user_name);
             func.Show(this);
             textBox2.Clear(); //password
             TxtBx_username.Clear();
             this.Hide();            
                    }
                    else
                    {

            Employee_Form func = new Employee_Form(controllerObj.user_name);
             func.Show(this);
             textBox2.Clear(); //password
             TxtBx_username.Clear();
             this.Hide();   


                    }
             }


              else
              {
                  MessageBox.Show("Wrong username or password");
              }

           
        }
       

       
        private void CreateAccount_Click(object sender, EventArgs e)
        {
           
            Account_Info func = new Account_Info();
            func.Show(this);
            this.Hide();            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            controllerObj.TerminateConnection();
        }

        private void TxtBx_username_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
