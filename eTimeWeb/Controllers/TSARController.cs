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
using log4net;

namespace eTimeWeb.Controllers
    {
    public class TSARController : Controller
        {

        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        TSARRequestsViewModel tsarRequestsViewModel = new TSARRequestsViewModel();
        TSARItemsViewModel tsarItemsViewModel = new TSARItemsViewModel();
        int tsarID;
        // GET: TSAR
        // GET: TSARDashboard
        public ActionResult Index()
            {
            ViewBag.SAPCostCenterNo = SAPLookupController.GetSAPCostCenterNos();
            ViewBag.SAPInternalOrder = SAPLookupController.GetSAPInternalOrder();
            //TBD - SM - Get TSAR ID from URL or TSAR On Demand
            Session["TSARID"] = 1;
            return View("TSARItems");
            }


        // NetSpecx Inc -- 09/12/2016 -- Shabina M
        // Method - This is invoked from Read Event of TSARItems Grid
        // Method - Display items in TSARItems grid
        public ActionResult TSARItems_Read([DataSourceRequest]DataSourceRequest request)
            {
            try
                {
                //LogManager.Debug("TSARItems_Read: START");
                
                using (var eTimeModelContext = new eTimeModelContext())
                    {
                    tsarItemsViewModel.TSARItemsList = eTimeModelContext.GetTSARItemsList(1);
                    DataSourceResult result = new DataSourceResult();
                    result = tsarItemsViewModel.TSARItemsList.ToDataSourceResult(request, p => new TSARItemsModel
                    {

                        TimeSheetApprovalRequestItemID = p.TimeSheetApprovalRequestItemID,
                        TimeSheetApprovalRequestID = p.TimeSheetApprovalRequestID,
                        Description = p.Description,
                        PayCode = p.PayCode,
                        WBS = p.WBS,
                        InternalOrder = p.InternalOrder,
                        CostCenter = p.CostCenter,
                        HoursDay1 = p.D1,
                        HoursDay2 = p.D2,
                        HoursDay3 = p.D3,
                        HoursDay4 = p.D4,
                        HoursDay5 = p.D5,
                        HoursDay6 = p.D6,
                        HoursDay7 = p.D7,
                        HoursDay8 = p.D8,
                        HoursDay9 = p.D9,
                        HoursDay10 = p.D10,
                        HoursDay11 = p.D11,
                        HoursDay12 = p.D12,
                        HoursDay13 = p.D13,
                        HoursDay14 = p.D14,
                        SortOrder = p.SortOrder,
                        Total = p.Total,
                        StartDate = p.StartDate,
                    });
                    //LogManager.Debug("TSARItems_Read: END");
                    //return Json(result);
                    return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
            catch (Exception ex)
                {
                //LogManager.Error("TSARItems_Read: ERROR " + ex.Message, ex);
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("Error");
                }
            }

        // NetSpecx Inc -- 09/14/2016 -- Shabina M
        // Method - This is invoked from Update Event of TSARItems Grid
        // Method - Updates items in TSARItems grid
        [HttpPost]
        public ActionResult TSARItems_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<TSARItemsModel> tsarItems)
            {
            try
                {
                LogManager.Debug("TSARItems_Update: START");
                if (Session["TSARID"] != null)
                    tsarID = Convert.ToInt32(Session["TSARID"]);
                using (var eTimeWebModelcontext = new eTimeModelContext())
                    {

                    List<TimeSheetApprovalRequestItem> tsarItemList = new List<TimeSheetApprovalRequestItem>();
                    if (tsarItems != null && ModelState.IsValid)
                        {
                        ModelState.Clear();
                        foreach (var tsarItem in tsarItems)
                            {

                            tsarItemList.Add(new TimeSheetApprovalRequestItem
                            {
                                TimeSheetApprovalRequestID = (tsarItem.TimeSheetApprovalRequestID == 0 ? tsarID : tsarItem.TimeSheetApprovalRequestID),
                                TimeSheetApprovalRequestItemID = tsarItem.TimeSheetApprovalRequestItemID,
                                Description = tsarItem.Description,
                                PayCode = tsarItem.PayCode,
                                CostCenter = tsarItem.CostCenter,
                                WBS = tsarItem.WBS,
                                InternalOrder = tsarItem.InternalOrder,
                                D1 = tsarItem.HoursDay1,
                                D2 = tsarItem.HoursDay2,
                                D3 = tsarItem.HoursDay3,
                                D4 = tsarItem.HoursDay4,
                                D5 = tsarItem.HoursDay5,
                                D6 = tsarItem.HoursDay6,
                                D7 = tsarItem.HoursDay7,
                                D8 = tsarItem.HoursDay8,
                                D9 = tsarItem.HoursDay9,
                                D10 = tsarItem.HoursDay10,
                                D11 = tsarItem.HoursDay11,
                                D12 = tsarItem.HoursDay12,
                                D13 = tsarItem.HoursDay12,
                                D14 = tsarItem.HoursDay14,
                                Total = tsarItem.Total,
                                
                            });
                            }
                        eTimeWebModelcontext.SaveTimeSheetApprovalRequestItem(tsarItemList);
                        }
                    //foreach (ApproversViewModel vm in approvers)
                    //    {
                    //    if (vm.ApproverUserId == null)
                    //        vm.ApproverUserId = string.Empty;
                    //    if (vm.RoleName == null)
                    //        vm.RoleName = string.Empty;
                    //    }
                    LogManager.Debug("Approvers_Update: END");
                    return Json(tsarItems.ToDataSourceResult(request, ModelState));
                    }
                }
            catch (Exception ex)
                {
                LogManager.Error("TSARItems_Update: ERROR " + ex.Message, ex);
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("Error");
                }
            }


        }
    }