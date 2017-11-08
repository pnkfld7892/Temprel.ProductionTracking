using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    public class DialogWindowViewModel : WindowViewModel
    {
        public string Title { get; set; }
        
        public Control Content { get; set; }

        public DialogWindowViewModel(Window window):base(window)
        {
            WindowMinHeight = 100;
            WindowMinWidth = 250;

            TitleHeight = 30;
        }
    }
}
