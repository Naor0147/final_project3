using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{
    class Point_f
    {

        public double img_x, img_y;

        public double real_x, real_y;

        private Canvas _canvas;

        //insted of taking canvas i need to take the size of the canvas or just height beacuse the ratio is same all the way
        public Point_f(double x, double y)
        {
            img_x = x;
            img_y = y;

            //until canvas has been set
            real_x = x;
            real_y = y;
        }
        public void Update_Points()
        {
           
            real_x = Settings_class.Convert_To_Real(img_x);
            real_y = Settings_class.Convert_To_Real(img_y );
        }
        public double[] Get_Real_Point()
        {
            //you need to update the img pos before you send or you will recive an old points 
            return new double[] { real_x, real_y } ;
        }
        public override string ToString()
        {
            return $"Imaginary point value ({img_x} , {img_y}) ,real point value ({real_x},{real_y}) ";
        }

    }
}
