using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class TextEntryDesignModel : TextEntryViewModel
    {
        #region singleton
        public static TextEntryViewModel Instance => new TextEntryViewModel();
        #endregion

        #region ctor
        public TextEntryDesignModel()
        {
            LabelText = "Text Entry:";

        }
        #endregion
    }
}
