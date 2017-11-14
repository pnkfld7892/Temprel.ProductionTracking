using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Temprel.ProductionTracking
{
 public class IsFocusedProperty: BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control) || DesignerProperties.GetIsInDesignMode(sender))
                return;
            control.Loaded += (s, se) => control.Focus();
        }
    }
}
