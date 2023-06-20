using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chemistry_app.CustomProperties
{
    internal class MendeleevContentControl : ContentControl
    {
        public static readonly DependencyProperty AtomicNumberProperty =
        DependencyProperty.Register("AtomicNumber", typeof(string), typeof(MendeleevContentControl));

        public string AtomicNumber
        {
            get { return (string)GetValue(AtomicNumberProperty); }
            set { SetValue(AtomicNumberProperty, value); }
        }

        public static readonly DependencyProperty AtomicWeightProperty =
        DependencyProperty.Register("AtomicWeight", typeof(string), typeof(MendeleevContentControl));

        public string AtomicWeight
        {
            get { return (string)GetValue(AtomicWeightProperty); }
            set { SetValue(AtomicWeightProperty, value); }
        }
    }
}
