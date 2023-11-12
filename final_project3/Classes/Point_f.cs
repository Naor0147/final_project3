using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{

    // better alternative than the defaults Point class 
    public class Point_f
    {
        // save in the class in self so when you do get you will not get into infinite recursive when you do get
        private double _Img_x;
        private double _Img_y;

        public double Img_x
        {
            get { return _Img_x; }
            //when the user try to change the img_x i will automatically change the real_x
            set
            {
                _Img_x = value;
                real_x = Settings_class.Convert_To_Real(Img_x);
            }
        }
        public double Img_y
        {
            get { return _Img_y; }
            //when the user try to change the img_x i will automatically change the real_x
            set
            {
                _Img_y = value;
                real_y = Settings_class.Convert_To_Real(Img_y);
            }
        }
  
        //represent the point on the real canvas(the one you see, that could be resizable) 
        public double real_x, real_y;

        //the canvas you work on 
        private Canvas _canvas;

        



        //take a x and y and convent it two point one the Imaginary canvas and one on the Real canvas 
        public Point_f(double x, double y)
        {
            Img_x = x;
            Img_y = y;
            Update_Points();

           // img=new Img(x, y);
          //  real = new Real(img);
            
        }
        public void Update_Points()
        {
           
            real_x = Settings_class.Convert_To_Real(Img_x);
            real_y = Settings_class.Convert_To_Real(Img_y);
        }


        public void Move_Point(double dx,double dy)
        {
            Img_x+= dx;
            Img_y+= dy;
            //Update_Object_Position
        }
        public void Set_Point(double x,double y)
        {
            Img_x= x;
            Img_y= y;

        }

        public double[] Get_Real_Point()
        {
            //you need to update the img pos before you send or you will receive an old points 
            return new double[] { real_x, real_y } ;
        }
        public override string ToString()
        {
            return $"Imaginary point value ({Img_x} , {Img_y}) ,real point value ({real_x},{real_y}) ";
        }


       
        /*
        public class Img
        {
        public double x { get; private set; }
        public double y { get; private set; }

            public Img (double x, double y)
            {
                this.x = x;
                this.y = y;
                
            }

        }
        public class Real
        {
            public double x { get; private set; }
            public double y { get; private set; }

            public Real(Img img)
            {
                update(img);
            }
            
            public void update(Img img) {
                this.x = Settings_class.Convert_To_Real(img.x);
                this.y = Settings_class.Convert_To_Real(img.y);
            }
        */
    }

}

