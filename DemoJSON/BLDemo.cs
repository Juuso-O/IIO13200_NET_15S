﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJSON
{
    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public DateTime birthday { get; set; }
    }

    public class Politic : Person
    {
        public string party { get; set; }

        [JsonProperty("position")]
        public string posiittion { get; set; }
    }
}
