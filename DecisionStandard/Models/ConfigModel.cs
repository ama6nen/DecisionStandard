using System.Diagnostics;

namespace DecisionStandard.Models
{
    public class ConfigModel
    {
        public float ProdWeight = 0.8f; //How positively we value productivity decisions compared to instant gratification
        public float DifficultyWeight = 0.25f; //how much does it matter to us that something is difficult (1 = max difficulty almost never recommended, 0 = difficulty does not matter at all)

        public int TasksGoal { get; set; } = 8; //How many tasks we want to get done in a day

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

            return model.TasksGoal == TasksGoal;

        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
