using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace DecisionStandard.ViewModels
{
    public class ConfigViewModel : Screen
    {
        private readonly IWindowManager _windowMgr; //might be needed later
        private ConfigModel config = null;

        private void NotifyChange<T>(ref T field, T newval, [CallerMemberName] string name = "") //so we can actually use 1 liner for setter
        {

            field = newval;
            NotifyOfPropertyChange(name);
        }

        public ConfigViewModel(IWindowManager manager)
        {
            Debug.WriteLine("Constructing config viewmodel");
            _windowMgr = manager;
            config = new ConfigModel();
        }

        public ConfigModel Config { get => config; set => NotifyChange(ref config, value); }
    }
}
