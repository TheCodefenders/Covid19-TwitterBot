using Newtonsoft.Json;
using System;

namespace CovidTwitterBot.Models
{
    public class StateDataResult
    {
        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("confirmed_per_100k_inhabitants")]
        public double ConfirmedPer100kInhabitants { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
        
        [JsonProperty("death_rate")]
        public double DeathRate { get; set; }
        
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        
        [JsonProperty("estimated_population_2019")]
        public int EstimatedPopulation2019 { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
    }
}