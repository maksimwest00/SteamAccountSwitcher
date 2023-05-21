using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steam_Account_Switcher
{
    public class SettingsJson
    {
        public Settings settings { get; set; }
    }

    public class Settings
    {
        public string path { get; set; }
    }

    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
