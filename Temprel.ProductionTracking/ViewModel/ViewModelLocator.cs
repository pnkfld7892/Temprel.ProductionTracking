using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///
    ///</summary>
    public class ViewModelLocator
    {
        #region Public Properties
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
       
        #endregion
    }
}
