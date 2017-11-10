using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Temprel.ProductionTracking
{
    public  class BaseLabelControl : UserControl
    {

        public virtual GridLength LabelWidth { get; set; }

        public virtual TextBlock LabelRef { get; }
    }
}
