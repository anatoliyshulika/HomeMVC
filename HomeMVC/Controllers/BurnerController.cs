using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class BurnerController : Controller
    {
        // GET: Burner
        private IDictionary<string, Devices> deviceList;
        private IDictionary<string, Devices> burnerList;
        public ActionResult BurnerView()
        {
            return View();
        }
        public ActionResult OnOff(string name, string parentName)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            burnerList = ((Bake)deviceList[parentName]).GetBurnerList();
            ((ISwitchbl)burnerList[name]).OnOff();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LevelDown(string name, string parentName)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            burnerList = ((Bake)deviceList[parentName]).GetBurnerList();
            ((ISetLevel)burnerList[name]).LevelDown();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LevelUp(string name, string parentName)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            burnerList = ((Bake)deviceList[parentName]).GetBurnerList();
            ((ISetLevel)burnerList[name]).LevelUp();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
    }
}