using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public class Bake : Devices
    {
        private IDictionary<string, Devices> burnerList;
        private Oven bakeOven;
        public Bake(string viewPath, string name, IDictionary<string, Devices> burnerList, Oven bakeOven) : base(viewPath, name)
        {
            this.burnerList = new Dictionary<string, Devices>();
            this.burnerList = burnerList;
            this.bakeOven = bakeOven;
        }
        public IDictionary<string, Devices> GetBurnerList()
        {
            return burnerList;
        }
        public Oven GetBakeOven()
        {
            return bakeOven;
        }
    }
}