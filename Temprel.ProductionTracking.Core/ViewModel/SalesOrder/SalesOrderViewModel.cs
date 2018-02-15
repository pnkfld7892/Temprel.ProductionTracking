using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class SalesOrderViewModel : BaseViewModel
    {
        public Oe_HdrViewModel Oe_hdr { get; set; }

        public Oe_LineViewModel Oe_Line { get; set; }

        public SalesOrderViewModel()
        {
           Oe_hdr = new Oe_HdrViewModel();
            Oe_Line = new Oe_LineViewModel();

            //Hook Events
            Oe_hdr.OrderHeaderLoaded += Oe_Line.OnOrderHeaderLoaded;
            Oe_Line.OrderUpdated += Oe_hdr.OnOrderUpdated;
        }

        public override void Clear()
        {
            Oe_hdr.Clear();
            Oe_Line.Clear();
        }
    }
}
