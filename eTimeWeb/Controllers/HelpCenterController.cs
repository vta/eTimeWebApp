using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eTimeWeb.Controllers
{
    public class HelpCenterController : Controller
    {
        // GET: HelpCenter
        public ActionResult Help()
        {
            return View();
        }

        public ActionResult TrainingMaterial()
        {

            return View();
        }
        public ActionResult ReleaseNotes()
        {

            return View();
        }
        public ActionResult GettingStarted()
        {

            return View();
        }
        public ActionResult HowToNotes()
        {

            return View();
        }
    }
}