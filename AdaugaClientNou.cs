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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect
{
    public partial class AdaugaClientNou : Form
    {
        private MainMenu mainMenu;
        public AdaugaClientNou(MainMenu menu)
        {
            InitializeComponent();
            this.mainMenu = menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void adaugaClientInBD(Client c)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int newIdClient = 1;
                string getMaxIdQuery = "SELECT ISNULL(MAX(Idclient), 0) + 1 FROM Client";
                using (SqlCommand getMaxIdCommand = new SqlCommand(getMaxIdQuery, connection))
                {
                    newIdClient = (int)getMaxIdCommand.ExecuteScalar();
                }


                string query = "INSERT INTO Client (Idclient, numePrenume, varsta, sex, salariu, mail, telefon) VALUES (@Idclient, @numePrenume, @varsta, @sex, @salariu, @mail, @telefon)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Idclient", newIdClient);
                    command.Parameters.AddWithValue("@numePrenume", c.NumePrenume);
                    command.Parameters.AddWithValue("@varsta", c.Varsta);
                    command.Parameters.AddWithValue("@sex", c.Sex.ToString());
                    command.Parameters.AddWithValue("@salariu", c.Salariu);
                    command.Parameters.AddWithValue("@mail", c.MailTelefon[0]);
                    command.Parameters.AddWithValue("@telefon", c.MailTelefon[1]);

                    command.ExecuteNonQuery();
                    }
            }
            
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbNumePrenume.Text) && !string.IsNullOrWhiteSpace(tbVarsta.Text) && !string.IsNullOrWhiteSpace(tbSalariu.Text) && !string.IsNullOrWhiteSpace(tbMail.Text) && !string.IsNullOrWhiteSpace(tbMail.Text) && !string.IsNullOrWhiteSpace(tbTelefon.Text))
            {
                string[] mailTel = new string[2];
                mailTel[0] = tbMail.Text;
                mailTel[1] = tbTelefon.Text;
                List<Asigurari> a = new List<Asigurari>();
                char sex;
                if (rbM.Checked == true) sex = 'M';
                else sex = 'F';
                Client c = new Client(Convert.ToSingle(tbSalariu.Text), mailTel, a, tbNumePrenume.Text, Convert.ToInt32(tbVarsta.Text), sex);
                mainMenu.Clients.Add(c);
                adaugaClientInBD(c);
                MessageBox.Show("Clientul a fost adaugat cu succes!");
                tbMail.Clear();
                tbTelefon.Clear();
                tbSalariu.Clear();
                tbNumePrenume.Clear();
                tbVarsta.Clear();

            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbNumePrenume.Text))
                {
                    errorProvider1.SetError(tbNumePrenume, "Nu poate fi lăsat gol!");
                } else errorProvider1.Clear();
                if (string.IsNullOrWhiteSpace(tbVarsta.Text))
                {
                    errorProvider2.SetError(tbVarsta, "Nu poate fi lăsat gol!");
                } else errorProvider2.Clear();
                if (string.IsNullOrWhiteSpace(tbSalariu.Text))
                {
                    errorProvider3.SetError(tbSalariu, "Nu poate fi lăsat gol!");
                } else errorProvider3.Clear();
                if (string.IsNullOrWhiteSpace(tbMail.Text))
                {
                    errorProvider4.SetError(tbMail, "Nu poate fi lăsat gol!");
                }
                else if (!(tbMail.Text.Contains("@") && tbMail.Text.Contains(".com"))) errorProvider4.SetError(tbMail, "Introduceti o adresa de mail valida!");
                else errorProvider4.Clear();
                if (string.IsNullOrWhiteSpace(tbTelefon.Text))
                {
                    errorProvider5.SetError(tbTelefon, "Nu poate fi lăsat gol!");
                } else errorProvider5.Clear();
            }
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if(rbF.Checked == true) { rbM.Checked = false; }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true) { rbF.Checked = false; }
        }

        //private void tbSalariu_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void tbTelefon_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void tbVarsta_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }
        //}

      
    }
}
