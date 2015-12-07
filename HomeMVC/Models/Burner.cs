using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public class Burner : Devices, ISwitchbl, ISetLevel
    {
        private SetLevel burnLevel;
        public Burner(string viewPath, string parentName, string name) : base(viewPath, parentName, name)
        {
        }
        public SetLevel BurnerLevel
        {
            get
            {
                return burnLevel;
            }
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
        public void LevelUp()
        {
            if (burnLevel == SetLevel.Medium && state)
            {
                burnLevel = SetLevel.Height;
                return;
            }
            else if (burnLevel == SetLevel.Low && state)
            {
                burnLevel = SetLevel.Medium;
                return;
            }
        }
        public void LevelDown()
        {
            if (burnLevel == SetLevel.Medium && state)
            {
                burnLevel = SetLevel.Low;
                return;
            }
            else if (burnLevel == SetLevel.Height && state)
            {
                burnLevel = SetLevel.Medium;
                return;
            }
        }
    }
}