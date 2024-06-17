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
using System.Xml.Linq;

namespace Proiect
{
    public partial class AfiseazaClienti : Form
    {
        private MainMenu mainMenu;
        public AfiseazaClienti(MainMenu mainmenu)
        {
            this.mainMenu = mainmenu;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AfiseazaClienti_Load(object sender, EventArgs e)
        {
            foreach(Client c in mainMenu.Clients)
            {
                TreeNode nod = new TreeNode(c.NumePrenume);
                nod.Nodes.Add("ID Client: " + c.Idclient.ToString());
                nod.Nodes.Add("Vârstă: " + c.Varsta.ToString());
                nod.Nodes.Add("Sex: " + c.Sex.ToString());
                nod.Nodes.Add("Salariu: " + c.Salariu.ToString());
                nod.Nodes.Add("Mail: " + c.MailTelefon[0]);
                nod.Nodes.Add("Telefon: " + c.MailTelefon[1]);
                TreeNode nodAsigurari = new TreeNode("Asigurari");
                foreach(Asigurari a in c.Asigurari)
                {
                    TreeNode nodAsigurare = new TreeNode(a.TipAsigurare);
                    nodAsigurare.Nodes.Add("ID Asigurare: " + a.IdAsigurare);
                    nodAsigurare.Nodes.Add("Denumire Asigurare: " +  a.DenumireAsigurare.ToString());
                    nodAsigurare.Nodes.Add("Valoare: " + a.SumaAsigurata.ToString());
                    nodAsigurare.Nodes.Add("Inceput valabilitate: " + a.InceputValabilitate.ToString().Substring(0, a.InceputValabilitate.ToString().IndexOf(' ')));
                    nodAsigurare.Nodes.Add("Final valabilitate: " + a.FinalValabilitate.ToString().Substring(0, a.FinalValabilitate.ToString().IndexOf(' ')));
                    nodAsigurari.Nodes.Add(nodAsigurare);
                }
                nod.Nodes.Add(nodAsigurari);
                tvClienti.Nodes.Add(nod);
            }
        }


        private TreeNode NodTop(TreeNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
        }


        private void modificaDateleClientuluiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modifica_Date modificaDate = new Modifica_Date(mainMenu);
            TreeNode selectedNode = tvClienti.SelectedNode;
            if (selectedNode != null && selectedNode.Level == 0)
            {
                string numePrenume = selectedNode.Text;
                modificaDate.tbNumeClient.Text = numePrenume;
            }
            else if(selectedNode != null && selectedNode.Level == 1)
            {
                string numePrenume = NodTop(tvClienti.SelectedNode).Text;
                modificaDate.tbNumeClient.Text = numePrenume;
            }
            else if(selectedNode !=null && selectedNode.Level == 2)
            {
                modificaDate.tbNumeClient.Text = NodTop(selectedNode).Text;
                modificaDate.tbTipAsigurare.Text = selectedNode.Text;
                if (selectedNode.Nodes.Count > 0)
                {
                    modificaDate.tbDenumireAsigurare.Text = selectedNode.Nodes[1].Text.Substring(selectedNode.Nodes[1].Text.IndexOf(": ") + 2);
                }

            }
            modificaDate.Show();
        }

        private void printeazaDateleClientuluiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceseazaUnClient acceseazaUnClient = new AcceseazaUnClient(mainMenu);
            TreeNode selectedNode = tvClienti.SelectedNode;
            string numePrenume = "";
            if (selectedNode != null && selectedNode.Parent == null)
            {
                numePrenume = selectedNode.Text;
            }
            else
            {
                numePrenume = NodTop(tvClienti.SelectedNode).Text;
            }
            acceseazaUnClient.tbNumeClient.Text = numePrenume;
            acceseazaUnClient.button1_Click(sender, e);
            acceseazaUnClient.button2_Click(sender, e);
        }

        private void salveazaClientulCaXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvClienti.SelectedNode;
            if (selectedNode != null && selectedNode.Parent == null)
            {
                selectedNode = NodTop(selectedNode);
            }
            bool gasit = false;
            foreach (Client c in mainMenu.Clients)
            {
                if (c.NumePrenume == selectedNode.Text && gasit == false) 
                {
                    gasit = true;
                    AcceseazaUnClient.WriteClientDataToXML(c);
                    MessageBox.Show("Clientul a fost salvat cu succes ca XML!");
                }
            }
            if (gasit == false) MessageBox.Show("Clientul nu a fost gasit!");
        }


        private static void stergeClientDinDB(int idClient)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Client WHERE Idclient = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idClient);
                    command.ExecuteNonQuery();
                }
            }
        }


        private static void stergeAsigurareDinDB(int idAsigurare)
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

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvClienti.SelectedNode;

            if (selectedNode != null)
            {
                if (selectedNode.Level == 0)
                {
                    DialogResult result = MessageBox.Show($"Sigur doriti sa stergeti clientul '{selectedNode.Text}'?",
                                                 "Confirmati stergerea:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int idClient = Convert.ToInt32(selectedNode.Nodes[0].Text.Substring(selectedNode.Nodes[0].Text.IndexOf(": ") + 2));
                        stergeClientDinDB(idClient);
                        bool gasit = false;
                        Client aux = null;
                        foreach (Client c in mainMenu.Clients)
                        {
                            if (c.Idclient == idClient && gasit == false)
                            {
                                aux = c;
                                gasit = true;
                            }
                        }
                        if (gasit == false) MessageBox.Show("Eroare: clientul se afla in TreeView, dar nu in lista de clienti!");
                        else mainMenu.Clients.Remove(aux);
                        tvClienti.Nodes.Remove(selectedNode);                  
                    }
                }
                else if (selectedNode.Level == 2)
                {
                    DialogResult result = MessageBox.Show($"Sigur doriti sa stergeti asigurarea '{selectedNode.Text}'?",
                                                 "Confirmati stergerea:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int idAsigurare = Convert.ToInt32(selectedNode.Nodes[0].Text.Substring(selectedNode.Nodes[0].Text.IndexOf(": ") + 2));
                        stergeAsigurareDinDB(idAsigurare);
                        TreeNode nodClient = NodTop(selectedNode);
                        int idClient = Convert.ToInt32(nodClient.Nodes[0].Text.Substring(nodClient.Nodes[0].Text.IndexOf(": ") + 2));
                        bool gasit = false;
                        foreach (Client c in mainMenu.Clients)
                        {
                            if (c.Idclient == idClient)
                            {
                                Asigurari aux = null;
                                foreach (Asigurari a in c.Asigurari)
                                {
                                    if (a.IdAsigurare == idAsigurare)
                                    {
                                        gasit = true;
                                        aux = a;
                                    }
                                }
                                if (gasit == true) c.Asigurari.Remove(aux);
                            }
                        }
                        if (gasit == false) MessageBox.Show("Eroare: Asigurarea se afla in TreeView, dar nu si in lista!");
                        tvClienti.Nodes.Remove(selectedNode);

                    }
                }
                else
                {
                    MessageBox.Show("Selectati un client sau o asigurare pentru stergere.", "Stergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nu ati selectat nimic pentru stergere.", "Stergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
