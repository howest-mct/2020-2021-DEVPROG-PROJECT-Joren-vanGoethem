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
        public MovieDetails Movie { get; set; }
        public List<MovieDetails> Suggestions { get; set; }
        public MovieDetailsPage(MovieDetails selectedMovie)
        {
            Movie = selectedMovie;
            InitializeComponent();
            LoadMovieDetails();

            // ad tapgesture recognizer for suggested movies
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            List<CachedImage> images = new List<CachedImage>() { suggestion1, suggestion2, suggestion3, suggestion4 };
            foreach (CachedImage C in images)
            {
                C.GestureRecognizers.Add(tapGestureRecognizer);
            }

            // enable cast button if the movie has a cast
            if (Movie.Cast != null)
            {
                cast.IsVisible = true;
            }
        }

        //redirect to movie page if suggested movie is tapped
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is CachedImage image)
            {
                for (int i = 0; i<Suggestions.Count; i++)
                {
                    Debug.WriteLine(Convert.ToString(image.Source).Split(' ')[1]);
                    Debug.WriteLine(Suggestions[i].MediumCoverImage);
                    if (Convert.ToString(image.Source).Split(' ')[1] == Suggestions[i].MediumCoverImage)
                    {
                        MovieDetails tappedmovie = await MovieRepository.GetMovieDetailsAsync(Suggestions[i].Id);
                        await Navigation.PushAsync(new MovieDetailsPage(tappedmovie));
                    }
                }
            }
        }

        // load all movie details into the xaml
        private async Task LoadMovieDetails()
        {
            movieName.Text = Movie.Title;
            year.Text = Convert.ToString(Movie.Year);
            genres.Text = Movie.GenreString;
            moviePicture.Source = Movie.LargeCoverImage;
            runtime.Text = Movie.RuntimeString;
            resolutions.Text = Movie.Resolutions;
            rating.Text = Convert.ToString(Movie.Rating);
            description.Text = Movie.DescriptionFull;
            await load_suggestions();
        }

        // go to trailer page with youtube trailer, will display an error if trailer is nog available. can be country related or age restricted
        private void trailer_Clicked(object sender, EventArgs e)
        {
            if (Movie.YtTrailerCode != null) //Debug.WriteLine("No items selected");
            {
                Navigation.PushAsync(new Trailer(Movie.YtTrailerCode));
            }
        }

        // go to movie page where all movie screenshots are displayed, this is best viewed with phone sideways
        private void pictures_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Pictures");
            Navigation.PushAsync(new MovieImages(Movie));
        }

        // go to torrent page, here the .torrent files can be downloaded
        private void torrents_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TorrentPage(Movie));
        }

        // load suggested movies according to the current movie's genre
        private async Task load_suggestions()
        {
            Suggestions = App.Cache.Get<List<MovieDetails>>($"moviesuggestions {Movie.Id}");
            if (Suggestions == null) { 
                Suggestions = await MovieRepository.GetMovieSuggestionsAsync(Movie.Id);
                App.Cache.Set<List<MovieDetails>>($"moviesuggestions {Movie.Id}", Suggestions);
            }

            List<CachedImage> images = new List<CachedImage>(){ suggestion1, suggestion2, suggestion3, suggestion4 };
            for(int i = 0; i<images.Count; i++)
            {
                images[i].Source = Suggestions[i].MediumCoverImage;
            }
        }

        //go to cast page if available and show all actors and a link to their imdb page
        private void cast_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CastPage(Movie));
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}