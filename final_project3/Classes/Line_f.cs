using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace final_project3.Classes
{
    class Line_f
    {
        // y=mx+b
        public double m;
        public double b;

        //point on the imageinary canvas 
        public int x1, x2, y1, y2;
        Point P1, P2;

        // the line in form y=mx+b
        string function;
        
        //canvas to draw on 
        Canvas _canv;

        //Imaginary Line
        Line _line_imaginary;

        public Line_f(Point p1, Point p2 , Canvas _canv )
        {
            //get two points of the line
            this.P1 = p1;
            this.P2 = p2;

            //make it simpler to use the class
            this.x1 = p1.X;
            this.x2 = p2.X;
            this.y1 = p1.Y;
            this.y2 = p2.Y;

            //what canvas to draw on
            this._canv = _canv;

            //the gradient 
            m = (double)((double)(y1 - y2) / (double)(x1 - x2));
            //the y value when x=0 
            b =  y1- (m * x1) ;

            //convert to function 
            function=convert_line_to_func();

            //Imaginary line 
            _line_imaginary =CreateLineOnScreen();

        }

        private string convert_line_to_func()
        {

            //convert to function 
            function = $"y= {m}*x";
            if (b > 0)
            {
                function += " +" + b;
            }
            else if (b < 0)
            {
                function += " -" + b;
            }
            return function;
        }

        public Line CreateLineOnScreen()
        {
            Line line = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = new SolidColorBrush(Colors.Purple),
                StrokeThickness = 2
            };
            
            this._canv.Children.Add(line);
            return line;
        }

        private void ConvertImaginaryLineToRealLine()
        {

        }



        public double getlineY(double x_temp) {
            return m * x_temp + b;
        }

        public bool isBetween(double v1, double middle, double v2) {

            if (v1 > v2)
            {
                double temp = v2;
                v2 = v1;
                v1 = temp;
            }
            return v1 < middle && middle < v2;
        }

        public bool checkCol(Line_f line)
        {
            if (this.m == line.m)
                return false;

            double x = (line.b - b) / (m - line.m);
            double y = getlineY(x);
            Point col = new Point((int)x, (int)y);


            bool condtion1 = isBetween(x1, x, x2);
            bool condtion2 = isBetween(line.x1, x, line.x2);
            bool condtion3 = isBetween(y1, y, y2);
            bool condtion4 = isBetween(line.y1, y, line.y2);

            return (condtion1 && condtion2 && condtion3 && condtion4);
        }

    }
}
