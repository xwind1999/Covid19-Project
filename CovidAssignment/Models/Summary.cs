using Newtonsoft.Json;
using System.Collections.Generic;

namespace CovidAssignment.Models
{
    public class Summary
    {
        [JsonProperty("Global")]
        public Global Global { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("Countries")]
        public List<CountryStatus> Countries { get; set; }
    }
}