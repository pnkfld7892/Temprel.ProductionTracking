using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class NumberEntryViewModel
    {
        public string LabelText { get; set; }

        public string NoString { get; set; }

        public ICommand SubmitCommand { get; set; }

        public NumberEntryViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
            //TODO: Implement firing of event for submit
            MessageBox.Show("Submitting Order: {0}", NoString);
        }
    }
}
