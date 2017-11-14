using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temprel.ProductionTracking.Data.Entities;

namespace Temprel.ProductionTracking.Data
{
    /// <summary>
    /// Data model for an Oe_Hdr with a reference to it's customer.
    /// </summary>
    public class Oe_HdrModel
    {
        #region ctor
        public Oe_HdrModel():this(new oe_hdr(),new customer())
        {

        }

        public Oe_HdrModel(oe_hdr hdr,customer cust)
        {
            Hdr = hdr;
            Customer = cust;
        }
        #endregion

        #region public properties
        public oe_hdr Hdr { get; private set; }

        public customer Customer { get; private set; }
        #endregion
    }
}
