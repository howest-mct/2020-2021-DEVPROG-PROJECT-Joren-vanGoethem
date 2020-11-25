using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieImages : ContentPage
    {
        public MovieDetails movie { get; set; }
        public int imageCounter { get; set; }
        public List<string> movieImages { get; set; }
        public MovieImages(MovieDetails movie)
        {           
            InitializeComponent();
            LoadImages();
        }

        private async Task LoadImages()
        {
            movieImages = new List<string>() { movie.largeScreenshotImage1, movie.largeScreenshotImage2, movie.largeScreenshotImage3 };
            imageCounter = 1;
            currentImage.Source = movieImages[imageCounter];
        }

        private void prevImage_Clicked(object sender, EventArgs e)
        {
            if (imageCounter > 0)
            {
                imageCounter -= 1;
                currentImage.Source = movieImages[imageCounter];
            }
            if (imageCounter == 0)
            {
                prevImage.BackgroundColor = Color.FromHex("#919191");
                prevImage.TextColor = Color.FromHex("#171717");
            }
        }

        private void nextImage_Clicked(object sender, EventArgs e)
        {
            
            if (imageCounter > 0 && imageCounter < 2 )
            {
                imageCounter += 1;
                prevImage.BackgroundColor = Color.FromHex("#5da93c");
                prevImage.TextColor = Color.FromHex("#FFFFFF");
                currentImage.Source = movieImages[imageCounter];
            }
            else if (imageCounter == 2)
            {
                nextImage.BackgroundColor = Color.FromHex("#919191");
                nextImage.TextColor = Color.FromHex("#171717");
            }

            page.Text = $"Page {imageCounter}";
        }
    }
}