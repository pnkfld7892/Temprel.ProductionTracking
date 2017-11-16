using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class Oe_LineDesignModel : Oe_LineViewModel
    {
        #region Singleton
        public static Oe_LineDesignModel Instance = new Oe_LineDesignModel();
        #endregion

        #region ctor
        public Oe_LineDesignModel()
        {
            this.Oe_LineModel.Lines = new List<Data.Entities.oe_line>
            {
                new Data.Entities.oe_line
                {
                    line_no = 1,
                    item_id = "T52J",
                    status_id = 1
                },
                new Data.Entities.oe_line
                {
                    line_no = 2,
                    item_id = "B52J",
                    status_id = 4
                },
            };
        }
        #endregion
    }
}
