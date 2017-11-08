using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Temprel.ProductionTracking.Data.Entities
{
    public class prod_order_hdr
    {
        public prod_order_hdr()
        {

        }

        [Key]
        public decimal prod_order_number { get; set; }

        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }

        public virtual ICollection<prod_order_line> prod_order_line { get; set; }
    }
}
