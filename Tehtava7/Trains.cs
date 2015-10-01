using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava7
{
    class Trains
    {
        [JsonProperty("trainNumber")]
        public int JunanNumero { get; set; }
        [JsonProperty("departureDate")]
        public DateTime LähtöPVM { get; set; }

        /*
        public string operatorUICCode { get; set; }
        public string operatorShortCode { get; set; }
        */

        [JsonProperty("trainType")]
        public string Junatyyppi { get; set; }
        [JsonProperty("trainCategory")]
        public string JunaKategoria { get; set; }
        [JsonProperty("runningCurrently")]
        public bool AjossaNyt { get; set; }
        [JsonProperty("cancelled")]
        public bool Peruttu { get; set; }
        [JsonProperty("timeTableRows")]
        public List<TrainPoints> PysahdysPaikat { get; set; }

        public bool right { get; set; }
    }
    class TrainPoints
    {
        [JsonProperty("stationShortCode")]
        public string Paikkakunta { get; set; }
        [JsonProperty("countryCode")]
        public string Maa { get; set; }

        /*
        public string stationUICCode { get; set; }
        public string type { get; set; }
        public bool trainStopping { get; set; }
        public bool cancelled { get; set; }
        public DateTime scheduledTime { get; set; }
        */
    }

    class Places
    {
        public string stationName { get; set; }
        public string stationShortCode { get; set; }
    }
}
