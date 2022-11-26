
namespace WebServiceGyak05
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chartRateData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtPickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtPickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRateData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(717, 398);
            this.dataGridView1.TabIndex = 0;
            // 
            // chartRateData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRateData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRateData.Legends.Add(legend1);
            this.chartRateData.Location = new System.Drawing.Point(792, 79);
            this.chartRateData.Name = "chartRateData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRateData.Series.Add(series1);
            this.chartRateData.Size = new System.Drawing.Size(569, 398);
            this.chartRateData.TabIndex = 1;
            this.chartRateData.Text = "chart1";
            // 
            // dtPickerStartDate
            // 
            this.dtPickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerStartDate.Location = new System.Drawing.Point(40, 38);
            this.dtPickerStartDate.Name = "dtPickerStartDate";
            this.dtPickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtPickerStartDate.TabIndex = 2;
            this.dtPickerStartDate.ValueChanged += new System.EventHandler(this.dtPickerStartDate_ValueChanged);
            // 
            // dtPickerEndDate
            // 
            this.dtPickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerEndDate.Location = new System.Drawing.Point(246, 39);
            this.dtPickerEndDate.Name = "dtPickerEndDate";
            this.dtPickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtPickerEndDate.TabIndex = 3;
            this.dtPickerEndDate.ValueChanged += new System.EventHandler(this.dtPickerEndDate_ValueChanged);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "EUR"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(481, 39);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCurrency.TabIndex = 4;
            this.comboBoxCurrency.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrency_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 503);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.dtPickerEndDate);
            this.Controls.Add(this.dtPickerStartDate);
            this.Controls.Add(this.chartRateData);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRateData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRateData;
        private System.Windows.Forms.DateTimePicker dtPickerStartDate;
        private System.Windows.Forms.DateTimePicker dtPickerEndDate;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
    }
}

