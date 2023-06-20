using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chemistry_app.CustomProperties
{
    public class BorderAspectRatio : Border
    {
        public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register
            (
                "AspectRatioProperty",
                typeof(double),
                typeof(BorderAspectRatio),
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsMeasure)
            );
        public double AspectRatio
        { 
            get { return (double)GetValue(AspectRatioProperty); }
            set { SetValue(AspectRatioProperty, value); }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            if (double.IsNaN(Width) && double.IsNaN(Height) && !double.IsInfinity(constraint.Width))
            {
                constraint = new Size(Width, Width * AspectRatio);
            }
            
            return base.MeasureOverride(constraint);
        }
    }
}
