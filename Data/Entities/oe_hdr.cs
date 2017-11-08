using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Temprel.ProductionTracking.Data.Entities
{
    public class oe_hdr
    {
        public oe_hdr() { }
        [Key]
        [StringLength(8)]
        public string order_no { get; set; }
        public decimal customer_id { get; set; }
        public string completed { get; set; }
        public DateTime? order_date { get; set; }

        public DateTime? promised_date { get; set; }

        public customer customer { get; set; }
        public virtual ICollection<oe_line> oe_line { get; set; }
    }
}
