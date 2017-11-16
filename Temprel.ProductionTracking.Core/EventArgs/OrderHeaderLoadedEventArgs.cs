using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class OrderHeaderLoadedEventArgs : EventArgs
    {

        #region public properties
        public string OrderNo { get; private set; }
        #endregion

        public OrderHeaderLoadedEventArgs(string orderNo)
        {
            OrderNo = orderNo;
        }
    }
}
