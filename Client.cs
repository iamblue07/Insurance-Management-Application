using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public class Client : Persoana, ICloneable, IComparable, IMetodeClient
    {
        static int next_id = 1;
        private int idclient;
        private float salariu;
        private string[] mailTelefon = new string[2];
        private List<Asigurari> asigurari;

        public int Idclient { get => idclient; set => idclient = value; }
        public float Salariu { get => salariu; set => salariu = value; }
        public string[] MailTelefon { get => mailTelefon; set => mailTelefon = value; }
        internal List<Asigurari> Asigurari { get => asigurari; set => asigurari = value; }

        public Client(float salariu, string[] mailTelefon, List<Asigurari> asigurari, string numePrenume, int varsta, char sex) : base(numePrenume, varsta, sex)
        {
            this.idclient = next_id;
            next_id++;
            this.salariu = salariu;
            this.mailTelefon[0] = mailTelefon[0];
            this.mailTelefon[1] = mailTelefon[1];
            this.asigurari = new List<Asigurari>();
            if (asigurari != null)
            {
                foreach (Asigurari s in asigurari)
                {
                    this.asigurari.Add((Asigurari)s.Clone());
                }
            }
        }

        public object Clone()
        {
            Client copie = new Client(this.salariu, this.mailTelefon, this.asigurari, this.NumePrenume, this.Varsta, this.Sex);
            return (object)copie;
        }

        public int CompareTo(object obj)
        {
            int aux = 0;
            Client client = obj as Client;
            float s1 = 0;
            foreach(Asigurari s in this.asigurari)
            {
                s1 += s.SumaAsigurata;
            }
            float s2 = 0;
            foreach (Asigurari s in client.asigurari)
            {
                s2 += s.SumaAsigurata;
            }

            if (s2 > s1)
                aux = 1;
            return aux;
        }


        public string this[int index]
        {
            get
            {
                if (index < 0 || index > 2)
                {
                    throw new IndexOutOfRangeException("Indexul este în afara limitelor masivului mailTelefon!");
                }

                return mailTelefon[index];
            }
            set
            {
                if (index < 0 || index > 2)
                {
                    throw new IndexOutOfRangeException("Indexul este în afara limitelor masivului mailTelefon!");
                }

                mailTelefon[index] = value;
            }
        }

        public static float operator%(Client client, float procent)
        {
            return client.salariu%procent;
        }


        public void afiseazaAsigurari()
        {
            string s = "";

            foreach (Asigurari a in  asigurari)
            {
                s += "Tip asigurare:" + a.TipAsigurare + "\nDenumire Asigurare:" + a.DenumireAsigurare
                    + "\nSuma asigurata:" + a.SumaAsigurata.ToString() + "\nValabil de la:" + a.InceputValabilitate.ToString()
                    + "\nPana la:" + a.FinalValabilitate.ToString();
                if (a.EsteValabila == true) s += "\nEste valabila: Da\n\n\n";
                else s += "\nEste valabila: Nu\n\n\n";
            }
            MessageBox.Show(s);
        }
        public float costTotalAsigurari()
        {
            float total = 0;
            foreach(Asigurari a in asigurari)
            {
                total += a.SumaAsigurata;
            }
            return total;
        }


    }
}
