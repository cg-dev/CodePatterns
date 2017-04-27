using OU.EV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OU.EV
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            VehicleRepository<OU.EV.Models.Vehicle>.Initialize();
            LocationRepository<OU.EV.Models.Location>.Initialize();
            SlotRepository<OU.EV.Models.Slot>.Initialize();
        }
    }
}