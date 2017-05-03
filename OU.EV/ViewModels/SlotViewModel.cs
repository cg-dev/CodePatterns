﻿namespace OU.EV.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using OU.EV.Models;

    public class SlotViewModel
    {
        public string Id { get; set; }

        [DisplayName("EV Owner")]
        public string Vehicle { get; set; }

        public string Location { get; set; }

        public Status Status { get; set; }

        public TimeSpan Duration { get; set; }

        public string Message { get; set; }

        [DisplayName("Free Spaces")]
        public int FreeSpaces { get; set; }

        [DisplayName("Free Points")]
        public int FreePoints { get; set; }

        [DisplayName("Arrival Time")]
        public DateTime Arrival { get; set; }

        [DisplayName("Charge Start Time")]
        public DateTime ChargeStartTime { get; set; }


        [DisplayName("Charge End Time")]
        public DateTime ChargeEndTime
        {
            get { return ChargeStartTime.Add(Duration); }
        }

        public IEnumerable<SelectListItem> Locations { get; set; }

        public IEnumerable<SelectListItem> Vehicles { get; set; }
    }
}