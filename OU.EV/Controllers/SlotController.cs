using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;
using System.Linq;
//using OU.EV.ViewModels;
using System.Configuration;

namespace OU.EV.Controllers
{
    using System;

    using AutoMapper;
    using SendGrid.Helpers.Mail;
    using SendGrid;

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
                await SendEmails(slot);
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
                await SendEmails(slot);
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

        private async Task<int> SendEmails(Slot slot)
        {
            var emailsSent = 0;

            var apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];

            if (apiKey != "DummyValue")
            {
                var changingVehicle = await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle);

                var slots = (await SlotRepository<Slot>.GetItemsAsync()).ToList();
                foreach (var waitingSlot in slots.Where(s => s.Status < Status.OnCharge && s.Location == slot.Location).OrderBy(s => s.Arrival))
                {
                    var vehicle = await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle);

                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress("noreply@ouevweb.co.uk", "No Reply");
                    var subject = $"Notice of change of charging status for an EV at {slot.Location.ToString()}";
                    var to = new EmailAddress(vehicle.Email, vehicle.FullName);
                    var plainTextContent = $@"{changingVehicle.FullName} has changed their charging status at {slot.Location.ToString()} to {slot.Status.ToString()}.
                        Please check waiting list on the website to see if you can move your car into the waiting bay or put it on to charge.
                        This email has been sent to all EV owners who are waiting at {slot.Location.ToString()}";
                    var htmlContent = $@"{changingVehicle.FullName} has changed their charging status at {slot.Location.ToString()} to {slot.Status.ToString()}<br/>.
                        Please check waiting list on the website to see if you can move your car into the waiting bay or put it on to charge.<br/>
                        This email has been sent to all EV owners who are waiting at {slot.Location.ToString()}";
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    emailsSent++;
                }
            }

            return emailsSent;
        }
    }
}