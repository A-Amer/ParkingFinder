namespace Parking_Finder
{
    partial class Change_Reservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.arrivalDT2 = new System.Windows.Forms.DateTimePicker();
            this.departureDT2 = new System.Windows.Forms.DateTimePicker();
            this.floorcombobox2 = new System.Windows.Forms.ComboBox();
            this.sectioncombobox2 = new System.Windows.Forms.ComboBox();
            this.lanecombobox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.garagecombobox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // arrivalDT2
            // 
            this.arrivalDT2.Location = new System.Drawing.Point(183, 31);
            this.arrivalDT2.Margin = new System.Windows.Forms.Padding(2);
            this.arrivalDT2.Name = "arrivalDT2";
            this.arrivalDT2.Size = new System.Drawing.Size(183, 20);
            this.arrivalDT2.TabIndex = 0;
            // 
            // departureDT2
            // 
            this.departureDT2.Location = new System.Drawing.Point(183, 74);
            this.departureDT2.Margin = new System.Windows.Forms.Padding(2);
            this.departureDT2.Name = "departureDT2";
            this.departureDT2.Size = new System.Drawing.Size(183, 20);
            this.departureDT2.TabIndex = 1;
            // 
            // floorcombobox2
            // 
            this.floorcombobox2.FormattingEnabled = true;
            this.floorcombobox2.Location = new System.Drawing.Point(183, 144);
            this.floorcombobox2.Margin = new System.Windows.Forms.Padding(2);
            this.floorcombobox2.Name = "floorcombobox2";
            this.floorcombobox2.Size = new System.Drawing.Size(82, 21);
            this.floorcombobox2.TabIndex = 2;
            this.floorcombobox2.SelectedIndexChanged += new System.EventHandler(this.floorcombobox2_SelectedIndexChanged);
            // 
            // sectioncombobox2
            // 
            this.sectioncombobox2.FormattingEnabled = true;
            this.sectioncombobox2.Location = new System.Drawing.Point(183, 178);
            this.sectioncombobox2.Margin = new System.Windows.Forms.Padding(2);
            this.sectioncombobox2.Name = "sectioncombobox2";
            this.sectioncombobox2.Size = new System.Drawing.Size(82, 21);
            this.sectioncombobox2.TabIndex = 3;
            this.sectioncombobox2.SelectedIndexChanged += new System.EventHandler(this.sectioncombobox2_SelectedIndexChanged);
            // 
            // lanecombobox2
            // 
            this.lanecombobox2.FormattingEnabled = true;
            this.lanecombobox2.Location = new System.Drawing.Point(183, 219);
            this.lanecombobox2.Margin = new System.Windows.Forms.Padding(2);
            this.lanecombobox2.Name = "lanecombobox2";
            this.lanecombobox2.Size = new System.Drawing.Size(82, 21);
            this.lanecombobox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "arrival date and time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "departure date and time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Section";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lane";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 258);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "garage name";
            // 
            // garagecombobox2
            // 
            this.garagecombobox2.FormattingEnabled = true;
            this.garagecombobox2.Location = new System.Drawing.Point(183, 107);
            this.garagecombobox2.Margin = new System.Windows.Forms.Padding(2);
            this.garagecombobox2.Name = "garagecombobox2";
            this.garagecombobox2.Size = new System.Drawing.Size(135, 21);
            this.garagecombobox2.TabIndex = 13;
            this.garagecombobox2.SelectedIndexChanged += new System.EventHandler(this.garagecombobox2_SelectedIndexChanged);
            // 
            // Change_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 292);
            this.Controls.Add(this.garagecombobox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lanecombobox2);
            this.Controls.Add(this.sectioncombobox2);
            this.Controls.Add(this.floorcombobox2);
            this.Controls.Add(this.departureDT2);
            this.Controls.Add(this.arrivalDT2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Change_Reservation";
            this.Text = "Change_Reservation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Change_Reservation_FormClosed);
            this.Load += new System.EventHandler(this.Change_Reservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker arrivalDT2;
        private System.Windows.Forms.DateTimePicker departureDT2;
        private System.Windows.Forms.ComboBox floorcombobox2;
        private System.Windows.Forms.ComboBox sectioncombobox2;
        private System.Windows.Forms.ComboBox lanecombobox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox garagecombobox2;
    }
}