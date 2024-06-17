using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proiect
{
    public partial class Grafice : Form
    {
        private MainMenu mainMenu;
        public Grafice()
        {
            InitializeComponent();
        }

        public Grafice(MainMenu menu)
        {
            InitializeComponent();
            this.mainMenu = menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void PieChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            Series series = new Series
            {
                Name = "Suma asigurarilor",
                ChartType = SeriesChartType.Pie
            };
            chart1.Series.Add(series);

            foreach (Client client in mainMenu.Clients)
            {
                float total = client.costTotalAsigurari();
                if(total > 0) series.Points.AddXY(client.NumePrenume, total);
            }

            chartArea.AxisX.Title = "Client";
            chartArea.AxisY.Title = "Suma asigurarilor";
        }
        private void LinesChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            Series series = new Series
            {
                Name = "Raport Varsta-Salariu",
                ChartType = SeriesChartType.Line
            };
            chart1.Series.Add(series);

            if (mainMenu != null && mainMenu.Clients != null)
            {
                List<Client> sortedClients = mainMenu.Clients.OrderBy(c => c.Varsta).ToList();

                foreach (Client client in sortedClients)
                {
                    series.Points.AddXY(client.Varsta, client.Salariu);
                }
            }

            chartArea.AxisX.Title = "Varsta";
            chartArea.AxisY.Title = "Salariu";
        }

        private void BarChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chart1.ChartAreas.Add(chartArea);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            Series series = new Series
            {
                Name = "Suma asigurarilor",
                ChartType = SeriesChartType.Bar
            };
            chart1.Series.Add(series);

            foreach (Client client in mainMenu.Clients)
            {
                if (client.Asigurari.Count > 0)
                {
                    float totalInsurance = client.costTotalAsigurari();
                    series.Points.AddXY(client.NumePrenume, totalInsurance);
                }
            }

            chartArea.AxisX.Title = "Client";
            chartArea.AxisY.Title = "Suma asigurarilor";
        }

        private void CopiazaInClipboard()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, ChartImageFormat.Jpeg);
                Bitmap bmp = new Bitmap(ms);
                Clipboard.SetImage(bmp);
            }
            MessageBox.Show("Graficul a fost salvat in clipboard!");
        }

        private void btnGraficLiniar_Click(object sender, EventArgs e)
        {
            LinesChart();
        }

        private void btnGraficPie_Click(object sender, EventArgs e)
        {
            PieChart();
        }

        private void btnGraficBars_Click(object sender, EventArgs e)
        {
            BarChart();
        }

        private void btnCopiaza_Click(object sender, EventArgs e)
        {
            CopiazaInClipboard();
        }
    }
}
