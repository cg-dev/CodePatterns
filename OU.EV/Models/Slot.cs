using Newtonsoft.Json;
using System;

namespace OU.EV.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Slot
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "vehicle")]
        public string Vehicle { get; set; }

        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "freeSpaces")]
        [DisplayName("Free Spaces")]
        public int FreeSpaces { get; set; }

        [JsonProperty(PropertyName = "freePoints")]
        [DisplayName("Free Points")]
        public int FreePoints { get; set; }

        [JsonProperty(PropertyName = "arrivalTime")]
        [DisplayName("Arrival Time")]
        public DateTime Arrival { get; set; }

        [JsonProperty(PropertyName = "chargeStartTime")]
        [DisplayName("Charge Start Time")]
        public DateTime ChargeStartTime { get; set; }
    }
}