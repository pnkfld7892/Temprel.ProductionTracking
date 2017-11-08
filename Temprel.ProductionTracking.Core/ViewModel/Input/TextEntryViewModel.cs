using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Temprel.ProductionTracking.Core
{
    public class TextEntryViewModel : BaseInputViewModel
    {

        public TextEntryViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
        }



        protected override void Submit()
        {
            //TODO: Implement firing of event for submit Text
            //MessageBox.Show(String.Format("Submitting Text: {0}", NoString),"Test Please Clean me up later");
        }
    }
}
