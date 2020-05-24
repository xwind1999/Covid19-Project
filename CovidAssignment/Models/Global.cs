using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidAssignment.Models
{
    public class Global
    {
        public int Id { get; set; }

        [JsonProperty("NewConfirmed")]
        public int NewConfirmed { get; set; }

        [JsonProperty("TotalConfirmed")]
        public int TotalConfirmed { get; set; }

        
        [JsonProperty("NewDeaths")]
        public int NewDeaths { get; set; }

        [JsonProperty("TotalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty("NewRecovered")]
        public int NewRecovered { get; set; }

        [JsonProperty("TotalRecovered")]
        public int TotalRecovered { get; set; }
    }
}