using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class BakeController : Controller
    {
        // GET: Bake
        private string parentName;
        private IDictionary<string, Devices> deviceList;
        private IDictionary<string, Devices> burnerList;
        private Oven bakeOven;
        public ActionResult BakeView()
        {
            parentName = ViewBag.ParentName;
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            burnerList = ((Bake)deviceList[parentName]).GetBurnerList();
            ViewBag.BurnerList = burnerList;
            bakeOven = ((Bake)deviceList[parentName]).GetBakeOven();
            ViewBag.BakeOven = bakeOven;
            return View();
        }
        public ActionResult Delete(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            deviceList.Remove(name);
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
    }
}