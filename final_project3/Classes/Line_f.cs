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
            this.x1 = p1.Img_x;
            this.x2 = p2.Img_x;
            this.y1 = p1.Img_y;
            this.y2 = p2.Img_y;

            //what canvas to Draw_line on
            this._canv = _canv;


            //the gradient 
            m = (double)((y1 - y2) / (x1 - x2));
            //the y value when x=0 
            b = y1 - (m * x1);

            //convert to function 
            function = Convert_line_to_func();

            //Imaginary line 
            CreateLineOnScreen();
        }

       

        private string Convert_line_to_func()
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
                StrokeThickness = 4
            };
            
            this._canv.Children.Add(_line_imaginary);
            
        }

       
        public void Move_Line(double dx ,double dy)
        {
            P1.Move_Point(dx, dy);
            P2.Move_Point(dx, dy);
            Update_Line_Real_Pos();
        }

        public void RemoveLine()
        {
            _canv.Children.Remove(_line_imaginary);
        }


        public void Update_Line_Real_Pos()
        {
            P1.Update_Points();
            P2.Update_Points();
            _line_imaginary.X1 = P1.real_x;
            _line_imaginary.Y1 = P1.real_y;
            _line_imaginary.X2 = P2.real_x;
            _line_imaginary.Y2 = P2.real_y;
        }


        //get y value of the line in the x value
        public double Get_Y_Value_On_X(double x_temp) {
            return m * x_temp + b;
        }

        

        public bool CheckCol(Line_f line)
        {
            
            if (this.m == line.m)
            {
                if (this.b==line.b)
                {
                    return true;//the same line
                }
                return false;
            }
                

            double x = (line.b - b) / (m - line.m);
            double y = Get_Y_Value_On_X(x);
            Point_f col = new Point_f(x, y);


            bool condtion1 = Settings_class.isBetween(x1, x, x2);
            bool condtion2 = Settings_class.isBetween(line.x1, x, line.x2);

            /*pretty sure i dont need this check 
             * cause i allready cheked the x of the line so i dont need to check the y 
             * 
             bool condtion3 = Settings_class.isBetween(y1, y, y2);
            bool condtion4 = Settings_class.isBetween(line.y1, y, line.y2);
            return (condtion1 && condtion2 && condtion3 && condtion4);*/

            return (condtion1 && condtion2 );


        }



        
        public void Change_Line_Color(Color color)
        {
            this._line_color = color;
            Update_color();
        }

        //if the user doesnt input color it wiil chose a random color 
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
