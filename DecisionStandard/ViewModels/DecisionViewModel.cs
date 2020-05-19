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
        private DecisionModel decision = null;

        private void NotifyChange<T>(ref T field, T newval, [CallerMemberName] string name = "") //so we can actually use 1 liner for setter
        {
            field = newval;
            NotifyOfPropertyChange(name);
        }

        public DecisionViewModel(IWindowManager manager)
        {
            var config = IoC.Get<ConfigViewModel>(); //we will want to use config if its loaded with data to aid our standard
            config.Config.DebugPrint();
            _windowMgr = manager;
            decision = new DecisionModel();
        }

        public DecisionModel Decision { get => decision; set => NotifyChange(ref decision, value); }
       
        //Realistically we dont need these in the Model itself
        private string _firstDecision;
        public string FirstDecision { get => _firstDecision; set => NotifyChange(ref _firstDecision, value); }
        private string _secondDecision;
        public string SecondDecision { get => _secondDecision; set => NotifyChange(ref _secondDecision, value); }

        public async void LoadConfigView()
        {
            await _windowMgr.ShowWindowAsync(IoC.Get<ConfigViewModel>());
        }
    }
}
