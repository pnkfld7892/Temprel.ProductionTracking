using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using Temprel.ProductionTracking.Core;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///Base class for all pages
    ///</summary>
    public class BasePage : UserControl
    {
        #region Public Properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// the time to animate
        /// </summary>
        public float AnimateSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out
        /// when loaded into new frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }
        #endregion

        #region Constructor
        ///<summary>
        ///Default Constructor
        ///</summary>
        public BasePage()
        {
            //Return if In design mode
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;
            //hook page loaded
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            else
                await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch(PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromLeft:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Left, false, AnimateSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
                case PageAnimation.SlideAndFadeInFromTop:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Top, false, AnimateSeconds, size: (int)Application.Current.MainWindow.Height);
                    break;
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Right, false, AnimateSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
                case PageAnimation.SlideAndFadeInFromBottom:
                    await this.SlideAndFadeInAsync(AnimationSlideDirection.Bottom, false, AnimateSeconds, size: (int)Application.Current.MainWindow.Height);
                    break;
                case PageAnimation.FadeIn:
                    await this.FadeInAsync(false, AnimateSeconds);
                    break;
            }
        }
        /// <summary>
        /// Animates Page Out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;
            switch(PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Left, AnimateSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
                case PageAnimation.SlideAndFadeOutToTop:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Top, AnimateSeconds, size: (int)Application.Current.MainWindow.Height);
                    break;
                case PageAnimation.SlideAndFadeOutToRight:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Right, AnimateSeconds, size: (int)Application.Current.MainWindow.Width);
                    break;
                case PageAnimation.SlideAndFadeOutToBottom:
                    await this.SlideAndFadeOutAsync(AnimationSlideDirection.Bottom, AnimateSeconds, size: (int)Application.Current.MainWindow.Height);
                    break;
                case PageAnimation.FadeOut:
                    await this.FadeOutAsync(seconds: AnimateSeconds);
                    break;
            }
        }
        #endregion
    }

    /// <summary>
    /// Base page with view model support
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : BasePage
        where VM: BaseViewModel, new()
    {
        private VM mViewModel;

        #region Public Properties
        public VM ViewModel
        {
            get => mViewModel;

            set
            {
                if (mViewModel == value)
                    return;
                mViewModel = value;
                DataContext = mViewModel;
            }
        }
        #endregion

        #region Ctor

        public BasePage() : base()
        {
            ViewModel = new VM();
        }
        #endregion

    }
}
