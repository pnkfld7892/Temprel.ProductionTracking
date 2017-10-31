using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Temprel.ProductionTracking
{
    /// <summary>
    /// A Base calss to run any animation method when a boolean is set to true and a reverse animation
    /// when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent>: BaseAttachedProperty<Parent,bool>
        where Parent:BaseAttachedProperty<Parent,bool>, new()
    {
        #region Protected Properties
        /// <summary>
        /// True if this is the very first time the value has been updated
        /// Used to Make sure we run the logic at least once during first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mAlreadyLoaded = new Dictionary<DependencyObject, bool>();

        /// <summary>
        /// The most recent value used if we get a value changed vefore we do the first load
        /// </summary>
        protected Dictionary<DependencyObject, bool> mFirstLoadValue = new Dictionary<DependencyObject, bool>();
        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //get framework element
            if (!(sender is FrameworkElement element))
                return;
            //Dont fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && mAlreadyLoaded.ContainsKey(sender))
                return;

            //on first load
            if (!mAlreadyLoaded.ContainsKey(sender))
            {
                //flag that we are in first load but have not finished
                mAlreadyLoaded[sender] = false;

                //start hidden
                if (!(bool)value)
                    element.Visibility = Visibility.Hidden;

                //create a single selfunkookable event
                //for the elements Loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {
                    element.Loaded -= onLoaded;

                    //slieght delay after load is needed for some elements to get laid out
                    await Task.Delay(5);

                    DoAnimation(element, mFirstLoadValue.ContainsKey(sender) ? mFirstLoadValue[sender] : (bool)value, true);

                    mAlreadyLoaded[sender] = true;
                };

                //hook loaded event
                element.Loaded += onLoaded;
            }

            else if (mAlreadyLoaded[sender] == false)
                mFirstLoadValue[sender] = (bool)value;
            else
                DoAnimation(element, (bool)value, false);

        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="value">The new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    public class AnimateSlideInFromLeftProperty: AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        /// <summary>
        /// Animates a framework element sliding it in from the left on show
        /// and now
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="firstLoad"></param>
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                //animate in
                await element.SlideAndFadeInAsync(AnimationSlideDirection.Left, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //animate out
                await element.SlideAndFadeOutAsync(AnimationSlideDirection.Left, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    public class AnimateSlideInFromRightProperty: AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.SlideAndFadeInAsync(AnimationSlideDirection.Right, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                await element.SlideAndFadeOutAsync(AnimationSlideDirection.Right, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }


    /// <summary>
    /// Animates a framework element sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// NOTE: Keeps the margin
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInAsync(AnimationSlideDirection.Bottom, firstLoad, firstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideDirection.Bottom, firstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a framework element fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                // Animate in
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                // Animate out
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);
        }
    }
}
