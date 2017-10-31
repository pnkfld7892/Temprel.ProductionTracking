using Temprel.ProductionTracking.Core;
using System.Diagnostics;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///helper methods to convert between application page enum and actual base page derivative
    ///</summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes a <see cref="ApplicationPage"/> and a viewmodel, if any, and creates the desired page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            //find appropriate page
            switch(page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);
                //case ApplicationPage.SalesOrder:
                //    return new SalesOrderPage();
                //case ApplicationPage.ProdOrder:
                //    return new ProdOrderPage();
                default:
                    Debugger.Break();
                    return null;

            }
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            //find the application page that matches the base page
            if (page is LoginPage)
                return ApplicationPage.Login;
            //if (page is SalesOrderPage)
            //    return ApplicationPage.SalesOrder;
            //if (page is ProdOrderPage)
            //    return ApplicationPage.ProdOrder;

            //Alert Debugger of issue
            Debugger.Break();
            return default(ApplicationPage);
        }

    }
}
