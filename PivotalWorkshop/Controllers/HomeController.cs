using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PivotalWorkshop.Utilities;

namespace PivotalWorkshop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.IpAddress = WebHelper.ServerIPAddress;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.IpAddress = WebHelper.ServerIPAddress;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.IpAddress = WebHelper.ServerIPAddress;
            return View();
        }

        public void KillMe()
        {
            WebHelper.KillTheApp();
        }
    }
}