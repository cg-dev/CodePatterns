using Newtonsoft.Json;
using System;

namespace OU.EV.Models
{
    using OU.EV.Validations;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [JsonObject(MemberSerialization.OptIn)]
    public class Slot
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "location")]
        [Required]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "vehicle")]
        [Required]
        public string Vehicle { get; set; }

        [JsonProperty(PropertyName = "status")]
        [Range(10, 60, ErrorMessage = "Please select a status for this slot.")]
        public Status Status { get; set; }

        [JsonProperty(PropertyName = "duration")]
        [RequiredForOnCharge]
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

        [DisplayName("EV Owner")]
        public string EvOwner { get; set; }

        [DisplayName("Charge End Time")]
        public DateTime ChargeEndTime { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

        public IEnumerable<SelectListItem> Vehicles { get; set; }
    }
}