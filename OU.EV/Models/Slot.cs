using Newtonsoft.Json;
using System;

namespace OU.EV.Models
{
    public class Slot
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "freeSpaces")]
        public int FreeSpaces { get; set; }

        [JsonProperty(PropertyName = "freePoints")]
        public int FreePoints { get; set; }

        [JsonProperty(PropertyName = "arrivalTime")]
        public DateTime Arrival { get; set; }

        [JsonProperty(PropertyName = "chargeStartTime")]
        public DateTime ChargeStartTime { get; set; }
    }
}