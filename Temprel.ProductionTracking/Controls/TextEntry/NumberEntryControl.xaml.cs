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
    public partial class NumberEntryControl : UserControl
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
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(NumberEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));


        #endregion

        #region Ctor
        public NumberEntryControl()
        {
            InitializeComponent();
        } 
        #endregion

        /// <summary>
        /// Handling text into to restrict to numbers only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Input_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

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
                (d as NumberEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
                ///Make dev aware of potential issue
                Debugger.Break();

                (d as NumberEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }
        #endregion
    }
}
