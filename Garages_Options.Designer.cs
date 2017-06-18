namespace Parking_Finder
{
    partial class Garages_Options
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
            this.components = new System.ComponentModel.Container();
            this.Rate = new System.Windows.Forms.Button();
            this.Review = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Garages_List = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Ratingscombobox = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.District = new System.Windows.Forms.ComboBox();
            this.SaveLocation = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CitycomboBox = new System.Windows.Forms.ComboBox();
            this.AreacomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Rate
            // 
            this.Rate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rate.Location = new System.Drawing.Point(693, 81);
            this.Rate.Margin = new System.Windows.Forms.Padding(2);
            this.Rate.Name = "Rate";
            this.Rate.Size = new System.Drawing.Size(64, 48);
            this.Rate.TabIndex = 1;
            this.Rate.Text = "Rate the Garage";
            this.Rate.UseVisualStyleBackColor = true;
            this.Rate.Click += new System.EventHandler(this.Rate_Click);
            // 
            // Review
            // 
            this.Review.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Review.Location = new System.Drawing.Point(693, 168);
            this.Review.Margin = new System.Windows.Forms.Padding(2);
            this.Review.Name = "Review";
            this.Review.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Review.Size = new System.Drawing.Size(64, 49);
            this.Review.TabIndex = 2;
            this.Review.Text = "Review the Garage";
            this.Review.UseVisualStyleBackColor = true;
            this.Review.Click += new System.EventHandler(this.Review_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Double click to view a garage info:";
            // 
            // Garages_List
            // 
            this.Garages_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Garages_List.FormattingEnabled = true;
            this.Garages_List.Location = new System.Drawing.Point(10, 81);
            this.Garages_List.Margin = new System.Windows.Forms.Padding(2);
            this.Garages_List.Name = "Garages_List";
            this.Garages_List.Size = new System.Drawing.Size(301, 355);
            this.Garages_List.TabIndex = 4;
            this.Garages_List.SelectedIndexChanged += new System.EventHandler(this.Garages_List_SelectedIndexChanged);
            this.Garages_List.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(470, 353);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 47);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save Garage";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(604, 353);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 55);
            this.button4.TabIndex = 6;
            this.button4.Text = "View your Saved Garages";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Ratingscombobox
            // 
            this.Ratingscombobox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Ratingscombobox.FormattingEnabled = true;
            this.Ratingscombobox.Items.AddRange(new object[] {
            ' ',
            1,
            2,
            3,
            4,
            5});
            this.Ratingscombobox.Location = new System.Drawing.Point(521, 81);
            this.Ratingscombobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ratingscombobox.Name = "Ratingscombobox";
            this.Ratingscombobox.Size = new System.Drawing.Size(125, 21);
            this.Ratingscombobox.TabIndex = 0;
            this.Ratingscombobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(470, 155);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(176, 79);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // District
            // 
            this.District.FormattingEnabled = true;
            this.District.Location = new System.Drawing.Point(596, 272);
            this.District.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.District.Name = "District";
            this.District.Size = new System.Drawing.Size(71, 21);
            this.District.TabIndex = 8;
            // 
            // SaveLocation
            // 
            this.SaveLocation.Location = new System.Drawing.Point(693, 272);
            this.SaveLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveLocation.Name = "SaveLocation";
            this.SaveLocation.Size = new System.Drawing.Size(64, 58);
            this.SaveLocation.TabIndex = 9;
            this.SaveLocation.Text = "Save Location";
            this.SaveLocation.UseVisualStyleBackColor = true;
            this.SaveLocation.Click += new System.EventHandler(this.SaveLocation_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CitycomboBox
            // 
            this.CitycomboBox.FormattingEnabled = true;
            this.CitycomboBox.Location = new System.Drawing.Point(323, 272);
            this.CitycomboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CitycomboBox.Name = "CitycomboBox";
            this.CitycomboBox.Size = new System.Drawing.Size(104, 21);
            this.CitycomboBox.TabIndex = 10;
            this.CitycomboBox.SelectedIndexChanged += new System.EventHandler(this.CitycomboBox_SelectedIndexChanged);
            // 
            // AreacomboBox
            // 
            this.AreacomboBox.FormattingEnabled = true;
            this.AreacomboBox.Location = new System.Drawing.Point(470, 271);
            this.AreacomboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AreacomboBox.Name = "AreacomboBox";
            this.AreacomboBox.Size = new System.Drawing.Size(104, 21);
            this.AreacomboBox.TabIndex = 11;
            this.AreacomboBox.SelectedIndexChanged += new System.EventHandler(this.AreacomboBox_SelectedIndexChanged);
            // 
            // Garages_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 488);
            this.Controls.Add(this.AreacomboBox);
            this.Controls.Add(this.CitycomboBox);
            this.Controls.Add(this.SaveLocation);
            this.Controls.Add(this.District);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Ratingscombobox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Garages_List);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.Rate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Garages_Options";
            this.Text = "Garages_Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Garages_Options_FormClosed);
            this.Load += new System.EventHandler(this.Garages_Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Rate;
        private System.Windows.Forms.Button Review;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Garages_List;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox Ratingscombobox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox District;
        private System.Windows.Forms.Button SaveLocation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox CitycomboBox;
        private System.Windows.Forms.ComboBox AreacomboBox;
    }
}