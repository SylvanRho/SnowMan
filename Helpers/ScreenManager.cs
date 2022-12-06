using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SnowMan.Helpers
{
    public class ScreenManager
    {
        /// <summary>
        /// 获取DPI百分比
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public static double GetDpiRatio(Window window)
        {
            var currentGraphics = Graphics.FromHwnd(new WindowInteropHelper(window).Handle);
            return currentGraphics.DpiX / 96;
        }

        public static double GetDpiRatio()
        {
            return GetDpiRatio(Application.Current.MainWindow);
        }

        public static double GetScreenHeight()
        {
            return SystemParameters.PrimaryScreenHeight * GetDpiRatio();
        }

        public static double GetScreenActualHeight()
        {
            return SystemParameters.PrimaryScreenHeight;
        }

        public static double GetScreenWidth()
        {
            return SystemParameters.PrimaryScreenWidth * GetDpiRatio();
        }

        public static double GetScreenActualWidth()
        {
            return SystemParameters.PrimaryScreenWidth;
        }
    }
}
