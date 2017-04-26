using Newtonsoft.Json;

namespace OU.EV.Models
{
    public class Status
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}