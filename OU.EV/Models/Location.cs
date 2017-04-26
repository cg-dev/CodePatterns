using Newtonsoft.Json;

namespace OU.EV.Models
{
    public class Location
    {
        [JsonProperty(PropertyName = "id")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "building")]
        public string Building { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "isWorking")]
        public bool Working { get; set; }
        [JsonProperty(PropertyName = "points")]
        public int Points { get; set; }
    }
}