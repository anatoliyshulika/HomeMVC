using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class TVController : Controller
    {
        // GET: TV
        private IDictionary<string, Devices> deviceList;
        public ActionResult TVViwe()
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
        public ActionResult ChannelDown(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((TV)deviceList[name]).ChannelDown();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ChannelUp(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((TV)deviceList[name]).ChannelUp();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult VolumeDown(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((TV)deviceList[name]).VolumeDown();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult VolumeUp(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((TV)deviceList[name]).VolumeUp();
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