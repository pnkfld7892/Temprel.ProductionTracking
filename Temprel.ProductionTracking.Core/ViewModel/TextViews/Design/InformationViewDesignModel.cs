using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
    public class InformationViewDesignModel : InformationViewViewModel
    {
        #region singleton
        public static InformationViewDesignModel Instance = new InformationViewDesignModel();
        #endregion

        #region ctor
        public InformationViewDesignModel()
        {
            LabelText = "Desgin Time:";
            ContentText = "Designing UI is so much fun!";
        }
#endregion
    }
}
