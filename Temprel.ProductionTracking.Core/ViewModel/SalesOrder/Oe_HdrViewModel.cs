using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class Oe_HdrViewModel : BaseViewModel
    {
        private NumberEntryViewModel orderNo;
        public NumberEntryViewModel OrderNo { get => orderNo; set { orderNo = value; } }

        public InformationViewViewModel CustomerId { get; set; }
        public InformationViewViewModel CustomerName { get; set; }
        public InformationViewViewModel OrderDate { get; set; }
        public InformationViewViewModel PromiseDate { get; set; }

        public Oe_HdrViewModel()
        {
            OrderNo = new NumberEntryViewModel { LabelText = "Order No:" };
            CustomerId = new InformationViewViewModel { LabelText = "Customer ID:" };
            CustomerName = new InformationViewViewModel { LabelText = "Customer Name:" };
            OrderDate = new InformationViewViewModel { LabelText = "Order Date:" };
            PromiseDate = new InformationViewViewModel { LabelText = "Promise Date:" };
            OrderNo.NumberSubmitted += OnNumberSubmitted;
        }


        public void OnNumberSubmitted(object source, EventArgs e)
        {
            //TODO: Kill this testing stuff later
            CustomerId.ContentText = "125889";
            CustomerName.ContentText = "Temprel Testing";
            OrderDate.ContentText = DateTime.Today.Date.ToShortDateString();
            PromiseDate.ContentText = DateTime.Today.AddDays(14).ToShortDateString();
            Console.WriteLine("Number Submitted: {0}", OrderNo.InputString);
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Title = "No Submitted!", Message = String.Format("Order No: {0} submitted", orderNo.Number), OkText = "Continue" });
            OrderNo.InputString = string.Empty;
        }
    }
}
