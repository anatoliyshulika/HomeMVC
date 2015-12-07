﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class RadioController : Controller
    {
        // GET: Radio
        private IDictionary<string, Devices> deviceList;
        public ActionResult RadioView()
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
        public ActionResult VolumeDown(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((Radio)deviceList[name]).VolumeDown();
            Session["Device"] = deviceList;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult VolumeUp(string name)
        {
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            ((Radio)deviceList[name]).VolumeUp();
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