namespace OU.EV
{
    using OU.EV.Repositories;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            VehicleRepository<Models.Vehicle>.Initialize();
            LocationRepository<OU.EV.Models.Location>.Initialize();
            SlotRepository<OU.EV.Models.Slot>.Initialize();
        }
    }
}