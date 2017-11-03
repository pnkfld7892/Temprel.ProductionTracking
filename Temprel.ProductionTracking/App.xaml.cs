using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Setup app
            ApplicationSetup();

            //show window

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            //TODO: create UIManager class and turn this binding on
            //IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
