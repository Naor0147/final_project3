using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{


    public class shapes_geometry
    {

        // real canvas is the regular canvas 
        // imaginary canvas is my canvas that can be any size i want 
        
        public Canvas _canvas; //canvas to Draw_line on

        
        /* posision on canvas , maybe i will try to make the x and y realtive to the canvas x y 
         I will to be making defalut screen size for my imaginary screen like 1600*900 where i place the x y ,
        than i will take the canvas real size , let imagine it will be 160*90 (for ez calc, the ratio has to be the same 16*9) 
        and x=800 y=490 =>
        the ratio => 160/1600=0.1 so the real x and y will be => x*0.1 => 800*0.1 = 80 , and the same for y
        */
       // public double _x, _y;
       //public double _real_x, _real_y;


        public Point_f point_F;

        // the same for speed
        public double _vx, _vy;
        


        public Shape _shape_Kind;

    
        public shapes_geometry(Canvas canvas, Point_f point_F, double vx, double vy, Shape shape_Kind)
        {
            this._canvas = canvas;
            /* this._x = x;
             this._y = y;
             this._real_x = Settings_class.Convert_To_Real(_x);
             this._real_y = Settings_class.Convert_To_Real(_y);
             */

            this.point_F = point_F;

            this._vx = vx;
            this._vy = vy;
            this._shape_Kind = shape_Kind;
            
        }

        public virtual bool collision()
        {
            return false;
        }


       

       
        public virtual void Update_Object_Position()
        {

            point_F.Update_Points();
        }
       


        public virtual void Move_Distance(double dx, double dy) { }




        
        


    }
}
