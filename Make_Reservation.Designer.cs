namespace Parking_Finder
{
    partial class Make_Reservation
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
            this.arrivalDT = new System.Windows.Forms.DateTimePicker();
            this.departureDT = new System.Windows.Forms.DateTimePicker();
            this.floor_combobox = new System.Windows.Forms.ComboBox();
            this.section_combobox = new System.Windows.Forms.ComboBox();
            this.lane_combobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.garage_combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // arrivalDT
            // 
            this.arrivalDT.CustomFormat = "dd MMMM yyyy HH:mm:ss";
            this.arrivalDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalDT.Location = new System.Drawing.Point(169, 21);
            this.arrivalDT.Margin = new System.Windows.Forms.Padding(2);
            this.arrivalDT.Name = "arrivalDT";
            this.arrivalDT.Size = new System.Drawing.Size(176, 20);
            this.arrivalDT.TabIndex = 0;
            this.arrivalDT.Value = new System.DateTime(2016, 12, 23, 0, 0, 0, 0);
            // 
            // departureDT
            // 
            this.departureDT.CustomFormat = "dd MMMM yyyy HH:mm:ss";
            this.departureDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.departureDT.Location = new System.Drawing.Point(169, 52);
            this.departureDT.Margin = new System.Windows.Forms.Padding(2);
            this.departureDT.MaxDate = new System.DateTime(2200, 1, 1, 0, 0, 0, 0);
            this.departureDT.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.departureDT.Name = "departureDT";
            this.departureDT.Size = new System.Drawing.Size(176, 20);
            this.departureDT.TabIndex = 1;
            this.departureDT.Value = new System.DateTime(2016, 12, 23, 20, 36, 2, 0);
            // 
            // floor_combobox
            // 
            this.floor_combobox.FormattingEnabled = true;
            this.floor_combobox.Location = new System.Drawing.Point(169, 126);
            this.floor_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.floor_combobox.Name = "floor_combobox";
            this.floor_combobox.Size = new System.Drawing.Size(82, 21);
            this.floor_combobox.TabIndex = 2;
            this.floor_combobox.SelectedIndexChanged += new System.EventHandler(this.floor_combobox_SelectedIndexChanged);
            // 
            // section_combobox
            // 
            this.section_combobox.FormattingEnabled = true;
            this.section_combobox.Location = new System.Drawing.Point(169, 168);
            this.section_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.section_combobox.Name = "section_combobox";
            this.section_combobox.Size = new System.Drawing.Size(82, 21);
            this.section_combobox.TabIndex = 3;
            this.section_combobox.SelectedIndexChanged += new System.EventHandler(this.section_combobox_SelectedIndexChanged);
            // 
            // lane_combobox
            // 
            this.lane_combobox.FormattingEnabled = true;
            this.lane_combobox.Location = new System.Drawing.Point(169, 211);
            this.lane_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.lane_combobox.Name = "lane_combobox";
            this.lane_combobox.Size = new System.Drawing.Size(82, 21);
            this.lane_combobox.TabIndex = 4;
            this.lane_combobox.SelectedIndexChanged += new System.EventHandler(this.lane_combobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "arrival date and time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "departure date and time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 173);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Section";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lane";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 255);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "garage name";
            // 
            // garage_combobox
            // 
            this.garage_combobox.FormattingEnabled = true;
            this.garage_combobox.Location = new System.Drawing.Point(169, 90);
            this.garage_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.garage_combobox.Name = "garage_combobox";
            this.garage_combobox.Size = new System.Drawing.Size(135, 21);
            this.garage_combobox.TabIndex = 13;
            this.garage_combobox.SelectedIndexChanged += new System.EventHandler(this.garage_combobox_SelectedIndexChanged);
            // 
            // Make_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 309);
            this.Controls.Add(this.garage_combobox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lane_combobox);
            this.Controls.Add(this.section_combobox);
            this.Controls.Add(this.floor_combobox);
            this.Controls.Add(this.departureDT);
            this.Controls.Add(this.arrivalDT);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Make_Reservation";
            this.Text = "Make_Reservation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Make_Reservation_FormClosed);
            this.Load += new System.EventHandler(this.Make_Reservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker arrivalDT;
        private System.Windows.Forms.DateTimePicker departureDT;
        private System.Windows.Forms.ComboBox floor_combobox;
        private System.Windows.Forms.ComboBox section_combobox;
        private System.Windows.Forms.ComboBox lane_combobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox garage_combobox;
    }
}