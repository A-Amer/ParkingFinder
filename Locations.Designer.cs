namespace Parking_Finder
{
    partial class Locations
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
            this.City = new System.Windows.Forms.ComboBox();
            this.Area = new System.Windows.Forms.ComboBox();
            this.District = new System.Windows.Forms.ComboBox();
            this.l3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Garages = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // City
            // 
            this.City.FormattingEnabled = true;
            this.City.Location = new System.Drawing.Point(11, 80);
            this.City.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(104, 21);
            this.City.TabIndex = 0;
            this.City.SelectedIndexChanged += new System.EventHandler(this.City_SelectedIndexChanged);
            // 
            // Area
            // 
            this.Area.FormattingEnabled = true;
            this.Area.Location = new System.Drawing.Point(136, 80);
            this.Area.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(104, 21);
            this.Area.TabIndex = 1;
            this.Area.SelectedIndexChanged += new System.EventHandler(this.Area_SelectedIndexChanged);
            // 
            // District
            // 
            this.District.FormattingEnabled = true;
            this.District.Location = new System.Drawing.Point(255, 80);
            this.District.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.District.Name = "District";
            this.District.Size = new System.Drawing.Size(104, 21);
            this.District.TabIndex = 2;
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Location = new System.Drawing.Point(33, 42);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(24, 13);
            this.l3.TabIndex = 3;
            this.l3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Area";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "District";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(136, 149);
            this.Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(79, 38);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Garages
            // 
            this.Garages.FormattingEnabled = true;
            this.Garages.Location = new System.Drawing.Point(466, 80);
            this.Garages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Garages.Name = "Garages";
            this.Garages.Size = new System.Drawing.Size(229, 251);
            this.Garages.TabIndex = 7;
            this.Garages.DoubleClick += new System.EventHandler(this.Garages_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Garages";
            // 
            // Locations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Garages);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.District);
            this.Controls.Add(this.Area);
            this.Controls.Add(this.City);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Locations";
            this.Text = "Locations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Locations_FormClosed);
            this.Load += new System.EventHandler(this.Locations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox City;
        private System.Windows.Forms.ComboBox Area;
        private System.Windows.Forms.ComboBox District;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ListBox Garages;
        private System.Windows.Forms.Label label1;
    }
}