using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public class Frige : Devices, ISwitchbl, ISetLevel
    {
        private Lamp lamp;
        private SetLevel frigeLevel = SetLevel.Low;
        public Frige() { }
        public Frige(string viewPath, string name, Lamp lamp) : base(viewPath, name)
        {
            this.lamp = lamp;
        }
        public SetLevel FrigeLevel
        {
            get
            {
                return frigeLevel;
            }
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
        public void LevelUp()
        {
            if (frigeLevel == SetLevel.Medium && state)
            {
                frigeLevel = SetLevel.Height;
                return;
            }
            else if (frigeLevel == SetLevel.Low && state)
            {
                frigeLevel = SetLevel.Medium;
                return;
            }
        }
        public void LevelDown()
        {
            if (frigeLevel == SetLevel.Medium && state)
            {
                frigeLevel = SetLevel.Low;
                return;
            }
            else if (frigeLevel == SetLevel.Height && state)
            {
                frigeLevel = SetLevel.Medium;
                return;
            }
        }
    }
}