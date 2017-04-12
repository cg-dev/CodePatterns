using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;
using System.Linq;


namespace OU.EV.Controllers
{
    public class SlotController : Controller
    {
        [ActionName("Index")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> IndexAsync()
        {
            var slots = await SlotRepository<Slot>.GetItemsAsync();
            return View(slots.OrderBy(s => s.Location).ThenBy(s => s.Arrival));
        }

        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Location,Type,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                await SlotRepository<Slot>.CreateItemAsync(slot);
                return RedirectToAction("Index");
            }

            return View(slot);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Location,Type,Duration,Message,FreeSpaces,PreePoints,Arrival,ChargeStartTime")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                await SlotRepository<Slot>.UpdateItemAsync(slot.Id, slot);
                return RedirectToAction("Index");
            }

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

            Slot slot = await SlotRepository<Slot>.GetItemAsync(id);
            if (slot == null)
            {
                return HttpNotFound();
            }

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
            return View(slot);
        }
    }
}