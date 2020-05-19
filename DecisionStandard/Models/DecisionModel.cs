using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DecisionStandard.Models
{
    public class DecisionModel
    {
        public string Name { get; set; }
       
        //not needed or used for now, might be useful for identifying theselater though
        private  static int IDCounter = 0;
        private int ID = 0;
        public DecisionModel()
        {
            ID = IDCounter++;
        }

        public void DebugPrint()
        {
            Debug.WriteLine("Name: " + Name);
        }
    }
}
