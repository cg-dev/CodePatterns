namespace OU.EV.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using OU.EV.Models;

    public class SlotViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

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

        public IEnumerable<SelectListItem> Locations { get; set; }
    }
}