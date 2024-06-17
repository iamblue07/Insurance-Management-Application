using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class MainMenu : Form
    {
        List<Client> clients = new List<Client>();
       
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal List<Client> Clients { get => clients; set => clients = value; }

        private void loadClients()
        {
            List<Asigurari> asigurariToate = new List<Asigurari>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string clientQuery = "SELECT Idclient, numePrenume, varsta, sex, salariu, mail, telefon FROM Client";
                SqlCommand clientCommand = new SqlCommand(clientQuery, connection);
                using (SqlDataReader clientReader = clientCommand.ExecuteReader())
                {
                    while (clientReader.Read())
                    {
                        int idClient = clientReader.GetInt32(0);
                        string numePrenume = clientReader.IsDBNull(1) ? null : clientReader.GetString(1);
                        int varsta = clientReader.GetInt32(2);
                        char sex = clientReader.IsDBNull(3) ? ' ' : clientReader.GetString(3)[0];
                        float salariu = clientReader.IsDBNull(4) ? 0 : (float)clientReader.GetDouble(4);
                        string mail = clientReader.IsDBNull(5) ? null : clientReader.GetString(5);
                        string telefon = clientReader.IsDBNull(6) ? null : clientReader.GetString(6);

                        List<Asigurari> asigurari = new List<Asigurari>();
                        string[] mailTelefon = new string[2];
                        mailTelefon[0] = mail;
                        mailTelefon[1] = telefon;
                        Client nou = new Client(salariu, mailTelefon, asigurari, numePrenume, varsta, sex);
                        nou.Idclient = idClient;
                        clients.Add(nou);
                    }
                }

                string asigurariQuery = "SELECT IdAsigurare, idClient, tipAsigurare, denumireAsigurare, sumaAsigurata, inceputValabilitate, finalValabilitate, esteValabila FROM Asigurari";
                SqlCommand asigurariCommand = new SqlCommand(asigurariQuery, connection);
                using (SqlDataReader asigurariReader = asigurariCommand.ExecuteReader())
                {
                    while (asigurariReader.Read())
                    {
                        int idAsigurare = asigurariReader.GetInt32(0);
                        int idClient = asigurariReader.GetInt32(1);
                        string tipAsigurare = asigurariReader.IsDBNull(2) ? null : asigurariReader.GetString(2);
                        string denumireAsigurare = asigurariReader.IsDBNull(3) ? null : asigurariReader.GetString(3);
                        float sumaAsigurata = asigurariReader.IsDBNull(4) ? 0 : (float)asigurariReader.GetDouble(4);
                        DateTime inceputValabilitate = asigurariReader.IsDBNull(5) ? DateTime.MinValue : asigurariReader.GetDateTime(5);
                        DateTime finalValabilitate = asigurariReader.IsDBNull(6) ? DateTime.MinValue : asigurariReader.GetDateTime(6);
                        bool esteValabila = asigurariReader.IsDBNull(7) ? false : asigurariReader.GetBoolean(7);

                        Asigurari asigurare = new Asigurari(tipAsigurare, idClient, denumireAsigurare, sumaAsigurata, inceputValabilitate, finalValabilitate);
                        asigurariToate.Add(asigurare);
                    }
                }
                foreach(Client c in clients)
                {
                    foreach(Asigurari a in asigurariToate)
                    {
                        if(c.Idclient == a.IdClient)
                        {
                            c.Asigurari.Add(a);
                        }
                    }
                }
            }
        }

        public MainMenu()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["LoginForm"].Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            loadClients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AfiseazaClienti afCl = new AfiseazaClienti(this);
            afCl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcceseazaUnClient acceseazaUnClient = new AcceseazaUnClient(this);
            acceseazaUnClient.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modifica_Date modifica_Date = new Modifica_Date(this);
            modifica_Date.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdaugaClientNou adaugaClientNou = new AdaugaClientNou(this);
            adaugaClientNou.Show();
        }

        private void btnGrafice_Click(object sender, EventArgs e)
        {
            Grafice grafice = new Grafice(this);
            grafice.Show();
        }
        
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach(Client c in clients)
                    {
                        sw.WriteLine(c.NumePrenume);
                        sw.WriteLine(c.Varsta.ToString());
                        sw.WriteLine(c.Sex.ToString());
                        sw.WriteLine(c.Salariu.ToString());
                        sw.WriteLine(c.MailTelefon[0]);
                        sw.WriteLine(c.MailTelefon[1]);
                        sw.Write(c.Asigurari.Count);
                        foreach(Asigurari a in c.Asigurari)
                        {
                            sw.Write(Environment.NewLine);
                            sw.WriteLine(a.TipAsigurare);
                            sw.WriteLine(a.IdClient);
                            sw.WriteLine(a.DenumireAsigurare);
                            sw.WriteLine(a.SumaAsigurata.ToString());
                            sw.WriteLine(a.InceputValabilitate.Day.ToString() + "." + a.InceputValabilitate.Month.ToString() + "." + a.InceputValabilitate.Year.ToString());
                            sw.Write(a.FinalValabilitate.Day.ToString() + "." + a.FinalValabilitate.Month.ToString() + "." + a.FinalValabilitate.Year.ToString());
                        }
                        if (clients.Count != clients.IndexOf(c) + 1) sw.Write(Environment.NewLine);
                    }
                }
                MessageBox.Show("Salvarea a avut loc cu succes!");
            }
        }

        private void loadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                clients.Clear();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string nume = sr.ReadLine();
                        int varsta = Convert.ToInt32(sr.ReadLine());
                        char sex = Convert.ToChar(sr.ReadLine());
                        float salariu = Convert.ToSingle(sr.ReadLine());
                        string[] mailTel = new string[2];
                        mailTel[0] = sr.ReadLine();
                        mailTel[1] = sr.ReadLine();
                        int nrAsigurari = Convert.ToInt32(sr.ReadLine());
                        List<Asigurari> Asg = new List<Asigurari>();
                        for (int i = 0; i < nrAsigurari; i++)
                        {
                            string tip = sr.ReadLine();
                            int idC = Convert.ToInt32(sr.ReadLine());
                            string denumire = sr.ReadLine();
                            float valoare = Convert.ToSingle(sr.ReadLine());
                            DateTime inceput = Convert.ToDateTime(sr.ReadLine());
                            DateTime final = Convert.ToDateTime(sr.ReadLine());
                            Asigurari a = new Asigurari(tip, idC, denumire, valoare, inceput, final);
                            Asg.Add(a);
                        }
                        Client c = new Client(salariu, mailTel, Asg, nume, varsta, sex);
                        clients.Add(c);
                    }
                }
                MessageBox.Show("File Opened successfully!");
            }
        }

       
    }
}
