using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Temprel.ProductionTracking.Data.Entities
{
    public class prod_order_line
    {
        public prod_order_line()
        {

        }
        [Key]
        [Column(Order =0)]
        public decimal prod_order_number { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal line_number { get; set; }

        public string item_id { get; set; }

        public decimal qty_to_make { get; set; }

        public int? status_id { get; set; }

        [ForeignKey("status_id")]
        public virtual status status { get; set; }

    }
}
