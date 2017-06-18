namespace Parking_Finder
{
    partial class cancel_reason
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
            this.label1 = new System.Windows.Forms.Label();
            this.reasonofcancel = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "please wite the reason for cancellation";
            // 
            // reasonofcancel
            // 
            this.reasonofcancel.Location = new System.Drawing.Point(81, 105);
            this.reasonofcancel.Name = "reasonofcancel";
            this.reasonofcancel.Size = new System.Drawing.Size(274, 110);
            this.reasonofcancel.TabIndex = 1;
            this.reasonofcancel.Text = "";
            this.reasonofcancel.TextChanged += new System.EventHandler(this.reasonofcancel_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel_reason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reasonofcancel);
            this.Controls.Add(this.label1);
            this.Name = "cancel_reason";
            this.Text = "cancel_reason";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.cancel_reason_FormClosed);
            this.Load += new System.EventHandler(this.cancel_reason_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox reasonofcancel;
        private System.Windows.Forms.Button button1;
    }
}