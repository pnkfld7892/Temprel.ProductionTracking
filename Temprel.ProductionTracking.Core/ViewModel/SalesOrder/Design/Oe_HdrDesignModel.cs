using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class Oe_HdrDesignModel : Oe_HdrViewModel
    {
        #region Singleton
        public static Oe_HdrDesignModel Instance = new Oe_HdrDesignModel();
        #endregion

        #region ctor
        public Oe_HdrDesignModel()
        {
            OrderNo.LabelText = "Order No:";
            OrderNo.InputString = "123467";
            CustomerId.LabelText = "Customer Id:";
            CustomerId.ContentText = "15879";
            CustomerName.LabelText = "Customer Name:";
            CustomerName.ContentText = "Temprel Test";
            OrderDate.LabelText = "Order Date:";
            PromiseDate.LabelText = "Promise Date:";
            OrderDate.ContentText = DateTime.Today.ToShortDateString();
            PromiseDate.ContentText = DateTime.Today.AddDays(14).ToShortDateString();
        }
        #endregion
    }
}
