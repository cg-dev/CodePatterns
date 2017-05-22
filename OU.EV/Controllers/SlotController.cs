using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;
using System.Linq;

namespace OU.EV.Controllers
{
    using System;

    using AutoMapper;

    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SlotController : Controller
    {
        [ActionName("Index")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> IndexAsync()
        {
            await SlotRepository<Slot>.DeleteItemsAsync(s => s.Arrival.Date < DateTime.Today);
            var slots = (await SlotRepository<Slot>.GetItemsAsync()).ToList();
            foreach (var slot in slots)
            {
                var vehicle = await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle);
                slot.EvOwner = vehicle?.FullName ?? "Not known";
                slot.ChargeEndTime = slot.ChargeStartTime.Add(slot.Duration);
            }
            return View(slots.Where(s => s.Status < Status.Completed && s.Arrival.Date >= DateTime.Today).OrderBy(s => s.Location).ThenBy(s => s.Arrival));
        }

        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync()
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var now = DateTime.Now.AddHours(tzi.IsDaylightSavingTime(DateTime.Today) ? 1 : 0);

            var slot = new Slot
            {
                Arrival = now,
                ChargeStartTime = now,
                Vehicles = new SelectList((await VehicleRepository<Vehicle>.GetItemsAsync()).OrderBy(v => v.FullName), "Registration", "FullName"),
                Locations = new SelectList((await LocationRepository<Location>.GetItemsAsync()).OrderBy(l => l.Building), "Building", "Building")
            };
            return View(slot);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Vehicle,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (this.ModelState.IsValid)
            {
                await SlotRepository<Slot>.CreateItemAsync(slot);
                //SendAppropriateEmails(slot).Wait();
                return RedirectToAction("Index");
            }

            slot.Vehicles = new SelectList((await VehicleRepository<Vehicle>.GetItemsAsync()).OrderBy(v => v.FullName), "Registration", "FullName");
            slot.Locations = new SelectList((await LocationRepository<Location>.GetItemsAsync()).OrderBy(l => l.Building), "Building", "Building");

            return View(slot);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Vehicle,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (this.ModelState.IsValid)
            {
                await SlotRepository<Slot>.UpdateItemAsync(slot.Id, slot);
                //SendAppropriateEmails(slot).Wait();
                return RedirectToAction("Index");
            }

            slot.Locations = new SelectList((await LocationRepository<Location>.GetItemsAsync()).OrderBy(l => l.Building), "Building", "Building");
            slot.EvOwner = (await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle)).FullName;

            return View(slot);
        }

        [ActionName("Edit")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var slot = await SlotRepository<Slot>.GetItemAsync(id);
            if (slot == null)
            {
                return HttpNotFound();
            }

            slot.Locations = new SelectList((await LocationRepository<Location>.GetItemsAsync()).OrderBy(l => l.Building), "Building", "Building");
            slot.EvOwner = (await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle)).FullName;

            return View(slot);
        }

        [ActionName("Delete")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DeleteAsync([Bind(Include = "Id")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var slot = await SlotRepository<Slot>.GetItemAsync(id);
            if (slot == null)
            {
                return HttpNotFound();
            }

            return View(slot);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await SlotRepository<Slot>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DetailsAsync([Bind(Include = "Id")] string id)
        {
            var slot = await SlotRepository<Slot>.GetItemAsync(id);
            return View(slot);
        }

        // todo: send appropriate emails
        static async Task SendAppropriateEmails(Slot slot)
        {
            if (slot.Status >= Status.OnCharge)
            {
                var slots = (await SlotRepository<Slot>.GetItemsAsync()).ToList();
                foreach (var waitingSlot in slots.Where(s => s.Status < Status.OnCharge))
                {
                    var vehicle = await VehicleRepository<Vehicle>.GetItemAsync(waitingSlot.Vehicle);
                    var client = new SendGridClient(Environment.GetEnvironmentVariable(""));
                    var from = new EmailAddress("noreply@open.ac.uk", "No reply");
                    var subject = "Sending with SendGrid is Fun";
                    var to = new EmailAddress(vehicle.Email, vehicle.FullName);
                    var plainTextContent = "and easy to do anywhere, even with C#";
                    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    await client.SendEmailAsync(msg);
                }
            }
        }
    }
}