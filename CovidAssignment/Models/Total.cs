using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidAssignment.Models
{
    public class Total
    {
        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("Province")]
        public string Province { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("CityCode")]
        public string CityCode { get; set; }

        [JsonProperty("Lat")]
        public string Lat { get; set; }

        [JsonProperty("Lon")]
        public string Lon { get; set; }

        [JsonProperty("Cofirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("Deaths")]
        public int Deaths { get; set; }

        [JsonProperty("Recovered")]
        public int Recovered { get; set; }

        [JsonProperty("Actice")]
        public int Active { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

    }
}