using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3
{
    class Pelaaja
    {
        private string etunimi;
        private string sukunimi;
        private string seura;
        private double siirtohinta;

        public string EtuNimi
        {
            get { return etunimi; }
            set { this.etunimi = value; }
        }

        public string SukuNimi
        {
            get { return sukunimi; }
            set { this.sukunimi = value; }
        }
        public string Seura
        {
            get { return seura; }
            set { this.seura = value; }
        }
        public double Siirtohinta
        {
            get { return siirtohinta; }
            set { this.siirtohinta = value; }
        }
        public string KokoNimi {
            get { return etunimi + " " + sukunimi + ", " + seura; }
        }

        public Pelaaja()
        {
            this.etunimi = "Pasi";
            this.sukunimi = "Pekka";
            this.seura = "Kemut";
            this.siirtohinta = 66.6;
        }

        public Pelaaja(string etunimi, string sukunimi, string seura, double siirtohinta)
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.seura = seura;
            this.siirtohinta = siirtohinta;
        }
    }
}
