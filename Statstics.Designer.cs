namespace Parking_Finder
{
    partial class Statstics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisY.Title = "Monthly Hours";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-7, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "My Monthly Worked Hours";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Average Worked Hours";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(426, 361);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart";
            title1.DockedToChartArea = "ChartArea1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = " Performance";
            title1.Position.Auto = false;
            title1.Position.Height = 4.538573F;
            title1.Position.Width = 33.21841F;
            title1.Position.X = 17.36849F;
            title1.Position.Y = 1.685162F;
            title1.Text = "Performance";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reservation Stat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart2
            // 
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.AxisX.Title = "pl";
            chartArea2.AxisY.Title = "Occupied";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(413, 0);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 2;
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(256, 307);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Percentage Occupied";
            this.chart2.Titles.Add(title2);
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(419, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Employee Performance";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Statstics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(663, 362);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "Statstics";
            this.Text = "Statstics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Statstics_FormClosed);
            this.Load += new System.EventHandler(this.Statstics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button2;




    }
}