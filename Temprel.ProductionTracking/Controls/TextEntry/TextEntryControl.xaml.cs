using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Temprel.ProductionTracking
{
    /// <summary>
    /// Interaction logic for NumberEntry.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {

        #region Dependency Properties
        /// <summary>
        /// The Label Width of the control
        /// </summary>

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));


        #endregion

        #region Ctor
        public TextEntryControl()
        {
            InitializeComponent();
        } 
        #endregion

        #region Depedency Callbacks
        /// <summary>
        /// Called When the label width has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {


                //set col def width to new value
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
                ///Make dev aware of potential issue
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }
        #endregion
    }
}
