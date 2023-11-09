using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{
    public class Point_f
    {

        private double _Img_x;
        public double Img_x
        {
            get { return _Img_x; }
            //when the user try to change the img_x i will automatically change the real_x
            set
            {
                _Img_x = value;
                Update_Points();
            }
        }

        private double _Img_y;

        public double Img_y
        {
            get { return _Img_y; }
            //when the user try to change the img_x i will automatically change the real_x
            set
            {
                _Img_y = value;
                Update_Points();
            }
        }
       

        public double real_x, real_y;

        private Canvas _canvas;

        //insted of taking canvas i need to take the size of the canvas or just height beacasue the ratio is same all the way
        public Point_f(double x, double y)
        {
            Img_x = x;
            Img_y = y;


            Update_Points();
            /*
            //until canvas has been set
            real_x = x;
            real_y = y;*/
        }
        public void Update_Points()
        {
           
            real_x = Settings_class.Convert_To_Real(Img_x);
            real_y = Settings_class.Convert_To_Real(Img_y );
        }


        public void Move_Point(double dx,double dy)
        {
            Img_x+= dx;
            Img_y+= dy;
            //Update_Points
        }

        public double[] Get_Real_Point()
        {
            //you need to update the img pos before you send or you will recive an old points 
            return new double[] { real_x, real_y } ;
        }
        public override string ToString()
        {
            return $"Imaginary point value ({Img_x} , {Img_y}) ,real point value ({real_x},{real_y}) ";
        }




    }
}
