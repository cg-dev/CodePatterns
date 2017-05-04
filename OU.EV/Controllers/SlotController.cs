using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;
using System.Linq;
using OU.EV.ViewModels;

namespace OU.EV.Controllers
{
    using System;

    using AutoMapper;

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
            return View(slots.Where(s => s.Status != Status.Completed).OrderBy(s => s.Location).ThenBy(s => s.Arrival));
        }

        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync()
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var now = DateTime.Now.AddHours(tzi.IsDaylightSavingTime(DateTime.Today) ? 1 : 0);

            var slotViewModel = new SlotViewModel
            {
                Arrival = now,
                ChargeStartTime = now,
                Vehicles = new SelectList(await VehicleRepository<Vehicle>.GetItemsAsync(), "Registration", "FullName"),
                Locations = new SelectList(await LocationRepository<Location>.GetItemsAsync(), "Building", "Building")
            };
            return View(slotViewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Vehicle,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] SlotViewModel slotViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var slot = Mapper.Map<Slot>(slotViewModel);
                await SlotRepository<Slot>.CreateItemAsync(slot);
                // todo: send appropriate emails
                return RedirectToAction("Index");
            }

            return View(slotViewModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Vehicle,Location,Status,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] SlotViewModel slotViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var slot = Mapper.Map<Slot>(slotViewModel);
                await SlotRepository<Slot>.UpdateItemAsync(slot.Id, slot);
                // todo: send appropriate emails
                return RedirectToAction("Index");
            }

            return View(slotViewModel);
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

            var slotViewModel = Mapper.Map<SlotViewModel>(slot);
            slotViewModel.Locations = new SelectList(await LocationRepository<Location>.GetItemsAsync(), "Building", "Building");
            slotViewModel.EvOwner = (await VehicleRepository<Vehicle>.GetItemAsync(slot.Vehicle)).FullName;

            return View(slotViewModel);
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
            Slot slot = await SlotRepository<Slot>.GetItemAsync(id);
            var slotViewModel = Mapper.Map<SlotViewModel>(slot);
            return View(slotViewModel);
        }
    }
}