using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Temprel.ProductionTracking.Data;

namespace Temprel.ProductionTracking.Core
{
    public class Oe_HdrViewModel : BaseViewModel
    {
        #region Private members
        private NumberEntryViewModel orderNo;
        private Data.Oe_HdrModel hdrModel;
        
        //NOTE: attempting to forego private context's for a static inside IOC
        //private  Data.TmprlBusinessContext context;
        #endregion


        #region Public Properties
        public NumberEntryViewModel OrderNo { get => orderNo; set { orderNo = value; } }


        public InformationViewViewModel CustomerId { get; set; }
        public InformationViewViewModel CustomerName { get; set; }
        public InformationViewViewModel OrderDate { get; set; }
        public InformationViewViewModel PromiseDate { get; set; }

        public Oe_HdrViewModel test { get; set; }
        #endregion

        #region Ctor
        public Oe_HdrViewModel()
        {
            OrderNo = new NumberEntryViewModel { LabelText = "Order No:" };
            SetupInformationViewModels();
            OrderNo.NumberSubmitted += OnNumberSubmitted;
        }


        #endregion

        #region Event Handlers

        public event EventHandler<OrderHeaderLoadedEventArgs> OrderHeaderLoaded;

        public virtual void OnOrderHeaderLoaded()
        {
            OrderHeaderLoaded?.Invoke(this, new OrderHeaderLoadedEventArgs(hdrModel.Hdr.order_no));
        }

        #endregion

        #region Methods
        public void OnNumberSubmitted(object source, EventArgs e)
        {
            //TODO: Kill this testing stuff later
            //CustomerId.ContentText = "125889";
            //CustomerName.ContentText = "Temprel Testing";
            //OrderDate.ContentText = DateTime.Today.Date.ToShortDateString();
            //PromiseDate.ContentText = DateTime.Today.AddDays(14).ToShortDateString();
            //Console.WriteLine("Number Submitted: {0}", OrderNo.InputString);
            //IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Title = "No Submitted!", Message = String.Format("Order No: {0} submitted", orderNo.Number), OkText = "Continue" });
            //OrderNo.InputString = string.Empty;

            try
            {
                SetupInformationViewModels();
                //attempt to find order
                hdrModel = IoC.Context.GetOe_Hdr(OrderNo.InputString);
                //if success start to fill in fields

                //customer information
                CustomerId.ContentText = hdrModel.Customer.customer_id.ToString("0");
                CustomerName.ContentText = hdrModel.Customer.customer_name;

                //order information
                OrderDate.ContentText = (hdrModel.Hdr.order_date).Value.ToShortDateString();
                PromiseDate.ContentText = (hdrModel.Hdr.promised_date).Value.ToShortDateString();
                OrderHeaderLoaded(this,new OrderHeaderLoadedEventArgs(hdrModel.Hdr.order_no));
            }
            catch(ArgumentException ex)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Title = "Exception",Message = ex.Message });
            }
        }

        public void OnOrderUpdated(object sender, EventArgs e)
        {
            //IoC.UI.ShowMessage(new MessageBoxDialogViewModel { Message ="Hit inside Oe_HdrVM" });
            Clear();
        }

        private void Clear()
        {
            OrderNo.InputString = string.Empty;
            hdrModel = new Oe_HdrModel();
            //customer information
            CustomerId.ContentText = String.Empty;
            CustomerName.ContentText = String.Empty;

            //order information
            OrderDate.ContentText = String.Empty;
            PromiseDate.ContentText = String.Empty;
        }

        private void SetupInformationViewModels()
        {
            CustomerId = new InformationViewViewModel { LabelText = "Customer ID:" };
            CustomerName = new InformationViewViewModel { LabelText = "Customer Name:" };
            OrderDate = new InformationViewViewModel { LabelText = "Order Date:" };
            PromiseDate = new InformationViewViewModel { LabelText = "Promise Date:" };
        }
        #endregion
    }
}
