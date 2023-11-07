using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;
using Windows.UI.ViewManagement;

namespace final_project3.Classes
{
    public enum Shape
    {
        circle, rectangle
    }

   
    public class Settings_class
    {
        //const
        public const double Imaginary_Screen_Height = 1000;
        public const double imaginary_Screen_Width = 1920;



        public static void Change_To_Right_Screen_Ratio()
        {
            var window = ApplicationView.GetForCurrentView();
            
            double ratio = imaginary_Screen_Width / Imaginary_Screen_Height;

            //
            //_ratio.Text = window.VisibleBounds.Width + " *" + window.VisibleBounds.Height + " ratio: " + window.VisibleBounds.Width / window.VisibleBounds.Height;
            if (window.VisibleBounds.Width / window.VisibleBounds.Height != ratio)
            {
                double newWidth = window.VisibleBounds.Height * ratio;

                window.TryResizeView(new Windows.Foundation.Size((int)newWidth, (int)window.VisibleBounds.Height));
            }
        }
    }
    
}
