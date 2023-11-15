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
        public double x;
        public double y;
        //maybe i will use the z if i want to take a body back in the z axies
        public double z;

        //The speed of the body in for sec 
        public double vy;
        public double vx;

        //The acceleration of the body in sec 
        public double ax;
        public double ay;

        public PhysicBody(double x, double y, double vy=0, double vx = 0, double ax = 0, double ay = 0 , double z=0)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            this.vy = vy;
            this.vx = vx;

            this.ax = ax;
            this.ay = ay;
        }

        //get the fps in game is divided by dt 
        public void Move_Dt(double Fps)
        {
            

        }

    }
}
