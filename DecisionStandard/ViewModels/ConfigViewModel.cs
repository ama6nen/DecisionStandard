using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

using DecisionStandard.Models;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows;
using DecisionStandard.Views;

namespace DecisionStandard.ViewModels
{
    public class ConfigViewModel : Screen
    {
        private readonly IWindowManager _windowMgr; //might be needed later
        private ConfigModel config = null;
        private ConfigModel oldConfig = null;
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
            config = new ConfigModel();

            if (File.Exists("config.json"))
                config = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText("config.json"));
            else File.WriteAllText("config.json", JsonConvert.SerializeObject(config)); //write the default config for now, for no reason

            oldConfig = config;
            config.DebugPrint();
        }

        public void HandleClose(object sender, CancelEventArgs e)
        {
            if (!object.Equals(oldConfig, config)) //Why bother asking if you want to save if nothing is changed
            {
                var res = MessageBox.Show("Do you want to save the configuration?", "Save", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(config));  //save config
                    oldConfig = config; //So now our oldconfig is our new one
                }
                else if (res == MessageBoxResult.No)
                    config = oldConfig; //reset to our old config
                else if (res == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                    return; //So we dont remove the event handler from below code
                }

            }
            (sender as ConfigView).Closing -= HandleClose; //Because for some reason the event keeps firing twice
        }
    }
}
