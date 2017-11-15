using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Data
{
    public class Oe_LineModel
    {
        public ICollection<Entities.oe_line> Lines;

        public Oe_LineModel(): this (new List<Entities.oe_line>())
        {

        }

        public Oe_LineModel(ICollection<Entities.oe_line> lines)
        {
            this.Lines = lines;
        }
    }
}
