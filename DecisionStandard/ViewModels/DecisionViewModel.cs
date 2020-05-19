using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using DecisionStandard.Views;
using System.Threading;
using System.Diagnostics;

namespace DecisionStandard.ViewModels
{
    public class DecisionViewModel : Conductor<object>
    {
        private readonly IWindowManager _windowMgr; //might be needed later
        private DecisionModel firstDecision = null;
        private DecisionModel secondDecision = null;
        private ConfigViewModel config = null;

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

        public DecisionModel FirstDecision { get => firstDecision; set => NotifyChange(ref firstDecision, value); }
        public DecisionModel SecondDecision { get => secondDecision; set => NotifyChange(ref secondDecision, value); }

        public async void LoadConfigView()
        {
            await _windowMgr.ShowWindowAsync(IoC.Get<ConfigViewModel>());
        }

        public void DebugButton()
        {
            FirstDecision.DebugPrint();
            SecondDecision.DebugPrint();
        }
    }
}
