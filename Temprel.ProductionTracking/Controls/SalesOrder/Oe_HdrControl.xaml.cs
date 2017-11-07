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
    /// Interaction logic for Oe_HdrControl.xaml
    /// </summary>
    public partial class Oe_HdrControl : UserControl
    {
        public Oe_HdrControl()
        {
            InitializeComponent();
            DataContext = new Order_HdrViewModel { OrderNo = new NumberEntryViewModel { LabelText = "Order no:" } };
        }
    }
}
