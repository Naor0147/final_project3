using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace final_project3.Classes
{
    class Ball : shapes_geometry
    {
        public double _size;//2 radius size
        public Color _color;// color of the ball

        //accelartion
        public double ax, ay;
        public const double gravity = 0.00098;



        //realtive
        
        public double _real_size;
        

        public Ellipse _ellipse;

        public Rectangle_Shape ball_col_rect;

        public Ball(Canvas canvas, Point_f point_F, double vx, double vy, double size , Color color) : base(canvas,point_F , vx, vy,shape_Kind: Shape.circle)
        {
     
            //only for ball class
            this._size = size;
            this._color = color;

            ay = gravity;

            //relative
           
            _real_size = Settings_class.Convert_To_Real(size);
            
           
            createBall();
        }


        private void createBall()
        {
          
            _ellipse = new Ellipse
            {
                Fill = new SolidColorBrush(_color),// i can also use imageBrush for photos 
                StrokeThickness = 2,
                Width = _size,
                Height = _size,
            };
            Canvas.SetLeft(_ellipse,point_F.real_x);
            Canvas.SetTop(_ellipse, point_F.real_y);

            ball_col_rect = new Rectangle_Shape(this._canvas, point_F, _size, _size);

            _canvas.Children.Add(_ellipse);

        }



      
        
        public void update_Size()
        {
            _real_size = Settings_class.Convert_To_Real(this._size);
            _ellipse.Width = _real_size;
            _ellipse.Height = _real_size;
            
        }

        public void move()
        {
            //reg
            //acc
            _vy += ay;
            _vx += ax;

            //add position
          
            point_F.Move_Point(_vx,_vy);

            /*
             
            //workiinngg just need to
            1. make this to one method 
            2. make it more readable 
            3. make so i dont delete the old lines i just transfrom the old lines to the new lines 
            //ball Collison rect*/
           
            // i need to make a function in Rectangle_Shape class where i can move the obstcale to any x ,y and not by dx and dy , this probbley the problem 
            ball_col_rect.Update_Object_Position();

            //ball_col_rect.Draw_Obstacle();
            //ball_col_rect.Duplicate_Obstacle(_x, _y);



          
           
            update_Size();
            Canvas.SetLeft(_ellipse, point_F.real_x);
            Canvas.SetTop(_ellipse, point_F.real_y);
            
          

        }
        


    }
}
