using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class NumberEntryViewModel : BaseViewModel
    {
        public string LabelText { get; set; }


        public string NoString { get; set; }

        public ICommand SubmitCommand { get; set; }

        public NumberEntryViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        //public EventHandler NumberSubmittedEventHandler(object source, EventArgs e);

        public event EventHandler<EventArgs> NumberSubmitted;

        private void Submit()
        {
            //TODO: Implement firing of event for submit
            //NOTE: This is quick and dirty testing to make sure this was firing
            //MessageBox.Show(String.Format("Submitting Order: {0}", NoString), "Test Please Clean me up later");

            OnNumberSubmitted();
        }

        protected virtual void OnNumberSubmitted()
        {
            NumberSubmitted?.Invoke(this, EventArgs.Empty);
        }
    }
}
