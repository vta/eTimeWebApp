using SAPSourceMasterApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTimeWeb.Controllers
{
    public class SAPLookupController : Controller
    {
        private static readonly log4net.ILog LogManager = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: SAPLookup
        public ActionResult Index()
        {
            return View();
        }

        public static List<int> GetSAPCostCenterNos()
            {
            try
                {
                LogManager.Debug("GetSAPCostCenterNos: START");
                List<int> costCenterNos = new List<int>();
                using (var SAPSourceModelContext = new SAPSourceModelContext())
                    {
                    costCenterNos = SAPSourceModelContext.GetSAPCostCenterNos();
                    }

                LogManager.Debug("GetSAPCostCenterNos: END");

                return costCenterNos;
                }
            catch (Exception ex)
                {
                LogManager.Error("GetSAPCostCenterNos: ERROR " + ex.Message, ex);
                return null;
                }
            }


        public JsonResult GetSAPWBS(string wbsNo)
            {
            try
                {
                LogManager.Debug("GetSAPWBS: START");

                IEnumerable<SAPWBS> wbs;
                using (var SAPSourceModelContext = new SAPSourceModelContext())
                    {
                    if (!string.IsNullOrEmpty(wbsNo))
                        {
                        wbs = SAPSourceModelContext.GetSAPWBSFilter(wbsNo.Trim());
                        }
                    else
                        {
                        SAPWBS empty = new SAPWBS();
                        empty.WBSNo = "";
                        empty.Description = "";
                        List<SAPWBS> emptyList = new List<SAPWBS>();
                        emptyList.Add(empty);
                        wbs = emptyList;
                        }
                    }
                LogManager.Debug("GetSAPWBS: END");

                return Json(wbs, JsonRequestBehavior.AllowGet);
                }

            catch (Exception ex)
                {
                LogManager.Error("GetSAPWBS: ERROR " + ex.Message, ex);
                return null;
                }
            }


        public static List<string> GetSAPInternalOrder()
            {
            try
                {
                LogManager.Debug("GetSAPInternalOrder: START");
                List<string> internalOrder = new List<string>();
                using (var SAPSourceModelContext = new SAPSourceModelContext())
                    {
                    internalOrder = SAPSourceModelContext.GetSAPInternalOrder();
                    }
                LogManager.Debug("GetSAPInternalOrder: END");
                return internalOrder;
                }

            catch (Exception ex)
                {
                LogManager.Error("GetSAPInternalOrder: ERROR " + ex.Message, ex);
                return null;
                }
            }

    }
}