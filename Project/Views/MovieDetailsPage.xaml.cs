using FFImageLoading.Forms;
using Project.Models;
using Project.Repositories;
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
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetails movie { get; set; }
        public MovieDetailsPage(MovieDetails selectedMovie)
        {
            movie = selectedMovie;
            InitializeComponent();
            LoadMovieDetails();
        }
        private async Task LoadMovieDetails()
        {
            movieName.Text = movie.title;
            year.Text = Convert.ToString(movie.year);
            genres.Text = movie.genreString;
            moviePicture.Source = movie.largeCoverImage;
            runtime.Text = movie.runtimeString;
            resolutions.Text = movie.resolutions;
            rating.Text = Convert.ToString(movie.rating);
            description.Text = movie.descriptionFull;
            await load_suggestions();
        }

        private void trailer_Clicked(object sender, EventArgs e)
        {
            if (movie.ytTrailerCode != null) //Debug.WriteLine("No items selected");
            {
                Navigation.PushAsync(new Trailer(movie.ytTrailerCode));
            }
        }

        private void pictures_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Pictures");
            Navigation.PushAsync(new MovieImages(movie));
        }

        private void torrents_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Torrents());
        }

        private async Task load_suggestions()
        {
            List<MovieDetails> suggestions = await MovieRepository.GetMovieSuggestionsAsync(movie.id);
            List<CachedImage> images = new List<CachedImage>(){ suggestion1, suggestion2, suggestion3, suggestion4 };
            for(int i = 0; i<images.Count; i++)
            {
                images[i].Source = suggestions[i].mediumCoverImage;
            }
        }
    }
}