using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace DecisionStandard.Models
{

    public class ConfigModel
    {
        public float ProdWeight = 0.8f; //How positively we value productivity decisions compared to instant gratification
        public float DifficultyWeight = 0.45f; //how much does it matter to us that something is difficult (1 = max difficulty almost never recommended, 0 = difficulty does not matter at all)
        public float TimeWeight = 0.4f; //The closer this is to 1, the more the line blurs between the switch from productive to non productive time

        public DateTime TimeGoal { get; set; } = DateTime.ParseExact("20:00", "HH:mm", CultureInfo.InvariantCulture);

        public int TasksGoal { get; set; } = 8; //How many tasks we want to get done in a day

        public void DebugPrint()
        {
            Debug.WriteLine("Productivity weight is " + ProdWeight);
            Debug.WriteLine("Difficulty weight is " + DifficultyWeight);
            Debug.WriteLine("Time weight is " + TimeWeight);
            Debug.WriteLine("Tasks Goal is " + TasksGoal);
            Debug.WriteLine("Time Goal is " + TimeGoal);
        }

        public ConfigModel ShallowCopy() => (ConfigModel)this.MemberwiseClone();

        public override bool Equals(object obj)
        {
            if (!(obj is ConfigModel))
                return false;

            var model = obj as ConfigModel;

            if (model.ProdWeight != ProdWeight)
                return false;

            if (model.DifficultyWeight != DifficultyWeight)
                return false;

            if (model.TimeWeight != TimeWeight)
                return false;

            if (model.TasksGoal != TasksGoal)
                return false;

            return model.TimeGoal.ToBinary() == TimeGoal.ToBinary();
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
