using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eTimeAutomationWeb
{
    // MVC Action Filter class which gets executed before an Action executes
    public class AuthorizationPrivilegeFilter : ActionFilterAttribute
    {
        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                LogManager.Debug("OnActionExecuting: START");

                string name = String.Empty;
                base.OnActionExecuting(filterContext);

            
                LogManager.Debug("OnActionExecuting: END");

            }
            catch (Exception ex)
            {
                LogManager.Error("OnActionExecuting: ERROR " + ex.Message, ex);
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ActionedOrCompleted" } });           
            }
        }
    }

    // MVC Action Filter class which gets executed before an Action executes
    public class SessionTimeOutFilter : ActionFilterAttribute
        {
        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
            try
                {
                LogManager.Debug("SessionTimeOutFilter: START");

                string name = String.Empty;
                base.OnActionExecuting(filterContext);

                HttpContext ctx = HttpContext.Current;
                // check if session has timed out here
                if (ctx.Session["LoggedInUserName"] == null)
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.Result = new JsonResult
                            {
                                  Data = new
                                  {
                                     status = "401"
                                  },
                                  JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                  
                            };

                          //xhr status code 401 to redirect
                          filterContext.HttpContext.Response.StatusCode = 401;
                          return;
                        }
                        else
                        {
                            var result = new PartialViewResult
                            {
                                ViewName = "SessionTimeOut"
                            };

                            filterContext.Result = result;
                            return;
                            //string loginUrl = "http://localhost/eInvoice/home/SessionTimeOut";
                            //filterContext.HttpContext.Response.Redirect(loginUrl, false);
                            //filterContext.Result = new EmptyResult();
                        }
                    }
                LogManager.Debug("SessionTimeOutFilter: END");

                }
            catch (Exception ex)
                {
                LogManager.Error("SessionTimeOutFilter: ERROR " + ex.Message, ex);

                }
            }
        }
}