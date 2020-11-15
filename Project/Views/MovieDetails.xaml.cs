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
        public Movie SelectedMovie { get; set; }
        public MovieDetails(Movie movie)
        {
            SelectedMovie = movie;
            InitializeComponent();
            LoadMovieDetails();
        }
        private async Task LoadMovieDetails()
        {
            MovieNamelbl.Text = SelectedMovie.title;
            Yearlbl.Text = Convert.ToString(SelectedMovie.year);
            Genreslbl.Text = SelectedMovie.genrestring;
            MoviePicture.Source = SelectedMovie.large_cover_image;
            Runtimelbl.Text = SelectedMovie.runtimestring;
            Ratinglbl.Text = Convert.ToString(SelectedMovie.rating);
        }
    }
}