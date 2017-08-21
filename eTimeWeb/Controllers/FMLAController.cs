using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
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
using System.Web.Optimization;
using System.Web.Routing;
using SAPSourceMasterApplication.DomainModel;

namespace eTimeWeb.Controllers
{
    public class FMLAController : Controller
    {
        FMLAEmployeeViewModel fmlaEmployeeViewModel = new FMLAEmployeeViewModel();
        SAPSourceModelContext SAPModel = new SAPSourceModelContext();
        int FMLAID;

        public ActionResult FMLA()
        {
            Session["FMLAID"] = null;
            ViewBag.IsSupervisorOrFMLA = false;
            var url = HttpContext.Request.Url.ToString();
            string userId = GetCurrentUserId();
            int empID = SAPModel.GetEmpIDFromUserID(userId);
            using (var eTimeModelContext = new eTimeModelContext())
            {
                fmlaEmployeeViewModel.FMLAEmployeeDetails = eTimeModelContext.GetFMLAEmployeeProfile(empID);
                fmlaEmployeeViewModel.EmpAgreementVerbiage = eTimeModelContext.GetEmpAgreementVerb("FMLAAgreementVerbiage");
            }

            fmlaEmployeeViewModel.QuotaBalance = GetEmployeeHoursBalance(empID);
            return PartialView("_FMLAMain", fmlaEmployeeViewModel);

        }

        [HttpPost]
        public ActionResult NewFMLA(FMLAEmployeeViewModel fmlaEmployeeViewModel)
        {
            return null;
        }

    // GET: FMLA
        //public ActionResult Index()
        //    {
        //        var url = HttpContext.Request.Url.ToString();
        //        //FMLAEmployeeViewModel fmlaEmployeeViewModel = new FMLAEmployeeViewModel();  
        //        string userId = GetCurrentUserId();
                
        //        int empID = SAPModel.GetEmpIDFromUserID(userId);
        //        fmlaEmployeeViewModel.QuotaBalance = GetEmployeeHoursBalance(empID);
        //        ViewBag.isSupervisorOrFMLA = false;
        //        using (var eTimeModelContext = new eTimeModelContext())
        //        {
        //            fmlaEmployeeViewModel.FMLAEmployeeDetails = eTimeModelContext.GetFMLAEmployeeProfile(empID);
        //            //fmlaEmployeeViewModel.FMLAEmployeeForDD = eTimeModelContext.GetFMLAEmployeeListForDD(empID, userId);
        //            fmlaEmployeeViewModel.EmpAgreementVerbiage = eTimeModelContext.GetEmpAgreementVerb("FMLAAgreementVerbiage");
        //        }
        //        //var FMLAEmployeeForDDList = new SelectList(fmlaEmployeeViewModel.FMLAEmployeeForDD, "ID", "Name");
        //        //if (fmlaEmployeeViewModel.FMLAEmployeeForDD.Count() > 1)
        //        //{
        //        //    ViewBag.isSupervisorOrFMLA = true;
        //        //}
        //        return View("FMLAMain", fmlaEmployeeViewModel);
        
        //    }

        public JsonResult GetEmployeesForDD() //(int empID)
        {
            string userId = GetCurrentUserId();
            SAPSourceModelContext SAPModel = new SAPSourceModelContext();
            fmlaEmployeeViewModel.FMLAEmployeeForDD = new List<FMLAEmployeeForDD>();
            //List<FMLAEmployeeForDD> empList = new List<FMLAEmployeeForDD>();
            //List<string> EmpNames = new List<string>();
            int employeeID = SAPModel.GetEmpIDFromUserID(userId);
            using (var eTimeModelContext = new eTimeModelContext())
            {

                fmlaEmployeeViewModel.FMLAEmployeeForDD = eTimeModelContext.GetEmployeesForDD(employeeID);
                //EmpNames = (from p in empList where p.EmployeeID == employeeID select p.EmployeeName).Distinct().ToList<string>();
                return Json(fmlaEmployeeViewModel.FMLAEmployeeForDD, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetFMLAEmpDetailsforEmpDD(FMLAEmployeeViewModel fmlaEmployeeViewModel)
        {
            //FMLAEmployeeViewModel fmlaEmployeeViewModel = new FMLAEmployeeViewModel();
            using (var eTimeModelContext = new eTimeModelContext())
            {
                //fmlaEmployeeViewModel.FMLAEmployeeDetails = eTimeModelContext.GetFMLAEmployeeProfile(employeeID);
            }
            return PartialView("_FMLAEmployeeHeaderReadOnly", fmlaEmployeeViewModel);
        }

        public ActionResult Test(string Email)
        {
            return null;
        }

        public SAPEmpQuotaBalance GetEmployeeHoursBalance(int employeeID)
        {
            SAPSourceModelContext SAPModel = new SAPSourceModelContext();
            SAPEmpQuotaBalance quotaBalance = SAPModel.GetEmployeeQuotaBalance(employeeID);
            return quotaBalance;
        }

        public JsonResult SaveComment(String Comment)
        {
            try
            {
                fmlaEmployeeViewModel.Comment = Comment;
                TempData["Comment"] = Comment;
                return Json(Comment, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult FMLAUploadFile()
        {
            try
            {
                return View("RoutingDetailsUploadFile");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("Error");
            }
        }

        //private void SaveInvoiceComments()
        //{
        //    try
        //    {
        //        string comment = String.Empty;
        //        using (var context = new eTimeModelContext())
        //        {
        //            if (TempData["Comment"] != null)
        //            {
        //                comment = TempData["Comment"].ToString();
        //                var fmlaComment = new FMLAComment
        //                {
        //                    FMLAID = ,
        //                    CommentDate = DateTime.Now,
        //                    Comment = comment,
        //                    CommentBy = HttpContext.User.Identity.Name
        //                };
        //                var result = context.;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public ActionResult GetDashPdf()
            {
            var fileStream = new FileStream("C:/Users/mirajkar_s/K2/Projects/MVC/eInvoiceAutomationPublish/Content/Images/Misc/FMLAReport.pdf",
                                             FileMode.Open,
                                             FileAccess.Read
                                           );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
            }

        public ActionResult GetMainPdf()
            {
            var fileStream = new FileStream("C:/Users/mirajkar_s/K2/Projects/MVC/eInvoiceAutomationPublish/Content/Images/Misc/FMLAMain.pdf",
                                            FileMode.Open,
                                            FileAccess.Read
                                          );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
            }

        private string GetCurrentUserId()
        {
                string userId = string.Empty;
                string loggedInUserId = HttpContext.User.Identity.Name;
                if (loggedInUserId.Contains('\\'))
                {
                    int index = loggedInUserId.IndexOf('\\');
                    userId = loggedInUserId.Substring(index + 1);
                }
                else
                    userId = loggedInUserId;
                return userId;
        }
    }


}