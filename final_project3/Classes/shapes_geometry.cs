using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{


    public class shapes_geometry
    {

        // real canvas is the regular canvas 
        // imaginary canvas is my canvas that can be any size i want 
        
        public Canvas _canvas; //canvas to draw on

        public double _x, _y;
        /* posision on canvas , maybe i will try to make the x and y realtive to the canvas x y 
         I will to be making defalut screen size for my imaginary screen like 1600*900 where i place the x y ,
        than i will take the canvas real size , let imagine it will be 160*90 (for ez calc, the ratio has to be the same 16*9) 
        and x=800 y=490 =>
        the ratio => 160/1600=0.1 so the real x and y will be => x*0.1 => 800*0.1 = 80 , and the same for y
        */
        public double _real_x, _real_y;

        // the same for speed
        public double _vx, _vy;
        


        public Shape _shape_Kind;

    
        public shapes_geometry(Canvas canvas, double x, double y, double vx, double vy, Shape shape_Kind)
        {
            this._canvas = canvas;
            this._x = x;
            this._y = y;
            this._vx = vx;
            this._vy = vy;
            this._shape_Kind = shape_Kind;
            this._real_x = Convert_To_Real(_x);
            this._real_y = Convert_To_Real(_y);
        }

        public bool collision()
        {
            return false;
        }


        public double Convert_To_Real(double value) => value * (_canvas.ActualHeight / Settings_class.IMAGINARY_SCREEN_HEIGHT) ;

        //takes number on the imagenary canvas and convert to the real canvas
        public void UpdateRealPos()
        {
            _real_x = Convert_To_Real(_x);
            _real_y = Convert_To_Real(_y);
        }
       


        public virtual void move() { }




        
        


    }
}
