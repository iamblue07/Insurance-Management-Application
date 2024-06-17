using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Proiect
{
    public partial class AcceseazaUnClient : Form
    {
        private MainMenu mainmenu;
        public AcceseazaUnClient(MainMenu mainmenu)
        {
            InitializeComponent();
            this.mainmenu = mainmenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        protected internal void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProvider1.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProvider1.Clear();
                string nume = tbNumeClient.Text;
                string s = "";
                foreach (Client c in mainmenu.Clients)
                {
                    if (c.NumePrenume.Contains(nume) && nume != " ")
                    {
                        s += "Nume: " + c.NumePrenume + Environment.NewLine;
                        s += "Vârstă: " + c.Varsta.ToString() + Environment.NewLine;
                        s += "Sex: " + c.Sex.ToString() + Environment.NewLine;
                        s += "ID Client: " + c.Idclient.ToString() + Environment.NewLine;
                        s += "Salariu: " + c.Salariu.ToString() + Environment.NewLine;
                        s += "Mail: " + c.MailTelefon[0] + Environment.NewLine;
                        s += "Telefon: " + c.MailTelefon[1] + Environment.NewLine;
                        if (c.Asigurari.Count == 0) s += "Clientul nu are asigurari." + Environment.NewLine;
                        else
                        {
                            s += "Asigurari:" + Environment.NewLine;
                            foreach (Asigurari a in c.Asigurari)
                            {
                                s += "Tip Asigurare: " + a.TipAsigurare + Environment.NewLine;
                                s += "Denumire Asigurare: " + a.DenumireAsigurare.ToString() + Environment.NewLine;
                                s += "Valoare: " + a.SumaAsigurata.ToString() + Environment.NewLine;
                                s += "Inceput valabilitate: " + a.InceputValabilitate.ToString().Substring(0, a.InceputValabilitate.ToString().IndexOf(' ')) + Environment.NewLine;
                                s += "Final valabilitate: " + a.FinalValabilitate.ToString().Substring(0, a.FinalValabilitate.ToString().IndexOf(' ')) + Environment.NewLine + Environment.NewLine;
                            }
                        }
                    }
                }
                if (s == "") s += "Clientul nu a fost gasit!";
                tbClientGasit.Text = s;
            }
        }



        protected internal void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string text = tbClientGasit.Text;
            if (text != "")
            {
                Font printFont = new Font("Arial", 12);
                RectangleF printArea = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                e.Graphics.DrawString(text, printFont, Brushes.Black, printArea);
            }
            else
                MessageBox.Show("Eroare: nu a fost gasit nici un client!");
        }

        protected internal void button2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }



        protected internal static void WriteClientDataToXML(Client client)
        {
            XElement clientElement = new XElement("Client",
                new XElement("Idclient", client.Idclient),
                new XElement("NumePrenume", client.NumePrenume),
                new XElement("Varsta", client.Varsta),
                new XElement("Sex", client.Sex),
                new XElement("Salariu", client.Salariu),
                new XElement("Mail", client.MailTelefon[0]),
                new XElement("Telefon", client.MailTelefon[1]),
                new XElement("Asigurari",
                    client.Asigurari.Select(a =>
                        new XElement("Asigurare",
                            new XElement("TipAsigurare", a.TipAsigurare),
                            new XElement("DenumireAsigurare", a.DenumireAsigurare),
                            new XElement("SumaAsigurata", a.SumaAsigurata),
                            new XElement("InceputValabilitate", a.InceputValabilitate),
                            new XElement("FinalValabilitate", a.FinalValabilitate),
                            new XElement("EsteValabila", a.EsteValabila)
                        )
                    )
                )
            );

            XDocument doc = new XDocument(new XElement("Clients", clientElement));
            string denumire_fisier = client.NumePrenume.ToString() + ".xml";
            doc.Save(denumire_fisier);
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProvider1.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProvider1.Clear();
                string nume = tbNumeClient.Text;
                foreach (Client c in mainmenu.Clients)
                {
                    if (c.NumePrenume.Contains(nume) && nume != " ")
                    {
                        WriteClientDataToXML(c);
                    }
                }
                MessageBox.Show("Salvarea XML a avut loc cu succes!");
            }
        }
    }
}
