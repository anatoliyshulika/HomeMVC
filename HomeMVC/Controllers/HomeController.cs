using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMVC
{
    public class HomeController : Controller
    {
        // GET: 
        private string lampViewPath = "~/Views/Lamp/LampView.cshtml";
        private string burnerViewPath = "~/Views/Burner/BurnerView.cshtml";
        private string ovenViewPath = "~/Views/Oven/OvenView.cshtml";
        private string bakeViewPath = "~/Views/Bake/BakeView.cshtml";
        private string frigeViewPath = "~/Views/Frige/FrigeView.cshtml";
        private string tvViewPath = "~/Views/TV/TVViwe.cshtml";
        private string radioViewPath = "~/Views/Radio/RadioView.cshtml";
        private IDictionary<string, Devices> deviceList;
        private IDictionary<string, Devices> burnerList;
        private Lamp lamp;
        private Oven bakeOven;
        public ActionResult Index()
        {
            if (Session["Device"] == null)
            {
                deviceList = new Dictionary<string, Devices>();
                deviceList.Add("Lamp1", new Lamp(lampViewPath, "Lamp1"));
                deviceList.Add("Bake1", new Bake(bakeViewPath, "Bake1", new Dictionary<string, Devices> { { "Bake1" + "burner1", new Burner(burnerViewPath, "Bake1", "Bake1" + "burner1") }, { "Bake1" + "burner2", new Burner(burnerViewPath, "Bake1", "Bake1" + "burner2") } }, new Oven(ovenViewPath, "Bake1", "Bake1" + "bakeOven", new Lamp("Bake1" + "bakeOven" + "lampOven"))));
                deviceList.Add("Frige1", new Frige(frigeViewPath, "Frige1", new Lamp("Frige1" + "Lamp")));
                deviceList.Add("TV1", new TV(tvViewPath, "TV1"));
                deviceList.Add("Radio1", new Radio(radioViewPath, "Radio1"));
                Session["Device"] = deviceList;
                ViewBag.DeviceList = deviceList;
                return View();
            }
            else
            {
                deviceList = (Dictionary<string, Devices>)Session["Device"];
                ViewBag.DeviceList = deviceList;
                return View();
            }
        }
        public ActionResult AddDevice(string typeOfDevice, string TextBoxNameOfDevice)
        {
            string name = TextBoxNameOfDevice;
            string parentName = TextBoxNameOfDevice;
            deviceList = (Dictionary<string, Devices>)Session["Device"];
            if (TextBoxNameOfDevice == string.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var key in deviceList)
            {
                if (name == key.Key)
                {
                    TextBoxNameOfDevice = null;
                    return RedirectToAction("Index", "Home");
                }
            }
            switch (typeOfDevice)
            {
                default:
                    break;
                case "Lamp":
                    deviceList.Add(name, new Lamp(lampViewPath, name));
                    break;
                case "TV":
                    deviceList.Add(name, new TV(tvViewPath, name));
                    break;
                case "Bake":
                    lamp = new Lamp(name + "bakeOven" + "lampOven");
                    bakeOven = new Oven(ovenViewPath, parentName, name + "bakeOven", lamp);
                    burnerList = new Dictionary<string, Devices> { { name + "burner1", new Burner(burnerViewPath, parentName, name + "burner1") }, { name + "burner2", new Burner(burnerViewPath, parentName, name + "burner2") } };
                    deviceList.Add(name, new Bake(bakeViewPath, name, burnerList, bakeOven));
                    break;
                case "Frige":
                    lamp = new Lamp(name + "lampFrige");
                    deviceList.Add(name, new Frige(frigeViewPath, name, lamp));
                    break;
                case "Radio":
                    deviceList.Add(name, new Radio(radioViewPath, name));
                    break;
            }
            TextBoxNameOfDevice = null;
            Session["Device"] = deviceList;
            ViewBag.DeviceList = deviceList;
            return RedirectToAction("Index", "Home");
        }
    }
}