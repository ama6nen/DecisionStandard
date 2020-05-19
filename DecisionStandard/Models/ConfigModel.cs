using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DecisionStandard.Models
{
    public class ConfigModel
    {
        private string name = "";
        public float ProdWeight = 0.8f; //How positively we value productivity decisions compared to instant gratification

        public ConfigModel(string Name)
        {
            name = Name;
        }

        public void DebugPrint()
        {
            Debug.WriteLine("Owner is " + name);
            Debug.WriteLine("Productivity weight is " + ProdWeight);
        }
    }
}
