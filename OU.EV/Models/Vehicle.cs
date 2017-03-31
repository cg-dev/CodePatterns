using Newtonsoft.Json;

namespace OU.EV.Models
{
    public class Vehicle
    {
        [JsonProperty(PropertyName = "id")]
        public string Registration { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "colour")]
        public string Colour { get; set; }

        [JsonProperty(PropertyName = "forename")]
        public string Forename { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}