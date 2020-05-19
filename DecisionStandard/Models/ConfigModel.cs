using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DecisionStandard.Models
{
    public class ConfigModel
    {
        private string name = "";
        public ConfigModel(string Name)
        {
            name = Name;
            Debug.WriteLine("Constructing config");
        }

        public void DebugPrint()
        {
            Debug.WriteLine("Owner is " + name);
        }
    }
}
