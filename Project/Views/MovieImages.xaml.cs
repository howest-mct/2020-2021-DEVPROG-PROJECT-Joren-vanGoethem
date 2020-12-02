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
        public MovieImages(MovieDetails selectedMovie)
        {
            movie = selectedMovie;
            InitializeComponent();
            LoadImages();
        }

        // load all images, cover + screenshots
        private void LoadImages()
        {
            movieImages = new List<string>() { movie.LargeCoverImage, movie.LargeScreenshotImage1, movie.LargeScreenshotImage2, movie.LargeScreenshotImage3 };
            counter.Text = $"1/{movieImages.Count}";
            imageCounter = 0;
            movieName.Text = movie.Title;
            currentImage.Source = movieImages[imageCounter];
        }

        // go back one images
        private void prevImage_Clicked(object sender, EventArgs e)
        {
            if (imageCounter > 0)
            {
                imageCounter -= 1;
                currentImage.Source = movieImages[imageCounter];
                nextImage.BackgroundColor = Color.FromHex("#5da93c");
                nextImage.TextColor = Color.FromHex("#FFFFFF");
            }
            if (imageCounter == 0)
            {
                prevImage.BackgroundColor = Color.FromHex("#919191");
                prevImage.TextColor = Color.FromHex("#171717");
            }
           counter.Text = $"{imageCounter + 1}/{movieImages.Count}";
        }

        // go forward one image
        private void nextImage_Clicked(object sender, EventArgs e)
        {
            if (imageCounter >= 0 && imageCounter < movieImages.Count-1 )
            {
                imageCounter += 1;
                prevImage.BackgroundColor = Color.FromHex("#5da93c");
                prevImage.TextColor = Color.FromHex("#FFFFFF");
                currentImage.Source = movieImages[imageCounter];
            }
            if (imageCounter == movieImages.Count-1)
            {
                nextImage.BackgroundColor = Color.FromHex("#919191");
                nextImage.TextColor = Color.FromHex("#171717");
            }

            counter.Text = $"{imageCounter + 1}/{movieImages.Count}";
        }
    }
}