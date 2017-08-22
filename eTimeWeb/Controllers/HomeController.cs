using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTimeAutomationWeb;
using log4net;
using SAPSourceMasterApplication.DomainModel;

namespace eTimeWeb.Controllers
    {
    public class HomeController : Controller
        {
        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
            {
            return View();
            }

        public ActionResult About()
            {
            
            return View();
            }

        

        #region Private Methods

        private void FetchUserName()
            {
            try
                {
                LogManager.Debug("FetchUserName: START");
                string loggedInUserId = HttpContext.User.Identity.Name.ToString();
                int index = loggedInUserId.IndexOf('\\');
                string userId = loggedInUserId.Substring(index + 1);
                using (SAPSourceModelContext context = new SAPSourceModelContext())
                    {
                    string userName = context.FetchLoggedInUserName(userId);
                    Session["LoggedInUserName"] = userName;
                    }
                LogManager.Debug("FetchUserName: END");
                }

            catch (Exception ex)
                {
                LogManager.Error("FetchUserName: ERROR " + ex.Message, ex);
                }
            }
        #endregion
        }
    }