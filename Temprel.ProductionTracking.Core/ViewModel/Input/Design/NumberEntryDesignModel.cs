using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class NumberEntryDesignModel : NumberEntryViewModel
    {
        #region singleton
        public static NumberEntryDesignModel Instance => new NumberEntryDesignModel();
        #endregion

        #region ctor
        public NumberEntryDesignModel()
        {
            LabelText = "Order No:";

        }
        #endregion
    }
}
