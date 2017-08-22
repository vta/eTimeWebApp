using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace eTimeWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Init Log4Net Configuration..
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
            {
            //Setting up value of custom Column, used in Log4Net.
            string userId = User.Identity.Name;
            int index = userId.IndexOf("\\");
            string logginUserName = userId.Substring(index + 1);
            log4net.GlobalContext.Properties["UserID"] = logginUserName;
            }
    }
}
