using Newtonsoft.Json;

namespace OU.EV.Models
{
    using System.ComponentModel;

    public class Location
    {
        [JsonProperty(PropertyName = "id")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "building")]
        public string Building { get; set; }

        [JsonProperty(PropertyName = "chargingPoints")]
        [DisplayName("Working Charging Points")]
        public int ChargingPoints { get; set; }

        [JsonProperty(PropertyName = "waitingBays")]
        [DisplayName("Waiting Bays")]
        public int WaitingBays { get; set; }
    }
}