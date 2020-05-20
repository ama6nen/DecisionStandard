using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using DecisionStandard.Views;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace DecisionStandard.ViewModels
{
    public class DecisionViewModel : Conductor<object>
    {
        private readonly IWindowManager _windowMgr; //might be needed later
        private DecisionModel firstDecision = null;
        private DecisionModel secondDecision = null;
        private ConfigViewModel config = null;
        private int tasksDone = 0;
        private string decisionMessage = "";

        private void NotifyChange<T>(ref T field, T newval, [CallerMemberName] string name = "") //so we can actually use 1 liner for setter
        {
            field = newval;
            NotifyOfPropertyChange(name);
        }

        public DecisionViewModel(IWindowManager manager)
        {
            config = IoC.Get<ConfigViewModel>(); //we will want to use config if its loaded with data to aid our standard
            _windowMgr = manager;
            firstDecision = new DecisionModel();
            secondDecision = new DecisionModel();
        }

        public string DecisionMessage { get => decisionMessage; set => NotifyChange(ref decisionMessage, value); }
        public int TasksDoneToday { get => tasksDone; set => NotifyChange(ref tasksDone, value); }
        public DecisionModel FirstDecision { get => firstDecision; set => NotifyChange(ref firstDecision, value); }
        public DecisionModel SecondDecision { get => secondDecision; set => NotifyChange(ref secondDecision, value); }

        public async void LoadConfigView()
        {
            await _windowMgr.ShowWindowAsync(IoC.Get<ConfigViewModel>());
        }

        public void DecideHandler()
        {
            float aScore = 0.0f;
            float bScore = 0.0f;
            //Calculate the perceived difficulty value
            float aDiffFract = (FirstDecision.Difficulty / 10.0f) * (1.0f - config.Config.DifficultyWeight);
            float bDiffFract = (SecondDecision.Difficulty / 10.0f) * (1.0f - config.Config.DifficultyWeight);

            //Calculate the perceived productivity value
            float aProdFract = (FirstDecision.Productivity / 10.0f) * config.Config.ProdWeight;
            float bProdFract = (SecondDecision.Productivity / 10.0f) * config.Config.ProdWeight;

            aScore += (aDiffFract * 1.25f) + aProdFract; //value difficulty 1.25 times as much as productivity; usually it means its more useful
            bScore += (bDiffFract * 1.25f) + bProdFract;

            float Goal = config.Config.TasksGoal;
            if (Goal == 0.0f)
                Goal = 1.0f; //avoid undefined behavior

            float Done = tasksDone;
            if (Done == 0.0f)
                Done = 0.1f; //avoid division by zero

            //We only want to multiply the perceived more "productive" item by our tasks done fraction. when everything is done, it will be hihgly lower score
            //When nothing is done, it basically always makes the more productive one win
            float tasksFract = (Goal / Done * 0.5f);
            if (aScore > bScore)
                aScore *= tasksFract;
            else
                bScore *= tasksFract;

            DecisionMessage = aScore > bScore ? FirstDecision.Name : SecondDecision.Name;

        }
    }
}
