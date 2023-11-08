﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Radios;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace final_project3.Classes
{
    public enum Shape
    {
        circle, rectangle
    }

   
    public class Settings_class
    {
        //const
        public const double IMAGINARY_SCREEN_HEIGHT = 1000;
        public const double IMAGINARY_SCREEN_WIDTH = 1920;


        /*
         **What the diffreance between I 
         
         to make the game work on any kind of screen I made consept called (Imaginary Canvas)
        I Draw_line and work on the Imaginary Canvas is size doesnt change ,even if you change the window size ,
        then i after i Draw_line on the imaginary canvas i convert the object postion and size to the size of the 
        "Real Canvas" (the canvas you see when you play the game), and every time you resize the screen the objects 
        update their size accordinliy to the screen size 
         
         */

        //convert Imaginary canvas value to real canvas value ;
        /* public static double Convert_To_Real(double value, Canvas _canvas)
         {
             var window = ApplicationView.GetForCurrentView();

             //canvas height {_canvas.ActualHeight}
             Debug.WriteLine($"  window visible bounds {window.VisibleBounds.Height} ");

             if (_canvas == null)
                 return value;

            return value * (_canvas.ActualHeight / IMAGINARY_SCREEN_HEIGHT);
         }*/


        public static double Convert_To_Real(double value)
        {
            var window = ApplicationView.GetForCurrentView();

           
            Debug.WriteLine($"  window visible bounds {window.VisibleBounds.Height} ");

            return value * (window.VisibleBounds.Height / IMAGINARY_SCREEN_HEIGHT);
        }




        //Every time the screen size change the function make sure the ratio of the width and height stay the same 
        public static void Change_To_Right_Screen_Ratio()
        {
            var window = ApplicationView.GetForCurrentView();
            
            //Imaginary screen ratio {width/height}
            double ratio = IMAGINARY_SCREEN_WIDTH / IMAGINARY_SCREEN_HEIGHT;

            
            //_ratio.Text = window.VisibleBounds.Width + " *" + window.VisibleBounds.Height + " ratio: " + window.VisibleBounds.Width / window.VisibleBounds.Height;
            if (window.VisibleBounds.Width / window.VisibleBounds.Height != ratio)
            {
                double newWidth = window.VisibleBounds.Height * ratio;

                window.TryResizeView(new Windows.Foundation.Size((int)newWidth, (int)window.VisibleBounds.Height));
            }
        }
    }
    
}
