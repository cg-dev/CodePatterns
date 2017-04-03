using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using OU.EV.Models;
using OU.EV.Repositories;

namespace OU.EV.Controllers
{
    public class VehicleController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var vehicles = await VehicleRepository<Vehicle>.GetItemsAsync();
            return View(vehicles);
        }

        [ActionName("Create")]
        [Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [Authorize(Roles = "OU-EV-Admins")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Registration,Make,Model,Colour,Forename,Surname,Email")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await VehicleRepository<Vehicle>.CreateItemAsync(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [HttpPost]
        [ActionName("Edit")]
        [Authorize(Roles = "OU-EV-Admins")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Registration,Make,Model,Colour,Forename,Surname,Email")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await VehicleRepository<Vehicle>.UpdateItemAsync(vehicle.Registration, vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [ActionName("Edit")]
        [Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> EditAsync([Bind(Include = "Registration")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = await VehicleRepository<Vehicle>.GetItemAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            return View(vehicle);
        }
        [ActionName("Delete")]
        [Authorize(Roles = "OU-EV-Admins")]
        public async Task<ActionResult> DeleteAsync([Bind(Include = "Registration")] string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = await VehicleRepository<Vehicle>.GetItemAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            return View(vehicle);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "OU-EV-Admins")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Registration")] string id)
        {
            await VehicleRepository<Vehicle>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync([Bind(Include = "Registration")] string id)
        {
            Vehicle vehicle = await VehicleRepository<Vehicle>.GetItemAsync(id);
            return View(vehicle);
        }
    }
}