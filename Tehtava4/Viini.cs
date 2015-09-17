using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tehtava4
{
    class Viini
    {
        string nimi {
            get { return nimi; }
            set { this.nimi = value; }
        }

        string maa {
            get { return maa; }
            set { this.maa = value; }
        }

        int pojot {
            get { return pojot; }
            set { this.pojot = value; }
        }

        public Viini()
        {
            this.nimi = "";
            this.maa = "";
            this.pojot = 0;
        }

        public Viini(string nimi, string maa, int pojot)
        {
            this.nimi = nimi;
            this.maa = maa;
            this.pojot = pojot;
        }
    }
}
