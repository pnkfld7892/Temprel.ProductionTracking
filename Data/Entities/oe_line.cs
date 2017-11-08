using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Data.Entities
{
    public class oe_line
    {
        public oe_line()
        {
                
        }
        [Key]
        [Column(Order =0)]
        [StringLength(8)]
        public string order_no { get; set; }
        [Key]
        [Column(Order = 1)]
        public decimal line_no { get; set; }

        public string item_id { get; set; }

        public oe_hdr oe_hdr { get; set; }

        public int? status_id { get; set; }

        [ForeignKey("status_id")]
        public virtual status status { get; set; }
    }
}
