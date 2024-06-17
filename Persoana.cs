using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public class Persoana
    {

        private string numePrenume;
        private int varsta;
        private char sex;

        public Persoana(string numePrenume, int varsta, char sex)
        {
            this.numePrenume = numePrenume;
            this.varsta = varsta;
            this.sex = sex;
        }

        public string NumePrenume { get => numePrenume; set => numePrenume = value; }
        public int Varsta { get => varsta; set => varsta = value; }
        public char Sex { get => sex; set => sex = value; }

        public static Persoana operator+(Persoana p, int value)
        {
            if(value > 0) p.varsta = p.varsta + value;
            return p;
        }
        public static Persoana operator-(Persoana p, int value)
        {
            if (value < p.varsta && value > 0) p.varsta = p.varsta - value;
            return p;
        }


        public void VerificaVarsta()
        {
            if (this.varsta >= 18) MessageBox.Show("Persoana are varsta legala de a achizitiona asigurari!");
            else MessageBox.Show("Persoana nu are varsta minima legala!");
        }

        public void afiseazaDate()
        {
            string s = "Nume:" + this.numePrenume + "\nSex:" + this.sex + "\nVarsta: " + this.Varsta.ToString() + " ani.";
            MessageBox.Show(s);
        }


    }
}
