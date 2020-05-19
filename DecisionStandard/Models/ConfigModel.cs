using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DecisionStandard.Models
{
    public class ConfigModel
    {
        private string name = "";
        public float ProductiveWeight = 0.8f; //How positively we value productivity decisions compared to instant gratification

        public ConfigModel(string Name)
        {
            name = Name;
            Debug.WriteLine("Constructing config");
        }

        public void DebugPrint()
        {
            Debug.WriteLine("Owner is " + name);
            Debug.WriteLine("Productivity weight is " + ProductiveWeight);
        }
    }
}
