using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class SalesOrderViewModel : BaseViewModel
    {
        public Oe_HdrViewModel Oe_hdr;

        public Oe_LineViewModel Oe_Line;

        public SalesOrderViewModel()
        {
            Oe_hdr = new Oe_HdrViewModel();
            Oe_Line = new Oe_LineViewModel();

            //Hook Events
            Oe_hdr.OrderHeaderLoaded += Oe_Line.OnOrderHeaderLoaded;
        }
    }
}
