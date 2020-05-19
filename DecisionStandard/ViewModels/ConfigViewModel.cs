using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

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
            LoadConfigFile();
           
        }

        public ConfigModel Config { get => config; set => NotifyChange(ref config, value); }

        private void LoadConfigFile()
        {
            config = new ConfigModel("Debug test");
          
            if (File.Exists("config.json"))
                config = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText("config.json"));
            else File.WriteAllText("config.json", JsonConvert.SerializeObject(config));

            config.DebugPrint();
        }
    }
}
