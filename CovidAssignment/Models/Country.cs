using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidAssignment.Models
{
    public class Country
    {
        public int Id { get; set; }

        [JsonProperty("Country")]
        public string Name { get; set; }

        [JsonProperty("Slug")]
        public string Slug { get; set; }

        [JsonProperty("ISO2")]
        public string ISO2 { get; set; }

    }
}