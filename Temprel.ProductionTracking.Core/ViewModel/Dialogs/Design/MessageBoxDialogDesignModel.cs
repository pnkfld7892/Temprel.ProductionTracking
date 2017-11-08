using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
   public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Singleton
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();
        #endregion

        #region ctor
        public MessageBoxDialogDesignModel()
        {
            Message = "Design Time";
            OkText = "Design OK";
        }
        #endregion
    }
}
