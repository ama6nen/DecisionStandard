using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using DecisionStandard.Views;

namespace DecisionStandard.ViewModels
{
    public class DecisionViewModel : Screen
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
            var config = IoC.Get<ConfigView>(); //we will want to use config if its loaded with data to aid our standard
            _windowMgr = manager;
            decision = new DecisionModel();
        }

        public DecisionModel Config { get => decision; set => NotifyChange(ref decision, value); }

    }
}
