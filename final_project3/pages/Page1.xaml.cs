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
        Ball _ball;
        obstacle obstacles, obstacles1;
        DispatcherTimer _timer;
        Line_f[] arr;
        public Page1()
        {
            this.InitializeComponent();
            ball = new Ball(canv, 800, 400, 4, -10, 100, Colors.Beige);

            
           Point[] points = new Point[]
                {
                new Point(400, 400),
                new Point(400, 900),
                new Point(1200, 900),
                new Point(1200, 400),
                };

           //apper on screen just need to add list of all the objects so i can update their size  
           obstacles = new obstacle(canv,x: 400,y: 300, width: 400,height: 400, alpha: 30);
           obstacles1 = new obstacle(canv,x: 200,y: 100, width: 400,height: 400, alpha: 10);

            //obstacles.DrawMultipleLines();
            //Start_Timer();



            // Debug.WriteLine(line_F.checkCol(line_F2));


        }


        //timer tick doesnt work well in this progrem the better alterntive is CompositionTarget_Rendering
        /*
        private void Start_Timer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Tick += _timer_Tick; 
            _timer.Start();
        }

        private void _timer_Tick(object sender, object e)
        {
            if (ball != null) {
                ball.move();
                string x = "imag (" + ball._x + "," + ball._y + ")";
                _pos.Text = x;
            }
            
           
            // low fps maybe i will try to move the object in a diffrent timer using dt and fps to make sure it will work 
          obstacles.Update_Obstacle_Size_And_Pos_f();
          obstacles.Move_Distance(1, 1);

            /*
            obstacles.angle += 0.05;
            obstacles.move(1,1);
            obstacles.convert_points_realtive();
            obstacles.DrawMultipleLines();
        }*/

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //change the screen to the right to the right screen size 
            Settings_class.Change_To_Right_Screen_Ratio();


            //update the settings_class window visbile height , so the program can now how to transfrom the object to right size 
            var window = ApplicationView.GetForCurrentView();
            Settings_class.Window_VisibleBounds_Height = (int)window.VisibleBounds.Height;


            if (ball == null) { return; }

            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Update_Line_Real_Pos();
                }
            }
        }

    

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (canv != null)
            {
                //i need to add a list with all of the objects in the screen and every time the screen updated there x will change 


                //there is problem with the canvas it always showes as null
                // need to change so the point will not need canv every time ;
               // Line_f line1 = new Line_f(new Point_f(200, 100),new Point_f(400, 400),canv , Colors.Red);
/*
                arr = new Line_f[] { new Line_f(new Point_f(200, 100), new Point_f(400, 400),canv),
            new Line_f(new Point_f(100, 100), new Point_f(300, 800), canv),
            new Line_f(new Point_f(450, 200), new Point_f(195, 295), canv),
                new Line_f(new Point_f(650, 200), new Point_f(195, 295), canv)
            };
*/

            }
            CompositionTarget.Rendering += CompositionTarget_Rendering;



        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            if (ball != null)
            {
                ball.move();
                string x = "imag (" + ball._x + "," + ball._y + ")";
                _pos.Text = x;
            }


            // low fps maybe i will try to move the object in a diffrent timer using dt and fps to make sure it will work 
            obstacles.Update_Obstacle_Size_And_Pos_f();
            obstacles1.Update_Obstacle_Size_And_Pos_f();
            obstacles.Move_Distance(1, 1);

            /*
            obstacles.angle += 0.05;
            obstacles.move(1,1);
            obstacles.convert_points_realtive();
            obstacles.DrawMultipleLines();*/
        }
    }
}
