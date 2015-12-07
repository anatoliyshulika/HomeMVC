using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class OvenController : Controller
    {
        // GET: Oven
        private IDictionary<string, Devices> deviceList;
        private Oven bakeOven;
        public ActionResult OvenView()
        {
            return View();
        }
        public ActionResult OnOff(string parentName)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            bakeOven = ((Bake)deviceList[parentName]).GetBakeOven();
            ((ISwitchbl)bakeOven).OnOff();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LampOnOff(string parentName)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            bakeOven = ((Bake)deviceList[parentName]).GetBakeOven();
            bakeOven.LampOnOff();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
    }
}