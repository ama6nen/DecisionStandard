using Caliburn.Micro;
using DecisionStandard.ViewModels;
using System.Windows;


namespace DecisionStandard.Views
{
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
