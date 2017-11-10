using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Temprel.ProductionTracking
{
    /// <summary>
    /// Interaction logic for InformationViewControl.xaml
    /// </summary>
    public partial class InformationViewControl : BaseLabelControl
    {
        #region Ctor
        public InformationViewControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Dependency Properties
        /// <summary>
        /// The Label Width of the control
        /// </summary>

        public override  GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        public override TextBlock LabelRef => Label;

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(InformationViewControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));


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
                (d as InformationViewControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception ex)
            {
                ///Make dev aware of potential issue
                Debugger.Break();

                (d as InformationViewControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }
        #endregion
    }
}
