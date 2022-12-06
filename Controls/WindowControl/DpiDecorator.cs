using SnowMan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnowMan.Controls.WindowControl
{
    public class DpiDecorator : Decorator
    {
        public DpiDecorator()
        {
            const int DesignWidth = 1920;
            const int DesignHeight = 1080;
            this.Loaded += (s, e) =>
            {
                Matrix m = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
                ScaleTransform dpiTransform = new ScaleTransform(1 / m.M11, 1 / m.M22);
                double scaleX = 1 / m.M11;
                double scaleY = 1 / m.M22;

                double nWidth = ScreenManager.GetScreenWidth();
                double nHieght = ScreenManager.GetScreenHeight();
                dpiTransform = new ScaleTransform(nWidth / DesignWidth * scaleX, nHieght / DesignHeight * scaleY);


                if (dpiTransform.CanFreeze)
                    dpiTransform.Freeze();
                this.LayoutTransform = dpiTransform;
            };
        }
    }
}
