namespace Proiect
{
    partial class Grafice
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnGraficLiniar = new System.Windows.Forms.Button();
            this.btnGraficPie = new System.Windows.Forms.Button();
            this.btnGraficBars = new System.Windows.Forms.Button();
            this.btnCopiaza = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(211, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 529);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 3);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1030, 523);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnGraficLiniar
            // 
            this.btnGraficLiniar.BackgroundImage = global::Proiect.Properties.Resources.button_background;
            this.btnGraficLiniar.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficLiniar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGraficLiniar.Location = new System.Drawing.Point(48, 69);
            this.btnGraficLiniar.Name = "btnGraficLiniar";
            this.btnGraficLiniar.Size = new System.Drawing.Size(99, 51);
            this.btnGraficLiniar.TabIndex = 1;
            this.btnGraficLiniar.Text = "Grafic liniar";
            this.btnGraficLiniar.UseVisualStyleBackColor = true;
            this.btnGraficLiniar.Click += new System.EventHandler(this.btnGraficLiniar_Click);
            // 
            // btnGraficPie
            // 
            this.btnGraficPie.BackgroundImage = global::Proiect.Properties.Resources.button_background;
            this.btnGraficPie.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficPie.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGraficPie.Location = new System.Drawing.Point(48, 149);
            this.btnGraficPie.Name = "btnGraficPie";
            this.btnGraficPie.Size = new System.Drawing.Size(99, 51);
            this.btnGraficPie.TabIndex = 2;
            this.btnGraficPie.Text = "Grafic pie";
            this.btnGraficPie.UseVisualStyleBackColor = true;
            this.btnGraficPie.Click += new System.EventHandler(this.btnGraficPie_Click);
            // 
            // btnGraficBars
            // 
            this.btnGraficBars.BackgroundImage = global::Proiect.Properties.Resources.button_background;
            this.btnGraficBars.Font = new System.Drawing.Font("Myanmar Text", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficBars.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGraficBars.Location = new System.Drawing.Point(48, 230);
            this.btnGraficBars.Name = "btnGraficBars";
            this.btnGraficBars.Size = new System.Drawing.Size(99, 51);
            this.btnGraficBars.TabIndex = 3;
            this.btnGraficBars.Text = "Grafic bars";
            this.btnGraficBars.UseVisualStyleBackColor = true;
            this.btnGraficBars.Click += new System.EventHandler(this.btnGraficBars_Click);
            // 
            // btnCopiaza
            // 
            this.btnCopiaza.BackgroundImage = global::Proiect.Properties.Resources.button_background;
            this.btnCopiaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiaza.Location = new System.Drawing.Point(48, 307);
            this.btnCopiaza.Name = "btnCopiaza";
            this.btnCopiaza.Size = new System.Drawing.Size(99, 60);
            this.btnCopiaza.TabIndex = 4;
            this.btnCopiaza.Text = "Copiaza In Clipboard";
            this.btnCopiaza.UseVisualStyleBackColor = true;
            this.btnCopiaza.Click += new System.EventHandler(this.btnCopiaza_Click);
            // 
            // Grafice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proiect.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(1256, 553);
            this.Controls.Add(this.btnCopiaza);
            this.Controls.Add(this.btnGraficBars);
            this.Controls.Add(this.btnGraficPie);
            this.Controls.Add(this.btnGraficLiniar);
            this.Controls.Add(this.panel1);
            this.Name = "Grafice";
            this.Text = "Grafice";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnGraficLiniar;
        private System.Windows.Forms.Button btnGraficPie;
        private System.Windows.Forms.Button btnGraficBars;
        private System.Windows.Forms.Button btnCopiaza;
    }
}