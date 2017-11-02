using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    /// <summary>
    /// Interaction logic for SalesOrderPage.xaml
    /// </summary>
    public partial class SalesOrderPage : BasePage<SalesOrderViewModel>
    {
        public SalesOrderPage()
        {
            InitializeComponent();
        }

        public SalesOrderPage(SalesOrderViewModel viewModel):base(viewModel)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nButton to Switch Pages Clicked\n--------------------------------------------------------------");
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login, new LoginViewModel());
        }
    }
}
