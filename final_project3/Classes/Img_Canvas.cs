using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{
    public class Img_Canvas
    {
        Canvas Main_Canavs { get; set; }

        public Img_Canvas(Canvas canvas) 
        {
            this.Main_Canavs = canvas;
        }



        //added the the objects to canvas.childern and add its to the list of objects in the class
        public void Add_Obj(shapes_geometry shape)
        {

          //  Main_Canavs.Children.Add();
        }

    }
}
