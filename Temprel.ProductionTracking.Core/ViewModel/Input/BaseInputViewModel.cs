using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class BaseInputViewModel : BaseViewModel
    {
        public string LabelText { get; set; }


        public string NoString { get; set; }

        public ICommand SubmitCommand { get; set; }

        protected virtual void Submit()
        {

        }
    }
}
