using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Data.Entities
{
    public class status
    {
        public status()
        {

        }

        [Key]
        public int status_id { get; set; }

        public string description { get; set;}

        override
        public string ToString()
        {
            return this.description;
        }

    }
}
