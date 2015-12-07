using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMVC
{
    public abstract class Devices
    {
        private string name = string.Empty;
        protected bool state = false;
        private string viewPath;
        private string parentName;
        public Devices() { }
        public Devices(string name)
        {
            this.name = name;
        }
        public Devices(string viewPath, string name)
        {
            this.viewPath = viewPath;
            this.name = name;
        }
        public Devices(string viewPath, string parentName, string name)
        {
            this.viewPath = viewPath;
            this.parentName = parentName;
            this.name = name;
        }
        public bool State
        {
            get
            {
                return state;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string ViewPath
        {
            get
            {
                return viewPath;
            }
        }
        public string ParentName
        {
            get
            {
                return parentName;
            }
        }
    }
}