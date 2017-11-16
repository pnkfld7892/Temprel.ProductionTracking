using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Core
{
   public class SalesOrderDesignModel: SalesOrderViewModel
    {
        #region singleton
        public static SalesOrderDesignModel instance = new SalesOrderDesignModel();
        #endregion
    }
}
