using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetails : ContentPage
    {
        public Movie selectedMovie { get; set; }
        public MovieDetails(Movie movie)
        {
            selectedMovie = movie;
            InitializeComponent();
            LoadMovieDetails();
        }
        private async Task LoadMovieDetails()
        {
            MovieNamelbl.Text = selectedMovie.title;
            Yearlbl.Text = Convert.ToString(selectedMovie.year);
            Genreslbl.Text = selectedMovie.genreString;
            MoviePicture.Source = selectedMovie.large_cover_image;
            Runtimelbl.Text = selectedMovie.runtimeString;
            Ratinglbl.Text = Convert.ToString(selectedMovie.rating);
        }
    }
}