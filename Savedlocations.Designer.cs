namespace Parking_Finder
{
    partial class Savedlocations
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
            this.Locations = new System.Windows.Forms.ListBox();
            this.Garages = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Locations
            // 
            this.Locations.FormattingEnabled = true;
            this.Locations.Location = new System.Drawing.Point(10, 58);
            this.Locations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Locations.Name = "Locations";
            this.Locations.Size = new System.Drawing.Size(138, 277);
            this.Locations.TabIndex = 0;
            this.Locations.DoubleClick += new System.EventHandler(this.Locations_DoubleClick);
            // 
            // Garages
            // 
            this.Garages.FormattingEnabled = true;
            this.Garages.Location = new System.Drawing.Point(239, 58);
            this.Garages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Garages.Name = "Garages";
            this.Garages.Size = new System.Drawing.Size(152, 277);
            this.Garages.TabIndex = 3;
            this.Garages.DoubleClick += new System.EventHandler(this.Garages_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your Saved Locations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Garages";
            // 
            // Savedlocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 401);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Garages);
            this.Controls.Add(this.Locations);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Savedlocations";
            this.Text = "Savedlocations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Savedlocations_FormClosed);
            this.Load += new System.EventHandler(this.Savedlocations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Locations;
        private System.Windows.Forms.ListBox Garages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}