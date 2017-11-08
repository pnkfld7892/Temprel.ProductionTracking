using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temprel.ProductionTracking.Data.Entities;

namespace Temprel.ProductionTracking.Data.Models
{
    public class OrderModel
    {
        private oe_hdr hdr;
        private ICollection<oe_line> lines;
        private customer cust;

        public OrderModel():this(new oe_hdr(), new List<oe_line>(),new customer())
        {

        }

        public OrderModel(oe_hdr hdr, ICollection<oe_line> lines, customer cust)
        {
           
            this.hdr = hdr;
            this.lines = lines;
            this.cust = cust;
        }

        public oe_hdr Hdr
        {
            get { return hdr; }
        }

        public ICollection<oe_line> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public customer Customer
        {
            get { return cust; }
        }
    }
}
