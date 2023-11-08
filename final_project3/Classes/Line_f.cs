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
using Windows.Web.UI;
using Color = Windows.UI.Color;

namespace final_project3.Classes
{
    class Line_f
    {
        // y=mx+b
        public double m;
        public double b;

        //point on the imageinary canvas 
        public double x1, x2, y1, y2;
        Point_f P1, P2;

        // the line in form y=mx+b
        string function;
        
        //canvas to Draw_line on 
        Canvas _canv;

        //Imaginary Line
        Line _line_imaginary;

        //color
        Color _line_color;

        
        //when user input a color
        public Line_f(Point_f p1, Point_f p2, Canvas _canv,Color color)
        {
            this._line_color = color;
            Initialize_Data(p1, p2, _canv);
        }

        public Line_f(Point_f p1, Point_f p2 , Canvas _canv )
        {
            this._line_color = GenerateRandomColor();
            Initialize_Data(p1, p2, _canv);

        }

        private void Initialize_Data(Point_f p1, Point_f p2, Canvas _canv)
        {
            //get two points of the line
            this.P1 = p1;
            this.P2 = p2;

            //make it simpler to use the class
            this.x1 = p1.img_x;
            this.x2 = p2.img_x;
            this.y1 = p1.img_y;
            this.y2 = p2.img_y;

            //what canvas to Draw_line on
            this._canv = _canv;


            //the gradient 
            m = (double)((y1 - y2) / (x1 - x2));
            //the y value when x=0 
            b = y1 - (m * x1);

            //convert to function 
            function = convert_line_to_func();

            //Imaginary line 
            CreateLineOnScreen();
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

        //create line accordingly to the real canvas
        public void CreateLineOnScreen()
        {
            _line_imaginary = new Line
            {
                X1 = P1.real_x,
                Y1 = P1.real_y,
                X2 = P2.real_x,
                Y2 = P2.real_y,
                Stroke = new SolidColorBrush( this._line_color),
                StrokeThickness = 2
            };
            
            this._canv.Children.Add(_line_imaginary);
            
        }

        public void UpdateLine()
        {
            P1.Update_Points();
            P2.Update_Points();
            _line_imaginary.X1 = P1.real_x;
            _line_imaginary.Y1 = P1.real_y;
            _line_imaginary.X2 = P2.real_x;
            _line_imaginary.Y2 = P2.real_y;
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

        public bool CheckCol(Line_f line)
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




        public void Change_Line_Color(Color color)
        {
            this._line_color = color;
            Update_color();
        }
        public void Change_Line_Color()
        {
            this._line_color = GenerateRandomColor();
            Update_color();
        }


        private void Update_color()
        {
            if (_line_imaginary != null)
            {
                _line_imaginary.Stroke = new SolidColorBrush(_line_color);
            }
        }




        //create a random color 
        public Color GenerateRandomColor()
        {

            Random random = new Random();
            byte r = (byte)random.Next(256); // Red component
            byte g = (byte)random.Next(256); // Green component
            byte b = (byte)random.Next(256); // Blue component

            return Color.FromArgb(255, r, g, b);
        }



        

    }
}
