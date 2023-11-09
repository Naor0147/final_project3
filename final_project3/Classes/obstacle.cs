using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace final_project3.Classes
{
    class obstacle : shapes_geometry
    {
        private double width;
        private double height;
        public double angle;

        public Point_f[] points_f;
       
        public List<Line_f> lines_f;


        //if you want change the variables , or how the rect looks , you need to make sure the the points[] has been updated 


        public obstacle(Canvas canvas, double x, double y, double width, double height, double alpha =0, double vx=0, double vy=0,Shape shape_Kind=Shape.rectangle) : base(canvas, x, y, vx, vy, shape_Kind)
        {
            this.width = width;
            this.height = height;
            this.angle = alpha;

          

            this.points_f = Convert_Stats_To_Points_f();
            DrawMultipleLines_Linef();

        }


        


        //take the varibles in the class {x,y,width,height,angle} and convert it to useable point on the imaginary canvas
   
        public Point_f[] Convert_Stats_To_Points_f()
        {

            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);

            return new Point_f[]
                {
                new Point_f(_x, _y),//(l,k) P1
                new Point_f((_x - height * sin),(_y+ height * cos)),//(l-hsin(a),k+hcos(a)) P3
                new Point_f((_x + width*cos-height*sin),(_y + width*sin+height*cos)),//(l+w*cos(a)-h*sin(a),k+w*sin(a)+h*cos(a)) P4
                new Point_f((_x + width*cos),(_y + width*sin) ),//l+wcos(a) P2
                };
        }



        public void DrawMultipleLines_Linef()
        {
            if (points_f == null) return;//if there isn't a list ' there nothing to draw 

            lines_f = new List<Line_f>();// reset the list 


            //this method connects all the point , and leave the last point to conect with first point 
            for (int i = 0; i < points_f.Length-1; i++)
            {
                lines_f.Add(new Line_f(points_f[i], points_f[i+1], _canvas));
            }
            lines_f.Add(new Line_f(points_f[points_f.Length-1], points_f[0], _canvas));

        }


        // if the window size has been changed it will update the the pos of x y and the size 
        // i need to add the abilty to update if the object has been changed 
        public void Update_Obstacle_Size_And_Pos_f()
        {
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].Update_Line_Real_Pos();
            }
        }

        public void Remove_Old_Lines()
        {
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].RemoveLine();
            }
        }


        //

        public override void Move_Distance(double dx, double dy)
        {
            _x += dx;
            _y += dy;
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].Move_Line(dx, dy);    
            }
            UpdateRealPos();
        }

        public void Change_Pos(double x, double y)
        {



            Move_Distance(x - this._x, y - this._y);

           // this.points_f = Convert_Stats_To_Points_f();
            
            //Update_Obstacle_Size_And_Pos_f();

        }

        public void Duplicate_Obstacle(double x, double y)
        {
            this._x = x;
            this._y = y;
            this.points_f = Convert_Stats_To_Points_f();
            DrawMultipleLines_Linef();

        }


        

    }

}
