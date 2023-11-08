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
using Point = System.Drawing.Point;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace final_project3.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        Ball ball;
        Ball _ball;
        obstacle obstacles;
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
           obstacles = new obstacle(canv,x: 400,y: 300, width: 400,height: 400, alpha: 30);

            obstacles.DrawMultipleLines();
            Start_Timer();

            arr = new Line_f[] { new Line_f(new Point(100, 100), new Point(400, 400), canv),
            new Line_f(new Point(100, 100), new Point(800, 800), canv),
            new Line_f(new Point(450, 200), new Point(195, 295), canv),new Line_f(new Point(650, 200), new Point(195, 295), canv)
            };
           

            // Debug.WriteLine(line_F.checkCol(line_F2));


        }

        private void Start_Timer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Tick += _timer_Tick; ;
            _timer.Start();
        }

        private void _timer_Tick(object sender, object e)
        {
            if (ball == null) { return; }
            ball.move();
           
            
            string x = "imag (" + ball._x + "," + ball._y + ")" ;
            _pos.Text = x;

            obstacles.angle += 0.05;
            obstacles.move(1,1);
            obstacles.convert_points_realtive();
            obstacles.DrawMultipleLines();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Change_To_Right_Screen_Ratio();
            //Change_To_Right_Screen_Ratio();

            if (ball == null) { return; }

            obstacles.convert_points_realtive();
            obstacles.DrawMultipleLines();
        }

        public static void Change_To_Right_Screen_Ratio()
        {
            var window = ApplicationView.GetForCurrentView();

            double ratio = Settings_class.IMAGINARY_SCREEN_WIDTH / Settings_class.IMAGINARY_SCREEN_HEIGHT;

            //
            //_ratio.Text = window.VisibleBounds.Width + " *" + window.VisibleBounds.Height + " ratio: " + window.VisibleBounds.Width / window.VisibleBounds.Height;
            if (window.VisibleBounds.Width / window.VisibleBounds.Height != ratio)
            {
                double newWidth = window.VisibleBounds.Height * ratio;

                window.TryResizeView(new Windows.Foundation.Size((int)newWidth, (int)window.VisibleBounds.Height));
            }
        }
       





    }
}
