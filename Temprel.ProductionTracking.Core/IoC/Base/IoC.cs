﻿using Ninject;
using Temprel.ProductionTracking.Data;
namespace Temprel.ProductionTracking.Core
{
    ///<summary>
    ///
    ///</summary>
    public static class IoC
    {
        #region public properties
        /// <summary>
        /// Kernel of our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the IUIManager
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to access the app view model
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to access the app view model
        /// </summary>
        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();

        public static Data.TmprlBusinessContext Context => IoC.Get<TmprlBusinessContext>();


        #endregion


        #region Construction
        /// <summary>
        /// sets up IoC container and binds all info
        /// NOTE: Must be called at app startup
        /// </summary>
        /// 

        public static void Setup()
        {
            //Bind all required view models
            BindAllIoCObjects();
        }
        /// <summary>
        /// Binds All singleton viewmodels
        /// </summary>
        private static void BindAllIoCObjects()
        {
            //bind to a single instance of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            //bind to a single instance of settings view model
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());

        }
        #endregion
        /// <summary>
        /// Get's a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
