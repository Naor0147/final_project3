using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace final_project3.Classes
{
    class obstacle : shapes_geometry
    {
        private double width;
        private double height;
        public double angle;

        public Point[] points;
        public Point[] relative_Points;
        public List<Line> lines;

        public obstacle(Canvas canvas, double x, double y, double width, double height, double alpha =0, double vx=0, double vy=0,Shape shape_Kind=Shape.rectangle) : base(canvas, x, y, vx, vy, shape_Kind)
        {
            this.width = width;
            this.height = height;
            this.angle = alpha+90;

            this.points = DrawRectOnAngle();//draw the rectangle 

            
            convert_points_realtive();
            lines = new List<Line>();
            DrawMultipleLines();
        }
       
        public Point[] DrawRectOnAngle()
        {
            return new Point[]
                {
                new Point((int)_x,(int) _y),//(l,k) P1
                new Point((int)(_x - height*Math.Sin(angle)),(int)(_y+height*Math.Cos(angle))),//(l-hsin(a),k+hcos(a)) P3
                new Point((int)(_x + width*Math.Cos(angle)-height*Math.Sin(angle)), (int)(_y + width*Math.Sin(angle)+height*Math.Cos(angle))),//(l+w*cos(a)-h*sin(a),k+w*sin(a)+h*cos(a)) P4
                new Point((int)(_x + width*Math.Cos(angle)),(int)(_y + width*Math.Sin(angle)) ),//l+wcos(a) P2
                };
        }

        //
        public void DrawMultipleLines()
        {
            if (relative_Points == null) return;

         
            // remove the old lines , and draw the new one , so there will not be overlap , when i resize it is necesery 
            RemoveIfExsits();
            lines= new List<Line>(); 

            //draw the lines on screen
            for (int i = 0; i < relative_Points.Length - 1; i++)
            {
                draw(i,i+1);
            }
            draw(relative_Points.Length - 1, 0);
        }
        
        public void RemoveIfExsits()//remove the old obstacles so when you resize the screen you don't have multiple lines that are the same
        {
            if (lines == null) return;
            for (int i = 0; i < lines.Count; i++)
            {
                _canvas.Children.Remove(lines[i]);
            }
            
        }

       


        private void draw(int i,int j)
        {
            Line line = new Line
            {
                X1 = relative_Points[i].X,
                Y1 = relative_Points[i].Y,
                X2 = relative_Points[j].X,
                Y2 = relative_Points[j].Y,
                Stroke = new SolidColorBrush(Colors.Blue),
                StrokeThickness = 2
            };
            lines.Add(line);
            _canvas.Children.Add(line);
        }


        public void move(int dx,int dy)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += dx;
                points[i].Y += dy;
            }
        }

        public void convert_points_realtive()
        {
            this.points = DrawRectOnAngle();//check , i need to update every time there is change 
            relative_Points = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                relative_Points[i] = new Point((int)Convert_To_Real(points[i].X), (int)Convert_To_Real(points[i].Y));
            }
        }




    }

}
