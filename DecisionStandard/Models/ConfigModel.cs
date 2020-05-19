using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DecisionStandard.Models
{
    public class ConfigModel
    {
        public float ProdWeight = 0.8f; //How positively we value productivity decisions compared to instant gratification
        public float DifficultyWeight = 0.45f; //how much does it matter to us that something is difficult (1 = max difficulty almost never recommended, 0 = difficulty does not matter at all)


        public void DebugPrint()
        {
            Debug.WriteLine("Productivity weight is " + ProdWeight);
            Debug.WriteLine("Difficulty weight is " + DifficultyWeight);
        }
    }
}
