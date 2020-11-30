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
        public List<MovieDetails> suggestions { get; set; }
        public MovieDetailsPage(MovieDetails selectedMovie)
        {
            movie = selectedMovie;
            InitializeComponent();
            LoadMovieDetails();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            //suggestion1.GestureRecognizers.Add(tapGestureRecognizer);

            List<CachedImage> images = new List<CachedImage>() { suggestion1, suggestion2, suggestion3, suggestion4 };
            foreach (CachedImage C in images)
            {
                C.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is CachedImage image)
            {
                for (int i = 0; i<suggestions.Count; i++)
                {
                    Debug.WriteLine(Convert.ToString(image.Source).Split(' ')[1]);
                    Debug.WriteLine(suggestions[i].MediumCoverImage);
                    if (Convert.ToString(image.Source).Split(' ')[1] == suggestions[i].MediumCoverImage)
                    {
                        MovieDetails tappedmovie = await MovieRepository.GetMovieDetailsAsync(suggestions[i].Id);
                        await Navigation.PushAsync(new MovieDetailsPage(tappedmovie));
                    }
                }
            }
        }

        private async Task LoadMovieDetails()
        {
            movieName.Text = movie.Title;
            year.Text = Convert.ToString(movie.Year);
            genres.Text = movie.GenreString;
            moviePicture.Source = movie.LargeCoverImage;
            runtime.Text = movie.RuntimeString;
            resolutions.Text = movie.Resolutions;
            rating.Text = Convert.ToString(movie.Rating);
            description.Text = movie.DescriptionFull;
            await load_suggestions();
        }

        private void trailer_Clicked(object sender, EventArgs e)
        {
            if (movie.YtTrailerCode != null) //Debug.WriteLine("No items selected");
            {
                Navigation.PushAsync(new Trailer(movie.YtTrailerCode));
            }
        }

        private void pictures_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Pictures");
            Navigation.PushAsync(new MovieImages(movie));
        }

        private void torrents_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TorrentPage(movie));
        }

        private async Task load_suggestions()
        {
            suggestions = await MovieRepository.GetMovieSuggestionsAsync(movie.Id);
            List<CachedImage> images = new List<CachedImage>(){ suggestion1, suggestion2, suggestion3, suggestion4 };
            for(int i = 0; i<images.Count; i++)
            {
                images[i].Source = suggestions[i].MediumCoverImage;
            }
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}