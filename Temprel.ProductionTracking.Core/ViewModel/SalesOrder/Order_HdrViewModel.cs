using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class Order_HdrViewModel : BaseViewModel
    {
        private NumberEntryViewModel orderNo;
        public NumberEntryViewModel OrderNo { get => orderNo; set { orderNo = value; } }

        public Order_HdrViewModel() : this(new NumberEntryViewModel())
        {
            //OrderNo = new NumberEntryViewModel();
            //OrderNo.NumberSubmitted += OnNumberSubmitted;
        }

        public Order_HdrViewModel(BaseViewModel vm)
        {
            OrderNo = (NumberEntryViewModel)vm;
            OrderNo.NumberSubmitted += OnNumberSubmitted;
        }

        public void OnNumberSubmitted(object source, EventArgs e)
        {
            Console.WriteLine("Number Submitted: {0}", OrderNo.NoString);
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Title = "No Submitted!", Message = String.Format("Order No: {0} submitted", orderNo.Number), OkText = "Continue" });
            OrderNo.NoString = string.Empty;
        }
    }
}
