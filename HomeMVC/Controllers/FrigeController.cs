using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class FrigeController : Controller
    {
        // GET: Frige
        private IDictionary<string, Devices> deviceList;
        public ActionResult FrigeView()
        {
            return View();
        }
        public ActionResult OnOff(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((ISwitchbl)deviceList[name]).OnOff();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LampOnOff(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((Frige)deviceList[name]).LampOnOff();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LevelDown(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((Frige)deviceList[name]).LevelDown();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LevelUp(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((Frige)deviceList[name]).LevelUp();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
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