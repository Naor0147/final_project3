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


        public obstacle(Canvas canvas,Point_f point_F, double width, double height, double alpha =0, double vx=0, double vy=0,Shape shape_Kind=Shape.rectangle) : base(canvas, point_F, vx, vy, shape_Kind)
        {
            this.width = width;
            this.height = height;
            this.angle = alpha;

          

            this.points_f = Convert_Stats_To_Points_f();
            DrawMultipleLines_Linef();

        }


        


        //take the variables in the class {x,y,width,height,angle} and convert it to rectangle in angle 
   
        public Point_f[] Convert_Stats_To_Points_f()
        {

            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            double _x = this.point_F.Img_x;
            double _y= this.point_F.Img_y;

            return new Point_f[]
                {
                point_F,//(l,k) P1 new Point_f(_x, _y)
                new Point_f((_x - height * sin),(_y+ height * cos)),//(l-hsin(a),k+hcos(a)) P3
                new Point_f((_x + width*cos-height*sin),(_y + width*sin+height*cos)),//(l+w*cos(a)-h*sin(a),k+w*sin(a)+h*cos(a)) P4
                new Point_f((_x + width*cos),(_y + width*sin) ),//l+wcos(a) P2
                };
        }


        /*this function Update the points of the obstacle 
        when you update the points of the obstacle the following things could happen :
        1. the obstacle would change place on screen
        2.the size of the obstacle could change 
        */ 
        public void Update_Points()
        {
           
            this.points_f = Convert_Stats_To_Points_f();
            for (int i = 0; i < lines_f.Count-1; i++)
            {
                lines_f[i].Change_Line_Points(points_f[i], points_f[i + 1]);
            }
            lines_f[lines_f.Count-1].Change_Line_Points(points_f[points_f.Length - 1], points_f[0]);
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
       /* public void Update_Obstacle_Size_And_Pos_f()
        {
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].Update_Line_Real_Pos();
            }
        }*/

        public void Remove_Lines()
        {
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].RemoveLine();
            }
        }


        //

        public override void Move_Distance(double dx, double dy)
        {
            point_F.Move_Point(dx, dy);
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].Move_Line(dx, dy);    
            }
            UpdateRealPos();
        }

        public void Change_Pos(double x, double y)
        {
            //update point_f (the top left corner of the obstacles )
            point_F.Set_Point(x, y);

            

         

        }

        public void Duplicate_Obstacle(double x, double y)
        {
            point_F.Img_x = x;
            point_F.Img_y = y;

            this.points_f = Convert_Stats_To_Points_f();
            DrawMultipleLines_Linef();

        }


        

    }

}
