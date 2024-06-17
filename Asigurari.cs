using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    public class Asigurari :ICloneable, IComparable
    {
        private static int next_id = 1;
        private int idAsigurare;
        private int idClient;
        private string tipAsigurare;
        private string denumireAsigurare;
        private float sumaAsigurata;
        private DateTime inceputValabilitate;
        private DateTime finalValabilitate;
        private bool esteValabila;

        public Asigurari() 
        { 
        }
        public Asigurari(string tipAsigurare, int idClient, string denumireAsigurare, float sumaAsigurata, DateTime inceputValabilitate, DateTime finalValabilitate)
        {
            this.idAsigurare = next_id;
            next_id++;
            this.idClient = idClient;
            this.tipAsigurare = tipAsigurare;
            this.denumireAsigurare = denumireAsigurare;
            this.sumaAsigurata = sumaAsigurata;
            this.inceputValabilitate = inceputValabilitate;
            this.finalValabilitate = finalValabilitate;
            if(DateTime.Now <= finalValabilitate) this.esteValabila = true;
            else this.esteValabila = false;
        }

        public string TipAsigurare { get => tipAsigurare; }
        public string DenumireAsigurare { get => denumireAsigurare; }
        public DateTime InceputValabilitate { get => inceputValabilitate; set => inceputValabilitate = value; }
        public DateTime FinalValabilitate { get => finalValabilitate; set => finalValabilitate = value; }
        public bool EsteValabila { get => esteValabila; set => esteValabila = value; }
        public float SumaAsigurata { get => sumaAsigurata; set => sumaAsigurata = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public int IdAsigurare { get => idAsigurare; set => idAsigurare = value; }

        public object Clone()
        {
            Asigurari aux = new Asigurari(this.tipAsigurare, this.idClient, this.denumireAsigurare, this.sumaAsigurata, this.inceputValabilitate, this.finalValabilitate);
            return (object)aux;
        }

        public int CompareTo(object obj)
        {
            int aux = 0;
            Asigurari a = obj as Asigurari;
            if (a.sumaAsigurata > this.sumaAsigurata)
                aux = 1;
            return aux;
        }

        public static Asigurari operator*(Asigurari a, float value)
        {
            if (value > 0) a.sumaAsigurata = a.SumaAsigurata * value;
            return a;
        }
        public static Asigurari operator/(Asigurari a, float value)
        {
            if (value > 0) a.sumaAsigurata = a.SumaAsigurata / value;
            return a;
        }


        public void extindeAsigurarea(DateTime date)
        {
            if(date >= DateTime.Now)
            {
                this.finalValabilitate = date;
                this.esteValabila = true;
            }
        }

        public void folosesteAsigurarea(float suma)
        {
            if (suma > 0)
            {
                if (suma < this.sumaAsigurata) this.sumaAsigurata -= suma;
                else this.sumaAsigurata = 0;
            }
        }

    }
}
