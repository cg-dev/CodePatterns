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
        public async Task<ActionResult> IndexAsync()
        {
            var locations = await LocationRepository<Location>.GetItemsAsync();
            return View(locations);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Code,Building,Type,Working,Points")] Location location)
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Code,Building,Type,Working,Points")] Location location)
        {
            if (ModelState.IsValid)
            {
                await LocationRepository<Location>.UpdateItemAsync(location.Code, location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Code")] string id)
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
        [ActionName("Delete")]
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
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Code")] string id)
        {
            await LocationRepository<Location>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync([Bind(Include = "Code")] string id)
        {
            Location location = await LocationRepository<Location>.GetItemAsync(id);
            return View(location);
        }
    }
}