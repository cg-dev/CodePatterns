using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;

namespace OU.EV.Controllers
{
    public class LocationController : Controller
    {
        [ActionName("Index")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> IndexAsync()
        {
            var locations = await LocationRepository<Location>.GetItemsAsync();
            return View(locations);
        }

        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> CreateAsync()
        {
            // todo: Do not allow duplicate codes to be entered
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        //[Authorize(Roles = "OU-EV-Admins")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Code,Building,ChargingPoints,WaitingBays")] Location location)
        {
            if (ModelState.IsValid)
            {
                await LocationRepository<Location>.CreateItemAsync(location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        [HttpPost]
        [ActionName("Edit")]
        //[Authorize(Roles = "OU-EV-Admins")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Code,Building,ChargingPoints,WaitingBays")] Location location)
        {
            if (ModelState.IsValid)
            {
                await LocationRepository<Location>.UpdateItemAsync(location.Code, location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        [ActionName("Edit")]
        //[Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Code")] string id)
        {
            // todo: prevent code from being edited
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Location location = await LocationRepository<Location>.GetItemAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }
        [ActionName("Delete")]
        //[Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> DeleteAsync([Bind(Include = "Code")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Location location = await LocationRepository<Location>.GetItemAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Code")] string id)
        {
            await LocationRepository<Location>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        //[Authorize(Roles = "OU-EV-Users")]
        public async Task<ActionResult> DetailsAsync([Bind(Include = "Code")] string id)
        {
            Location location = await LocationRepository<Location>.GetItemAsync(id);
            return View(location);
        }
    }
}