using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }

        public Task Shutdown(string message)
        {
            ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Fatal Error",
                Message = String.Format("Fatal error: {0}", message),
            });
                Application.Current.MainWindow.Close();
            return null;
        }
    }
}
