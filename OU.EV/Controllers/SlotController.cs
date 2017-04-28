using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;
using System.Linq;


namespace OU.EV.Controllers
{
    using System;

    public class SlotController : Controller
    {
        [ActionName("Index")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> IndexAsync()
        {
            // todo: remove any slots before today
            var slots = await SlotRepository<Slot>.GetItemsAsync();
            return this.View(slots.Where(s => s.Status != Status.Completed).OrderBy(s => s.Location).ThenBy(s => s.Arrival));
        }

        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync()
        {
            // todo: Populate dropdown for locations from database
            // todo: Pass in and display the max number of working charge points and waiting bays
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var now = DateTime.Now.AddHours(tzi.IsDaylightSavingTime(DateTime.Today) ? 1 : 0);

            var slot = new Slot
                       {
                           Arrival = now,
                           ChargeStartTime = now
                       };

            return this.View(slot);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (this.ModelState.IsValid)
            {
                await SlotRepository<Slot>.CreateItemAsync(slot);
                // todo: send appropriate emails
                return this.RedirectToAction("Index");
            }

            return this.View(slot);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (this.ModelState.IsValid)
            {
                await SlotRepository<Slot>.UpdateItemAsync(slot.Id, slot);
                // todo: send appropriate emails
                return this.RedirectToAction("Index");
            }

            return this.View(slot);
        }

        [ActionName("Edit")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id")] string id)
        {
            // todo: Populate dropdown for locations from database
            // todo: Pass in and display the max number of working charge points and waiting bays
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Slot slot = await SlotRepository<Slot>.GetItemAsync(id);
            if (slot == null)
            {
                return this.HttpNotFound();
            }

            return this.View(slot);
        }
        [ActionName("Delete")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DeleteAsync([Bind(Include = "Id")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Slot slot = await SlotRepository<Slot>.GetItemAsync(id);
            if (slot == null)
            {
                return this.HttpNotFound();
            }

            return this.View(slot);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await SlotRepository<Slot>.DeleteItemAsync(id);
            return this.RedirectToAction("Index");
        }

        [ActionName("Details")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DetailsAsync([Bind(Include = "Id")] string id)
        {
            Slot slot = await SlotRepository<Slot>.GetItemAsync(id);
            return this.View(slot);
        }
    }
}