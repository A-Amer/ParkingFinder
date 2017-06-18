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
    public partial class Form1 : Form
    {
        int sid;
        public Form1(int si)
        {
            InitializeComponent();
            sid=si;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           int m1=comboBox1.SelectedIndex+1;
           int m2=comboBox2.SelectedIndex+1;
           int m3=comboBox3.SelectedIndex+1;
           int y1=Convert.ToInt16(comboBox4.SelectedItem);
           int y2=Convert.ToInt16(comboBox5.SelectedItem);
           int y3=Convert.ToInt16(comboBox6.SelectedItem);
           new ReservationStat(m1,m2,m3,y1,y2,y3,sid).Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
        }

    }

