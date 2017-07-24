using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTimeWeb.Controllers
{
    public class FMLAController : Controller
    {
    // GET: FMLA
    public ActionResult Index()
        {
        return View("FMLAMain");
        
        }

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
    }


}