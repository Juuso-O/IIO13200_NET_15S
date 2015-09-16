using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3
{
    class Joukkue
    {
        private List<string> joukkueLista = new List<string>();
        
        public Joukkue()
        {
            joukkueLista.Add("TPS");
            joukkueLista.Add("Lukko");
            joukkueLista.Add("Ässät");
            joukkueLista.Add("HIFK");
            joukkueLista.Add("Blues");
            joukkueLista.Add("HPK");
            joukkueLista.Add("Tappara");
            joukkueLista.Add("Ilves");
            joukkueLista.Add("Sport");
            joukkueLista.Add("Pelicans");
            joukkueLista.Add("KooKoo");
            joukkueLista.Add("SaiPa");
            joukkueLista.Add("Kärpät");
            joukkueLista.Add("JYP");
            joukkueLista.Add("KalPa");
        }

        public List<string> getJoukkueet() {
            return joukkueLista;
        }
    }
}
