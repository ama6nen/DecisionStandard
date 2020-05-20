﻿using Caliburn.Micro;
using DecisionStandard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DecisionStandard.Views
{
    public static class Constants
    {
        public static string TimeFormat = "HH:mm:ss";
    }
    public partial class ConfigView : Window
    {
        private ConfigViewModel viewModel;
        public ConfigView()
        {
            InitializeComponent();
            viewModel = IoC.Get<ConfigViewModel>();
            Closing += viewModel.HandleClose;
        }
    }
}
