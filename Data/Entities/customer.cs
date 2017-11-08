using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Data.Entities
{
    public class customer
    {
        public customer()
        {

        }
        [Key]
        public decimal customer_id { get; set; }
        public string customer_name { get; set; }
    }
}
