
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eTimeWeb.ViewModels;
using eTime.DomainModel;
using System.Data.Entity;
using Kendo.Mvc.Extensions;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Security;
using System.Threading.Tasks;
using System.Net;

namespace eTimeWeb.Controllers
{
    
    public class TSARDashboardController : Controller
    {

        TSARRequestsViewModel tsarRequestsViewModel = new TSARRequestsViewModel();

        // GET: TSARDashboard
        public ActionResult Index()
        {
            return View("TSARRequestsReviewedbyMe");
        }


        // NetSpecx Inc -- 09/08/2016 -- Shabina M
        // Method - This is invoked from Read Event of TSARRequestsReviewedByMe Grid
        // Method - Display items in TSARRequestsReviewedByMe grid
        public ActionResult TSARRequestsReviewedByMe_Read([DataSourceRequest]DataSourceRequest request)
            {
            try
                {
                //LogManager.Debug("TSARRequestsReviewedByMe_Read: START");
                using (var eTimeModelContext = new eTimeModelContext())
                    {
                    tsarRequestsViewModel.TSARRequestsReviewedByMeList = eTimeModelContext.GetReviewedByMeList();
                    DataSourceResult result = new DataSourceResult();
                    result = tsarRequestsViewModel.TSARRequestsReviewedByMeList.ToDataSourceResult(request, p => new TSARRequestsReviewedByMeModel
                    {

                        TSARID = p.TimeSheetApprovalRequestID,
                        EmpName = p.EmpName,
                        PayTypePeriod = p.PayTypePeriod,
                        Status = p.Status,
                        SubmittedDate = p.SubmittedDate,
                        SupervisorApprovalDateTime = p.SupervisorApprovalDateTime,
                        
                    });
                    //LogManager.Debug("TSARRequestsReviewedByMe_Read: END");
                    //return Json(result);
                    return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
            catch (Exception ex)
                {
                //LogManager.Error("TSARRequestsReviewedByMe_Read: ERROR " + ex.Message, ex);
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("Error");
                }
            }
    }
}