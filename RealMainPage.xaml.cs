using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media;
//using System.Drawing;
using Windows.Media.Render;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Popups;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Invaders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RealMainPage : Page
    {
        Player player;
        public RealMainPage()
        {
            this.InitializeComponent();
            Grid area = this.Content as Grid;
            player = new Player(PlayArea);
            DispatcherTimer anim = new DispatcherTimer();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            World.Start(this.PlayArea);
            this.Loaded += RealMainPage_Loaded;
            // ReImage();
        }

        private void RealMainPage_Loaded(object sender, RoutedEventArgs e)
        {
           // Image();
        }

        private void CompositionTarget_Rendering(object sender, object e)
        {
            SetLoc();
        }
        void SetLoc()
        {
            foreach (Invader invader in World.invaders)
            {
                bool found = false;
                Image selected = null;
                foreach(Image image in PlayArea.Children)
                {
                    if (image.Tag.ToString() == invader.Tag)
                    {
                        found = true;
                        selected = image;
                    }
                    
                }
                if(found == false)
                {
                    Image image = new Image();
                    image.Tag = invader.Tag;
                    image.Height = 50;
                    image.Width = 50;
                    image.Source = new BitmapImage() { UriSource = new Uri("ms-appx:///Invaders/Untitled2.png") };
                    selected = image;
                    PlayArea.Children.Add(image);
                }
                if (selected != null)
                {
                    Canvas.SetLeft(selected, invader.Location.X);
                    Canvas.SetTop(selected, invader.Location.Y);
                }
            }
        }
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        async private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            await new MessageDialog("keydown").ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            World.AddInvaders(PlayArea, 8);
        }
    }
}
