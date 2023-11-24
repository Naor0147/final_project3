using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project3.Classes
{
    public class PhysicBody
    {
        //Position 
        public Point_f point;
        

        //The speed of the body in for sec 
        public double vy;
        public double vx;

        //The acceleration of the body in sec 
        public double ax;
        public double ay;


        //const
        
        public const double gravity = 0.00098;

        public PhysicBody(Point_f point_F, double vy=0, double vx = 0, double ax = 0, double ay = 0 )
        {

            point = point_F;

            this.vy = vy;
            this.vx = vx;

            this.ax = ax;
            this.ay = ay;
        }

        //get the fps in game is divided by dt 
        public void Move_Dt()
        {
            double dt = 1 / Settings_class.current_FPS;

            //add a/fps so you move the same if you diffrent fps 
            vx += ax * dt;
            vy += ay * dt;
            
            //you move the same in every frame 
            point.Img_x += vx * dt;
            point.Img_y += vy * dt;

        }

    }
}
