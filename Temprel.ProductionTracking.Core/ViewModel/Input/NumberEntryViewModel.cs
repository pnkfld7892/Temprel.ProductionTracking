using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class NumberEntryViewModel : BaseInputViewModel
    {
        #region Public Properties
        public int Number { get; set; }
        #endregion

        public NumberEntryViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }

        //public EventHandler NumberSubmittedEventHandler(object source, EventArgs e);

        public event EventHandler<EventArgs> NumberSubmitted;

        protected override void Submit()
        {
            //TODO: Implement firing of event for submit
            //NOTE: This is quick and dirty testing to make sure this was firing
            //MessageBox.Show(String.Format("Submitting Order: {0}", NoString), "Test Please Clean me up later");
            if (!String.IsNullOrEmpty(NoString))
            {
                try
                {
                    Number = int.Parse(NoString);
                    OnNumberSubmitted();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(ArgumentNullException))
                    {
                        IoC.UI.ShowMessage( new MessageBoxDialogViewModel
                        {
                            Title = "No number!",
                            Message = "You need to enter a number!"
                        });
                    }
                }
            }
            else
            {
                return;
            }

        }

        protected virtual void OnNumberSubmitted()
        {
            NumberSubmitted?.Invoke(this, EventArgs.Empty);
        }
    }
}
