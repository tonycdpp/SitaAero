using Newtonsoft.Json;

namespace SitaAssignment.Configuration
{
    public class MailHandler
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("minWeightInKg")]
        public decimal? MinWeightInKg { get; set; }
        [JsonProperty("maxWeightInKg")]
        public decimal? MaxWeightInKg { get; set; }
        [JsonProperty("minValue")]
        public decimal? MinValue { get; set; }
        [JsonProperty("maxValue")]
        public decimal? MaxValue { get; set; }
    }
}