using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    /// <summary>
    /// A view model for a TextView control
    /// </summary>
    public class InformationViewViewModel : BaseViewModel
    {
        /// <summary>
        /// The label text
        /// </summary>
        public string LabelText { get; set; }
        /// <summary>
        /// The Content to display
        /// </summary>
        public string ContentText { get; set; }
    }
}
