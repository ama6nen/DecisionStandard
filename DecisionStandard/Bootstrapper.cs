using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DecisionStandard
{
    class Bootstrapper : BootstrapperBase
    {
        SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        //might as well make it look cleaner since we probably will not need these 3 methods
        protected override object GetInstance(Type serviceType, string key)
        => _container.GetInstance(serviceType, key);
        
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        =>_container.GetAllInstances(serviceType);

        protected override void BuildUp(object instance)
        => _container.BuildUp(instance);

        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<ViewModels.ConfigViewModel>();
            _container.Singleton<ViewModels.DecisionViewModel>();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            IoC.BuildUp(_container.GetInstance<ViewModels.ConfigViewModel>()); //config first so we can use it in decision viewmodel
            IoC.BuildUp(_container.GetInstance<ViewModels.DecisionViewModel>());
            DisplayRootViewFor<ViewModels.DecisionViewModel>();
        }
    }
}
