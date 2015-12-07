using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public class Lamp : Devices, ISwitchbl
    {
        public Lamp(string name) : base(name)
        {
        }
        public Lamp(string viewPath, string name) : base(viewPath, name)
        {
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