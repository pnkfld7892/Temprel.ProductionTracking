using System;
using System.Diagnostics;
using System.Globalization;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///
    ///</summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //find appropriate page
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                //case ApplicationPage.SalesOrder:
                //    return new SalesOrderPage();
                //case ApplicationPage.ProdOrder:
                //    return new ProdOrderPage();
                default:
                    Debugger.Break();
                    return null;

            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
