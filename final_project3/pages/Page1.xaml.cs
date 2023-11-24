using final_project3.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using CompositionTarget = Windows.UI.Xaml.Media.CompositionTarget;

using Point = System.Drawing.Point;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace final_project3.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        private Compositor compositor;

        Ball ball;
        
        Rectangle_Shape obstacles, obstacles1;
        DispatcherTimer _timer;
        Line_f[] arr;


        private DispatcherTimer fpsTimer;
        private int frameCount;

        public Page1()
        {
            this.InitializeComponent();
            ball = new Ball(canv,new PhysicBody( new Point_f(200,100), 40, 10,0,10), 100, Colors.Beige);

            
           

           //apper on screen just need to add list of all the objects so i can update their size  
           obstacles = new Rectangle_Shape(canv,new PhysicBody( new Point_f(400,400)), width: 400,height: 400, alpha: 30);

           //game border
           obstacles1 = new Rectangle_Shape(canv,new PhysicBody(new Point_f(5,5)), width: 1910,height: 990, alpha: 0);
            
            

            // Debug.WriteLine(line_F.checkCol(line_F2));
            

        }


        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //change the screen to the right to the right screen size 
            Settings_class.Change_To_Right_Screen_Ratio();

            obstacles.Update_Object_Position();
            obstacles1.Update_Object_Position();


            // obstacles1.UpdateRealPos();


        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (canv != null)
            {
               

                ball.update_Size();
                

            }
            Functions_add();



        }
        private void Functions_add()
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            fpsTimer = new DispatcherTimer();
            fpsTimer.Interval = TimeSpan.FromSeconds(1);
            fpsTimer.Tick += FpsTimer_Tick; 
            fpsTimer.Start();
        }

        private void FpsTimer_Tick(object sender, object e)
        {
            fpstextblock.Text = $"FPS: {frameCount:F2}";

            Classes.Settings_class.current_FPS = frameCount;
            // Reset counters
            frameCount = 0;
        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            frameCount++;
            ball.move();
            string x = "imag (" + ball.point_F.Img_x + "," + ball.point_F.Img_x + ") and real (" + ball.point_F.real_x + "," + ball.point_F.real_x + ")";
            _pos.Text = x;
            //ball.CreateTrail();
            ball.physic_body.Move_Dt();




        }

        

    }
}
