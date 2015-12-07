using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public class Oven : Devices, ISwitchbl
    {
        private Lamp lamp;
        public Oven() { }
        public Oven(string viewPath, string parentName, string name, Lamp lamp) : base(viewPath, parentName, name)
        {
            this.lamp = lamp;
        }
        public void LampOnOff()
        {
            lamp.OnOff();
        }
        public bool GetLampState()
        {
            return lamp.State;
        }
        public void OnOff()
        {
            if (State)
            {
                state = false;
                return;
            }
            if (!State)
            {
                state = true;
                return;
            }
        }
    }
}