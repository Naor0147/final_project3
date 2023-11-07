using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{
    class Point_f
    {

        public double img_x, img_y;

        public double real_x, real_y;

        private Canvas _canvas;

        public Point_f(double x, double y,Canvas canvas)
        {
            img_x = x;
            img_y = y;
            update_Points();
        }
        public void update_Points()
        {
            real_x = Settings_class.Convert_To_Real(img_x, _canvas);
            real_y = Settings_class.Convert_To_Real(img_y, _canvas);
        }




    }
}
