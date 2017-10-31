using System;
using System.Windows;

namespace Temprel.ProductionTracking
{
    ///<summary>
    ///Base
    ///</summary>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {
        #region Public Events
        /// <summary>
        /// FIred when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        /// <summary>
        /// Fired when the value changes, even if it's the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, e) => { };
        #endregion

        #region Public Properties
        public static Parent Instance { get; private set; } = new Parent();
        #endregion

        #region Attached Property Definintions
        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(Property),
            typeof(BaseAttachedProperty<Parent, Property>),
            new UIPropertyMetadata(
                default(Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                ));

        /// <summary>
        /// THe callback evn when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI elemtn that had it's property changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);

            //call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);

        }

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            //Call event listeners
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            //return object
            return value;
        }

        /// <summary>
        /// Get the Attached property
        /// </summary>
        /// <param name="d">The element to get hte property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Set the attached property
        /// </summary>
        /// <param name="d">The element to get hte property from</param>
        /// <param name="value">the value to set the property to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached proeprty of this attached property is chnaged
        /// </summary>
        /// <param name="sender">The UI element that this property was changed from</param>
        /// <param name="e">The args for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// the method that is called when any attched property of this type is changed even when the data is the same
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="value">The arguments for this event</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }
        #endregion
    }
}
