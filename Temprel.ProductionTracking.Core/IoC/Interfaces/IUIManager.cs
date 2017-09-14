using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
   public interface IUIManager
    {
        /// <summary>
        /// Displays a single message box to user
        /// </summary>
        /// <param name="viewModel">the view model</param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
