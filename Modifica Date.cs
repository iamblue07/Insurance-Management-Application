using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Modifica_Date : Form
    {
        private MainMenu mainmenu;

        public Modifica_Date(MainMenu menu)
        {
            InitializeComponent();
            this.mainmenu = menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        public static void addAsigurareInBD(Asigurari nou)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Asigurari (IdAsigurare, idClient, tipAsigurare, denumireAsigurare, sumaAsigurata, inceputValabilitate, finalValabilitate, esteValabila) " +
                               "VALUES (@IdAsigurare, @idClient, @tipAsigurare, @denumireAsigurare, @sumaAsigurata, @inceputValabilitate, @finalValabilitate, @esteValabila)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAsigurare", nou.IdAsigurare);
                    command.Parameters.AddWithValue("@idClient", nou.IdClient);
                    command.Parameters.AddWithValue("@tipAsigurare", nou.TipAsigurare ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@denumireAsigurare", nou.DenumireAsigurare ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@sumaAsigurata", nou.SumaAsigurata);
                    command.Parameters.AddWithValue("@inceputValabilitate", nou.InceputValabilitate);
                    command.Parameters.AddWithValue("@finalValabilitate", nou.FinalValabilitate);
                    command.Parameters.AddWithValue("@esteValabila", nou.EsteValabila);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateAsigurare(int idAsigurare, float sumaAsigurata, DateTime inceputValabilitate, DateTime finalValabilitate, bool esteValabila)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Asigurari SET sumaAsigurata = @sumaAsigurata, inceputValabilitate = @inceputValabilitate, finalValabilitate = @finalValabilitate, esteValabila = @esteValabila WHERE IdAsigurare = @IdAsigurare";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAsigurare", idAsigurare);
                    command.Parameters.AddWithValue("@sumaAsigurata", sumaAsigurata);
                    command.Parameters.AddWithValue("@inceputValabilitate", inceputValabilitate);
                    command.Parameters.AddWithValue("@finalValabilitate", finalValabilitate);
                    command.Parameters.AddWithValue("@esteValabila", esteValabila);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static void DeleteAsigurare(int idAsigurare)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Asigurari WHERE IdAsigurare = @IdAsigurare";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAsigurare", idAsigurare);
                    command.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateNume(string numeV, string numeN)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Client SET numePrenume = @newName WHERE numePrenume = @oldName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newName", numeN);
                    command.Parameters.AddWithValue("@oldName", numeV);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateSalariu(string nume, float salariuN)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Client SET salariu = @salariuN WHERE numePrenume = @nume";
                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@salariuN", salariuN);
                    command.Parameters.AddWithValue("@nume", nume);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateMail(string nume, string mailN)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Client SET mail = @mailN WHERE numePrenume = @nume";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mailN", mailN);
                    command.Parameters.AddWithValue("@nume", nume);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static void UpdateTelefon(string nume, string telN)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Client SET telefon = @telN WHERE numePrenume = @nume";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@telN", telN);
                    command.Parameters.AddWithValue("@nume", nume);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnNumeNou_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbNumeNou.Text)) errorProvider1.SetError(tbNumeNou, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider1.Clear();
                    bool gasit = false;
                    foreach (Client c in mainmenu.Clients)
                    {
                        if (c.NumePrenume == tbNumeClient.Text && gasit == false)
                        {
                            gasit = true;
                            UpdateNume(c.NumePrenume, tbNumeNou.Text);
                            c.NumePrenume = tbNumeNou.Text;
                           
                            MessageBox.Show("Numele a fost modificat cu succes!");
                        }
                    }
                    if (gasit == false)
                    {
                        MessageBox.Show("Eroare: Clientul nu a fost gasit!");
                    }
                    else
                    {
                        tbNumeClient.Clear();
                        tbNumeNou.Clear();
                    }
                }
            }
        }

        private void btnSalariuNou_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbSalariuNou.Text)) errorProvider2.SetError(tbSalariuNou, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider2.Clear();
                    bool gasit = false;
                    foreach (Client c in mainmenu.Clients)
                    {
                        if (c.NumePrenume == tbNumeClient.Text && gasit == false)
                        {
                            gasit = true;
                            UpdateSalariu(c.NumePrenume, Convert.ToSingle(tbSalariuNou.Text));
                            c.Salariu = Convert.ToSingle(tbSalariuNou.Text);
                            MessageBox.Show("Salariul a fost modificat cu succes!");
                        }
                    }
                    if (gasit == false)
                    {
                        MessageBox.Show("Eroare: Clientul nu a fost gasit!");
                    }
                    else
                    {
                        tbNumeClient.Clear();
                        tbSalariuNou.Clear();
                    }
                }
            }
        }

        private void btnMailNou_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbMailNou.Text)) errorProvider3.SetError(tbMailNou, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider3.Clear();
                    bool gasit = false;
                    foreach (Client c in mainmenu.Clients)
                    {
                        if (c.NumePrenume == tbNumeClient.Text && gasit == false)
                        {
                            gasit = true;
                            UpdateMail(c.NumePrenume, tbMailNou.Text);
                            c.MailTelefon[0] = tbMailNou.Text;
                            MessageBox.Show("Mailul a fost modificat cu succes!");
                        }
                    }
                    if (gasit == false)
                    {
                        MessageBox.Show("Eroare: Clientul nu a fost gasit!");
                    }
                    else
                    {
                        tbNumeClient.Clear();
                        tbMailNou.Clear();
                    }
                }
            }
        }

        private void btnTelefonNou_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbTelefonNou.Text)) errorProvider4.SetError(tbTelefonNou, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider4.Clear();
                    bool gasit = false;
                    foreach (Client c in mainmenu.Clients)
                    {
                        if (c.NumePrenume == tbNumeClient.Text && gasit == false)
                        {
                            gasit = true;
                            UpdateTelefon(c.NumePrenume, tbTelefonNou.Text);
                            c.MailTelefon[1] = tbTelefonNou.Text;
                            MessageBox.Show("Numarul de telefon a fost modificat cu succes!");
                        }
                    }
                    if (gasit == false)
                    {
                        MessageBox.Show("Eroare: Clientul nu a fost gasit!");
                    }
                    else
                    {
                        tbNumeClient.Clear();
                        tbTelefonNou.Clear();
                    }
                }
            }
        }

        private void btnModificaAsigurare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbTipAsigurare.Text)) errorProvider5.SetError(tbTipAsigurare, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider5.Clear(); 
                    if (string.IsNullOrWhiteSpace(tbDenumireAsigurare.Text)) errorProvider6.SetError(tbDenumireAsigurare, "Nu poate fi lasat gol!");
                    else
                    {
                        errorProvider6.Clear(); 
                        if (string.IsNullOrWhiteSpace(tbValoareAsigurata.Text)) errorProvider7.SetError(tbValoareAsigurata, "Nu poate fi lasat gol!");
                        else
                        {
                            errorProvider7.Clear();
                            bool gasitAsigurare = false;
                            bool gasitClient = false;
                            foreach (Client c in mainmenu.Clients)
                            {
                                if (tbNumeClient.Text == c.NumePrenume)
                                {
                                    gasitClient = true;
                                    foreach (Asigurari a in c.Asigurari)
                                    {
                                        if (a.TipAsigurare == tbTipAsigurare.Text && a.DenumireAsigurare == tbDenumireAsigurare.Text && gasitAsigurare == false)
                                        {
                                            gasitAsigurare = true;
                                            a.InceputValabilitate = dtpInceputNou.Value;
                                            a.FinalValabilitate = dtpFinalNou.Value;
                                            a.SumaAsigurata = Convert.ToSingle(tbValoareAsigurata.Text);
                                            if (a.FinalValabilitate >= DateTime.Now && a.InceputValabilitate <= DateTime.Now)
                                            {
                                                a.EsteValabila = true;
                                            }
                                            else
                                            {
                                                a.EsteValabila = false;
                                            }
                                            UpdateAsigurare(a.IdAsigurare, a.SumaAsigurata, a.InceputValabilitate, a.FinalValabilitate, a.EsteValabila);
                                            MessageBox.Show("Actualizarea s-a realizat cu succes!");
                                        }
                                    }
                                    if (gasitAsigurare == false)
                                    {
                                        MessageBox.Show("Eroare: Asigurarea nu a fost gasita pentru clientul " + tbNumeClient.Text + ".Verificati denumirea si tipul asigurarii!");
                                    }
                                    else
                                    {
                                        tbValoareAsigurata.Clear();
                                        tbTipAsigurare.Clear();
                                        tbDenumireAsigurare.Clear();
                                        tbNumeClient.Clear();
                                    }
                                }
                                
                            }
                            if (gasitClient == false)
                            {
                                MessageBox.Show("Eroare: Clientul nu a fost gasit in baza de date!");
                            }
                        }
                    }
                }
            }
        }

        private void btnAdaugaAsigurare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbTipAsigurare.Text)) errorProvider5.SetError(tbTipAsigurare, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider5.Clear(); 
                    if (string.IsNullOrWhiteSpace(tbDenumireAsigurare.Text)) errorProvider6.SetError(tbDenumireAsigurare, "Nu poate fi lasat gol!");
                    else
                    {
                        errorProvider6.Clear(); 
                        if (string.IsNullOrWhiteSpace(tbValoareAsigurata.Text)) errorProvider7.SetError(tbValoareAsigurata, "Nu poate fi lasat gol!");
                        else
                        {
                            errorProvider7.Clear();
                            int idClient = 0;
                           bool gasitClient = false;
                            foreach (Client c in mainmenu.Clients)
                            {
                                if (tbNumeClient.Text == c.NumePrenume && gasitClient == false)
                                {
                                    gasitClient = true;
                                    idClient = c.Idclient;
                                    Asigurari aux = new Asigurari(tbTipAsigurare.Text, idClient, tbDenumireAsigurare.Text, Convert.ToSingle(tbValoareAsigurata.Text), dtpInceputNou.Value, dtpFinalNou.Value);
                                    addAsigurareInBD(aux);
                                    c.Asigurari.Add(aux);
                                    MessageBox.Show("Noua asigurare a fost adaugata!");
                                }
                            }
                            if (gasitClient == false)
                            {
                                MessageBox.Show("Clientul nu a fost gasit in baza de date!");
                            }
                            else
                            {
                                tbNumeClient.Clear();
                                tbTipAsigurare.Clear();
                                tbDenumireAsigurare.Clear();
                                tbValoareAsigurata.Clear();
                            }
                        }
                    }
                }
            }
        }

        private void btnStergeAsigurare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNumeClient.Text)) errorProviderNumePrenume.SetError(tbNumeClient, "Nu poate fi lasat gol!");
            else
            {
                errorProviderNumePrenume.Clear();
                if (string.IsNullOrWhiteSpace(tbTipAsigurare.Text)) errorProvider5.SetError(tbTipAsigurare, "Nu poate fi lasat gol!");
                else
                {
                    errorProvider5.Clear(); 
                    if (string.IsNullOrWhiteSpace(tbDenumireAsigurare.Text)) errorProvider6.SetError(tbDenumireAsigurare, "Nu poate fi lasat gol!");
                    else
                    {
                        errorProvider6.Clear();
                        bool gasitAsigurare = false;
                        bool gasitClient = false;
                        int pozitieDeSters = 0;
                        foreach (Client c in mainmenu.Clients)
                        {
                            if (tbNumeClient.Text == c.NumePrenume)
                            {
                                gasitClient = true;

                                foreach (Asigurari a in c.Asigurari)
                                {
                                    if (a.TipAsigurare == tbTipAsigurare.Text && a.DenumireAsigurare == tbDenumireAsigurare.Text && gasitAsigurare == false)
                                    {
                                        gasitAsigurare = true;
                                        pozitieDeSters = c.Asigurari.IndexOf(a);
                                        DeleteAsigurare(a.IdAsigurare);
                                        MessageBox.Show("Stergerea a fost realizata cu succes!");
                                    }
                                }
                                if (gasitAsigurare == false)
                                {
                                    MessageBox.Show("Eroare: Asigurarea nu a fost gasita pentru clientul " + tbNumeClient.Text + ".Verificati denumirea si tipul asigurarii!");
                                }
                                else
                                {
                                    c.Asigurari.RemoveAt(pozitieDeSters);
                                    tbNumeClient.Clear();
                                    tbTipAsigurare.Clear();
                                    tbDenumireAsigurare.Clear();
                                    tbValoareAsigurata.Clear();
                                }
                            }
                        }
                        if (gasitClient == false)
                        {
                            MessageBox.Show("Eroare: Clientul nu a fost gasit in baza de date!");
                        }
                    }
                }
            }
        }

        private void tbValoareAsigurata_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) 
            { 
                e.Handled = true;
            }
        }

        private void tbSalariuNou_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tbTelefonNou_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}

        