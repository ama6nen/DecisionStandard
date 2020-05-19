using Caliburn.Micro;
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
    /// <summary>
    /// Interaction logic for ConfigView.xaml
    /// </summary>
    public partial class ConfigView : Window
    {
        private ConfigViewModel viewModel;
        public ConfigView()
        {
            Debug.WriteLine("Setting up ConfigView");
            InitializeComponent();
            viewModel = IoC.Get<ConfigViewModel>();
            Closing += viewModel.HandleClose;
          
        }
    }
}
