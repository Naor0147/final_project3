using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public obstacle ball_col_rect;

        public Ball(Canvas canvas, double x, double y, double vx, double vy, double size , Color color) : base(canvas, x, y, vx, vy,shape_Kind: Shape.circle)
        {
     
            //only for ball class
            this._size = size;
            this._color = color;

            ay = gravity;

            //realtive
           
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
            Canvas.SetLeft(_ellipse,_real_x);
            Canvas.SetTop(_ellipse, _real_y);

            ball_col_rect = new obstacle(this._canvas, _x, _y, _size, _size);

            _canvas.Children.Add(_ellipse);

        }



        /*
        public void updatePos()
        {
           
            _x += _vx;
            _y += _vy;
           
             update_Size();
             _real_x = Settings_class.Convert_To_Real(_x)+_real_vx;
            _real_y = Settings_class.Convert_To_Real(_y)+ _real_vy;
            Canvas.SetLeft(_ellipse, _x);
            Canvas.SetTop(_ellipse, _y);

        }
        */
        
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
            _x += _vx;
            _y += _vy;


            UpdateRealPos();
            //ball Collison rect
            ball_col_rect.Change_Pos(_x,_y);// i have no clue why it doesnt match the ball 
            // i need to make a function in obstacle class where i can move the obstcale to any x ,y and not by dx and dy , this probbley the problem 

            //ball_col_rect.Duplicate_Obstacle(_x, _y);



          
           
           
            Canvas.SetLeft(_ellipse, _real_x);
            Canvas.SetTop(_ellipse, _real_y);

          

        }


    }
}
