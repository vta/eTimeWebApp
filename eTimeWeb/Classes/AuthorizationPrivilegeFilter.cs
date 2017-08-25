using eTime.DomainModel;
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

                //HttpContext ctx = HttpContext.Current;
                //// check if session has timed out here
                //if (HttpContext.Current.Session["LoggedInUserName"] == null)
                //    {
                //    filterContext.Result = new RedirectResult("~/Home/SessionTimeOut");
                //    return;
                //    }

                using (var eTimeModelContext = new eTimeModelContext())
                    {
                    string userId = HttpContext.Current.User.Identity.Name;
                    // Removing Domain name from the logged in user name
                    if (!String.IsNullOrEmpty(userId))
                        {
                        int index = userId.IndexOf("\\");
                        name = userId.Substring(index + 1);

                        var url = HttpContext.Current.Request.Url.ToString();
                        // If URL doesn't contain ProcId, gets the configured user, 
                        // validates and routes the URL appropriately
                        // SM TBD If URL doesn't contain SN, it is a saved FMLA or a Create New FMLA Request   
                    
                        // Create New FMLA acccess
                        if (!url.Contains("SN") && !url.Contains("FMLAID"))
                            {
                            if (filterContext.ActionDescriptor.ActionName == "FMLAMain")
                                {
                                //var result = eInvoiceModelContext.GetConfiguredUser("AP", 0);
                                // SM TBD validate Employee in SAPEmployeeProfile table and give access, if not Deny access
                                var result = "";
                                var authenticated = "";// TBD(from configuredName in result where configuredName.ToLower().Equals(name.ToLower()) select configuredName);
                                if (authenticated == null || authenticated.Count() == 0)
                                    {
                                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                                    }
                                }
                            }
                        // SM TBD Saved FMLA can be opened by FMLA Admin or Employee themselved
                        // Open saved FMLA Record
                        else if (url.Contains("FMLAID") && !url.Contains("ReadOnly"))
                            {
                            //string invoiceMasterID = String.Empty;
                            //if (HttpContext.Current.Request.QueryString["InvoiceMasterID"] != null)
                            //    invoiceMasterID = HttpContext.Current.Request.QueryString["InvoiceMasterID"];
                            //string documentNo = eInvoiceModelContext.GetDocumentNoFromInvoiceMasterID(Convert.ToInt32(invoiceMasterID));

                            //if (String.IsNullOrEmpty(documentNo))
                            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                            //else
                            //    {
                            //    string status = eInvoiceModelContext.GetStatus(Convert.ToInt32(invoiceMasterID));
                            //    if (status == "AP Review")
                            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "SavedeInvoice" }, { "documentNo", documentNo }, { "status", status }, { "invoiceMasterID", Convert.ToInt32(invoiceMasterID) } });
                            //    else
                            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                            //    }
                            }
                        // For viewing Report
                        // SM TBD All Employees, FMLA Admin should be able to view Report
                        else if (url.Contains("ReadOnly") && url.Contains("InvoiceMasterID"))
                            {
                            //string invoiceMasterID = String.Empty;
                            //if (HttpContext.Current.Request.QueryString["InvoiceMasterID"] != null)
                            //    invoiceMasterID = HttpContext.Current.Request.QueryString["InvoiceMasterID"];
                            //string documentNo = eInvoiceModelContext.GetDocumentNoFromInvoiceMasterID(Convert.ToInt32(invoiceMasterID));
                            //string status = eInvoiceModelContext.GetStatus(Convert.ToInt32(invoiceMasterID));

                            //// SM 06/12/2017 -- Allow All VTA Users access to Report link to Doc No
                            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ViewReport" }, { "documentNo", documentNo }, { "status", status }, { "invoiceMasterID", Convert.ToInt32(invoiceMasterID) } });

                            ////var invoiceApprovers = eInvoiceModelContext.GetDestinationApproversforInvoice(Convert.ToInt32(invoiceMasterID));
                            ////var authenticatedUser = (from configuredName in invoiceApprovers where configuredName.ToLower() == name.ToLower() select configuredName);

                            ////if (authenticatedUser == null || authenticatedUser.Count() == 0)
                            ////{
                            ////    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                            ////}
                            ////else
                            ////{
                            ////    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ViewReport" }, { "documentNo", documentNo }, { "status", status }, { "invoiceMasterID", Convert.ToInt32(invoiceMasterID) } });
                            ////}
                            }
                        // SM TBD If URL contains SN, extracts ProcId from it, query from DB, 
                        // get the FMLAID No and Status of FMLA from FMLA Request Table and route appropriately
                        else
                            {
                            //string SN = String.Empty;
                            //string SharedUser = string.Empty;

                            //if (HttpContext.Current.Request.QueryString["SN"] != null)
                            //    SN = HttpContext.Current.Request.QueryString["SN"];
                            //if (HttpContext.Current.Request.QueryString["SharedUser"] != null)
                            //    SharedUser = HttpContext.Current.Request.QueryString["SharedUser"];

                            //// bool authenticated = K2Service.VerifyWorklistItem(SN, userId);
                            //bool authenticated = K2Service.VerifyWorklistItemShared(SN, userId, SharedUser);
                            //if (authenticated)
                            //    {
                            //    int SNIndex = SN.IndexOf('_');
                            //    string newProcId = SN.Substring(0, SNIndex);
                            //    string documentNo = eInvoiceModelContext.GetDocumentNo(Convert.ToInt32(newProcId));
                            //    int invoiceMasterID = eInvoiceModelContext.GetInvoiceMasterIDFromProcId(Convert.ToInt32(newProcId));
                            //    if (documentNo == null || documentNo.Equals("0"))
                            //        {
                            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                            //        }
                            //    else
                            //        {
                            //        if (filterContext.ActionDescriptor.ActionName != "ReadOnlyeInvoice")
                            //            {
                            //            string status = eInvoiceModelContext.GetStatus(invoiceMasterID);
                            //            var roles = eInvoiceModelContext.GetLoggedInUserRole(userId);
                            //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ReadOnlyeInvoice" }, { "documentNo", documentNo }, { "status", status }, { "SN", SN }, { "SharedUser", SharedUser } });
                            //            }
                            //        }
                            //    }
                            //else
                            //    {
                            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "AccessDenied" } });
                            //    }
                            }
                        }
                    }

                LogManager.Debug("OnActionExecuting: END");

                }
            catch (Exception ex)
                {
                LogManager.Error("OnActionExecuting: ERROR " + ex.Message, ex);
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ActionedOrCompleted" } });
                }
            }

        //public override void OnActionExecuting2(ActionExecutingContext filterContext)
        //{
        //    try
        //    {
        //        LogManager.Debug("OnActionExecuting: START");

        //        string name = String.Empty;
        //        base.OnActionExecuting(filterContext);

             
                

        //        LogManager.Debug("OnActionExecuting: END");

        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.Error("OnActionExecuting: ERROR " + ex.Message, ex);
        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "ActionedOrCompleted" } });           
        //    }
        //}
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