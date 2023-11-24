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
using Color = Windows.UI.Color;

namespace final_project3.Classes
{
    class Rectangle_Shape : shapes_geometry
    {
        private double width;
        private double height;
        public double angle;

        public Point_f[] points_f;
       
        public List<Line_f> lines_f;

        public Color Color { get; set; }

        //when the user doesn't input color
        public Color color_null = new Color();

        //if you want change the variables , or how the rect looks , you need to make sure the the points[] has been updated 


       
        public Rectangle_Shape(Canvas canvas, PhysicBody physicBody, double width, double height,Color color= new Color() ,double alpha = 0) : base(canvas, physicBody, shape_Kind : Shape.rectangle)
        {
            //gets color
            this.Color = color;

            this.width = width;
            this.height = height;
            this.angle = alpha;

            this.points_f = Convert_Stats_To_Points_f();
            Draw_Obstacle();

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




        /*this function Update the points of the Rectangle_Shape 
        when you update the points of the Rectangle_Shape the following things could happen :
        1. the Rectangle_Shape would change place on screen
        2.the size of the Rectangle_Shape could change 
        */ 
        public override void Update_Object_Position()
        {
            
            this.points_f = Convert_Stats_To_Points_f();//==> this line makes sure the points of the Rectangle_Shape are up do date 

            for (int i = 0; i < lines_f.Count-1; i++)
            {
                lines_f[i].Change_Line_Points(points_f[i], points_f[i + 1]);
            }
            lines_f[lines_f.Count-1].Change_Line_Points(points_f[points_f.Length - 1], points_f[0]);

            UpdateTrail();
        }

        

        //Draws the obstacle on the screen
        public void Draw_Obstacle()
        {

            if (points_f == null) return;//if there isn't a list of points there nothing to draw 

            lines_f = new List<Line_f>();// reset the list 


            //this method connects all the point , and leave the last point to connects with first point 
            for (int i = 0; i < points_f.Length-1; i++)
            {
                Draw_Line(i,i+1);//draw the line on the screen and added it to the list 
            }
            Draw_Line(points_f.Length-1,0);//draw the line on the screen and added it to the list 

        }

        private void Draw_Line(int i,int j)
        {
            if (Color == color_null)//{#00000000} checks if the color is null and if so gives a random color
            {
                lines_f.Add(new Line_f(points_f[i], points_f[j], _canvas));
                return;
            }

            lines_f.Add(new Line_f(points_f[i], points_f[j], _canvas,Color));
        }


        public void Remove_Lines()
        {
            for (int i = 0; i < lines_f.Count; i++)
            {
                lines_f[i].RemoveLine();
            }
        }



        public override void Move_Distance(double dx, double dy)
        {
            point_F.Move_Point(dx, dy);

            Update_Object_Position();
        }

        public void Change_Pos(double x, double y)
        {
            //update point_f (the top left corner of the obstacles )
            point_F.Set_Point(x, y);
            Update_Object_Position();
        }

        public void Duplicate_Obstacle(double x, double y)
        {
            point_F.Img_x = x;
            point_F.Img_y = y;

            this.points_f = Convert_Stats_To_Points_f();
            Draw_Obstacle();

        }


        

    }

}
