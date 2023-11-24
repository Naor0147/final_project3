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

        public List<shapes_geometry> shapes {  get; set; }

        public Img_Canvas(Canvas canvas) 
        {
            this.Main_Canavs = canvas;
            shapes = new List<shapes_geometry>();
        }



        //added the the objects to canvas.childern and add its to the list of objects in the class
        public void Add_Obj(shapes_geometry shape)
        {
            shapes.Add(shape);

          //  Main_Canavs.Children.Add();
        }
        public void AddToCanvas(shapes_geometry _object)
        {
            shapes.Add(_object);
            if (_object._shape_Kind == Shape.circle)
            {

            }
            
        }

        public void UpdateShapes()
        {
            foreach (shapes_geometry shape in shapes)
            {
                shape.Update_Object_Position();
            }
        }

    }
}
