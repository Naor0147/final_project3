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
        public const double gravity = 0.098;



        //realtive
        
        public double _real_size;
        

        public Ellipse _ellipse;

        public Ball(Canvas canvas, double x, double y, double vx, double vy, double size , Color color) : base(canvas, x, y, vx, vy,shape_Kind: Shape.circle)
        {
     
            //only for ball class
            this._size = size;
            this._color = color;

            ay = gravity;

            //realtive
           
            _real_size = Convert_To_Real(size);
            
           
            createBall();
        }


        private void createBall()
        {
            /*
            _ellipse = new Ellipse
            {
                Fill = new SolidColorBrush(_color),// i can also use imageBrush for photos 
                StrokeThickness = 2,
                Width = _real_size,
                Height = _real_size,
            };

            Canvas.SetLeft(_ellipse, Convert_To_Real(_x));
            Canvas.SetTop(_ellipse, Convert_To_Real(_y));
            */
            _ellipse = new Ellipse
            {
                Fill = new SolidColorBrush(_color),// i can also use imageBrush for photos 
                StrokeThickness = 2,
                Width = _size,
                Height = _size,
            };

            Canvas.SetLeft(_ellipse,_real_x);
            Canvas.SetTop(_ellipse, _real_y);
            _canvas.Children.Add(_ellipse);

        }



        /*
        public void updatePos()
        {
           
            _x += _vx;
            _y += _vy;
           
             update_Size();
             _real_x = Convert_To_Real(_x)+_real_vx;
            _real_y = Convert_To_Real(_y)+ _real_vy;
            Canvas.SetLeft(_ellipse, _x);
            Canvas.SetTop(_ellipse, _y);

        }
        */
        
        private void update_Size()
        {
            _real_size = Convert_To_Real(this._size);
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
            update_Size();
            //realtive 
            /*
            _real_ay = Convert_To_Real(ay);
            _real_vy += _real_ay;
            _real_ax = Convert_To_Real(ax);
            _real_vx = _real_ax;*/
            Canvas.SetLeft(_ellipse, _real_x);
            Canvas.SetTop(_ellipse, _real_y);

          

        }


    }
}
