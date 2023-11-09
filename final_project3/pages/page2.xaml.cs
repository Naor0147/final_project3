﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CompositionTarget = Windows.UI.Xaml.Media.CompositionTarget;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace final_project3.pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class page2 : Page
    {
        private Visual visual;
        private Compositor compositor;
        private float angle = 0.0f;

        public page2()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComposition();
            CompositionTarget.Rendering += CompositionTarget_Rendering1;
        }

        private void CompositionTarget_Rendering1(object sender, object e)
        {
            myRectangle.Width += 1;
            myRectangle.Height += 1;
        }

        private void InitializeComposition()
        {
            var hostVisual = ElementCompositionPreview.GetElementVisual(myRectangle);
            compositor = hostVisual.Compositor;

            visual = compositor.CreateSpriteVisual();
            

            ElementCompositionPreview.SetElementChildVisual(myRectangle, visual);
        }

       
    }
}