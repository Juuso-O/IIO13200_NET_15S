using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava8
{
    class Palaute
    {
        public string pvm { get; set; }
        public string tekija { get; set; }
        public string opittu { get; set; }
        public string haluanoppia { get; set; }
        public string hyvaa { get; set; }
        public string parannettavaa { get; set; }
        public string muuta { get; set; }

        public Palaute(string pvm, string tekija, string opittu, string haluanoppia, string hyvaa, string parannettavaa, string muuta)
        {
            this.pvm = pvm;
            this.tekija = tekija;
            this.opittu = opittu;
            this.haluanoppia = haluanoppia;
            this.hyvaa = hyvaa;
            this.parannettavaa = parannettavaa;
            this.muuta = muuta;
        }
    }
}
