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

        private async Task<int> SendEmails(Slot leavingSlot)
        {
            var emailsSent = 0;

            var apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];

            if (leavingSlot.Status >= Status.OnCharge && apiKey != "DummyValue")
            {
                var leavingVehicle = await VehicleRepository<Vehicle>.GetItemAsync(leavingSlot.Vehicle);

                var slots = (await SlotRepository<Slot>.GetItemsAsync()).ToList();
                foreach (var activeSlot in slots
                    .Where(s => s.Status <= Status.OnCharge && s.Location == leavingSlot.Location && s.Vehicle != leavingVehicle.Registration)
                    .OrderBy(s => s.Arrival))
                {
                    var activeVehicle = await VehicleRepository<Vehicle>.GetItemAsync(activeSlot.Vehicle);

                    await this.SendEmailToWaitingVehicle(leavingSlot, apiKey, activeVehicle, leavingVehicle);
                    emailsSent++;
                }
                await this.SendEmailToLeavingVehicle(leavingSlot, apiKey, leavingVehicle, emailsSent);
            }

            return emailsSent;
        }

        private async Task SendEmailToWaitingVehicle(Slot leavingSlot, string apiKey, Vehicle activeVehicle, Vehicle leavingVehicle)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("noreply@ouevweb.co.uk", "OU EV Charging Monitor");
            var subject = $"Notice of change of charging status for an EV at {leavingSlot.Location.ToString()}";
            var to = new EmailAddress(activeVehicle.Email, activeVehicle.FullName);
            var plainTextContent = $@"{leavingVehicle.FullName} has changed charging status at {leavingSlot.Location.ToString()} to {leavingSlot.Status.ToString()}.
                        Please check waiting list on the website. You may be able to move your car into a waiting bay or put it on to charge.
                        {@"http://ou-ev-web.azurewebsites.net/Slot"}
                        This email has been sent to all EV owners who are on charge or waiting at {leavingSlot.Location.ToString()}";
            var htmlContent = $@"<p>{leavingVehicle.FullName} has changed charging status at <bold>{leavingSlot.Location.ToString()}</bold> to <bold>{leavingSlot.Status.ToString()}</bold>.</p>
                        <p>Please check waiting list on the website. You may be able to move your car into a waiting bay or put it on to charge.</p>
                        <p>{@"http://ou-ev-web.azurewebsites.net/Slot"}</p>
                        <p>This email has been sent to all EV owners who are on charge or waiting at {leavingSlot.Location.ToString()}</p>";
            var msg = MailHelper.CreateSingleEmail(@from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }

        private async Task SendEmailToLeavingVehicle(Slot leavingSlot, string apiKey, Vehicle leavingVehicle, int emailsSent)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("noreply@ouevweb.co.uk", "OU EV Charging Monitor");
            var subject = $"Thank you for updating your charging status at {leavingSlot.Location.ToString()} to {leavingSlot.Status.ToString()}";
            var to = new EmailAddress(leavingVehicle.Email, leavingVehicle.FullName);
            var plainTextContent = $@"{emailsSent} messages has/have been sent to EV owners who are on charge or waiting to charge at {leavingSlot.Location.ToString()}.
                        Please remember to keep the web page updated next time you use the university's charging facilities.
                        {@"http://ou-ev-web.azurewebsites.net/Slot"}";
            var htmlContent = $@"<p>{emailsSent} messages has/have been sent to EV owners who are on charge or waiting to charge at {leavingSlot.Location.ToString()}.</p>
                        <p>Please remember to keep the OU EV Charging Monitor slots page updated next time you use the university's charging facilities.</p>
                        <p>{@"http://ou-ev-web.azurewebsites.net/Slot"}</p>";
            var msg = MailHelper.CreateSingleEmail(@from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}