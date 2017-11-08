using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class TextEntryViewModel : BaseViewModel
    {
        public string LabelText { get; set; }

        public string NoString { get; set; }

        public ICommand SubmitCommand { get; set; }

        public TextEntryViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        private void Submit()
        {
            //TODO: Implement firing of event for submit
            //MessageBox.Show(String.Format("Submitting Text: {0}", NoString),"Test Please Clean me up later");
        }
    }
}
