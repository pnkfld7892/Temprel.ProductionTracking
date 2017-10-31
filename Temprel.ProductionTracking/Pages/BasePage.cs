﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Temprel.ProductionTracking.Core;

namespace Temprel.ProductionTracking
{/// <summary>
 /// THe base page for all pages to gain mase funcitonality
 /// </summary>
    public class BasePage : UserControl
    {

        #region Private Members
        private object mViewModel;
        #endregion

        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out
        /// when loaded into a new frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                if (mViewModel == value)
                    return;
                //update vm
                mViewModel = value;

                //Fire viewmodel changed
                OnViewModelChanged();

                //reset datacontext
                DataContext = mViewModel;
            }
        }
        #endregion

        #region Ctor
        public BasePage()
        {
            // dont' animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //hook page loaded event
            Loaded += BasePage_LoadedAsync;

        }
        #endregion

        #region Animation Load /Unload

        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //if we should animate out on load
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            //otherwise
            else
                //animate in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {

            //make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
            }

        }

        /// <summary>
        /// animates page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            //make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;
            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Left, SlideSeconds);
                    //this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;
                case PageAnimation.SlideAndFadeOutToRight:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Right, SlideSeconds);
                    //this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Fired when view model changed
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }
    }

    /// <summary>
    /// A base page with added viwe model support
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {



        #region Public Properties

        /// <summary>
        /// The view model assoc'd with the page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Ctor
        /// <summary>
        /// Default Ctor
        /// </summary>
        public BasePage() : base()
        {
            ViewModel = IoC.Get<VM>();

        }

        /// <summary>
        ///  Ctor wiht specific viewmodel
        /// </summary>
        /// <param name="specificViewModel">The specific viewmodel to use, if any</param>
        public BasePage(VM specificViewModel = null) : base()
        {
            //Set dpecific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            //create default viewmodel
            //Using the IoC to bind to the passed in viewmodel
            //if onedoens't exist a new VM of expected type will be created.
            else
                ViewModel = IoC.Get<VM>();

        }
        #endregion


    }
}
