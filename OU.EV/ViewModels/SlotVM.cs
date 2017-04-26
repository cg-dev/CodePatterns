using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OU.EV.Models
{
    public class SlotVM
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        public TimeSpan Duration { get; set; }
        public string Message { get; set; }
        public int FreeSpaces { get; set; }
        public int FreePoints { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime ChargeStartTime { get; set; }

        public List<Status> _Statuses { get; set; }

        public IEnumerable<SelectListItem> Statuses
        {
            get { return new SelectList(_Statuses, "Id", "Description"); }
        }
    }
}