using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CovidAssignment.Models
{
    public class CountryStatus 
    {
        public int Id { get; set; }

        [JsonProperty("Country")]
        public string Name { get; set; }

        [JsonProperty("CountryCode")]
        public string Code { get; set; }

        [JsonProperty("Slug")]
        public string Slug { get; set; }

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

        [JsonProperty("Date")]
        public string Date { get; set; }

    }
}