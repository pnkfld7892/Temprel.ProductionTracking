using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Temprel.ProductionTracking
{
    ///<summary>
    /// static class holding the defnintions of our animations
    ///</summary>
    public static class FrameworkElementAnimations
    {
        #region Slide In/Out
        /// <summary>
        /// Slides and Fades an Element In
        /// </summary>
        /// <param name="element">the Framework Element to animate</param>
        /// <param name="dir">the Direction of the Animation</param>
        /// <param name="firstLoad">Inidicates wether this is The first load of the element or not</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="keepMargin">Indicates whether to keep the element width the same or not</param>
        /// <param name="size">The height/width to animate to. if not specified, the element height/width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideDirection dir, bool firstLoad, float seconds = 0.2f, bool keepMargin = true, int size = 0)
        {
            var sb = new Storyboard();

            switch (dir)
            {
                case AnimationSlideDirection.Left:
                    sb.AddSlideFromLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Top:
                    sb.AddSlideFromTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Right:
                    sb.AddSlideFromRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideFromBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
        /// <summary>
        /// Slides and Element out
        /// </summary>
        /// <param name="element">the Framework Element to animate</param>
        /// <param name="dir">the Direction of the Animation</param>
        /// <param name="firstLoad">Inidicates wether this is The first load of the element or not</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="keepMargin">Indicates whether to keep the element width the same or not</param>
        /// <param name="size">The height/width to animate to. if not specified, the element height/width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideDirection dir, float seconds = 0.2f, bool keepMargin = true, int size = 0)
        {
            var sb = new Storyboard();

            switch (dir)
            {
                case AnimationSlideDirection.Left:
                    sb.AddSlideToLeft(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Top:
                    sb.AddSlideToTop(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Right:
                    sb.AddSlideToRight(seconds, size == 0 ? element.ActualWidth : size, keepMargin: keepMargin);
                    break;
                case AnimationSlideDirection.Bottom:
                    sb.AddSlideToBottom(seconds, size == 0 ? element.ActualHeight : size, keepMargin: keepMargin);
                    break;
            }

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            if (seconds != 0)
                element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));

            element.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Fade In/Out
        /// <summary>
        /// Fades element in
        /// </summary>
        /// <param name="element">The target FrameworkElement</param>
        /// <param name="firstLoad">Indicates if this is the first time the element has been loaded</param>
        /// <param name="seconds">The animation time</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, bool firstLoad, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds);

            sb.Begin(element);

            if (seconds != 0 || firstLoad)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
        /// <summary>
        /// Fades an Element Out
        /// </summary>
        /// <param name="element">The target FrameworkElement</param>
        /// <param name="firstLoad">Indicates if this is the first time the element has been loaded</param>
        /// <param name="seconds">The animation time</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.Begin(element);

            if (seconds != 0)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
            element.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
