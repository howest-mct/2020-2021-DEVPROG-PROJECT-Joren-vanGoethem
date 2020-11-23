using Project.Models;
using Project.Repositories;
using Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using FFImageLoading;
using FFImageLoading.Forms;



namespace Project
{
    public partial class MainPage : ContentPage
    {
        public int limit { get; set; }
        public int pageCounter { get; set; }
        public string quality { get; set; }
        public int minimumRating { get; set; }
        public string query { get; set; }
        public string genre { get; set; }
        public string sortBy { get; set; }
        public string orderBy { get; set; }

        public List<MovieDetails> movieList { get; set; }

        public MainPage(int limit = 10, int page = 1, string quality = "all", int minimumRating = 0, string query = "0", string genre = "all", string sortBy = "rating", string orderBy = "desc")
        {
            pageCounter = page;
            limit = Preferences.Get("Limit", 10);
            quality = Preferences.Get("Quality", "all");
            minimumRating = Preferences.Get("MinimumRating", 0);
            genre = Preferences.Get("Genre", "all");
            sortBy = Preferences.Get("SortBy", "rating");
            orderBy = Preferences.Get("OrderBy", "desc");
            InitializeComponent();
            LoadMovies(limit, pageCounter, quality, minimumRating, query, genre, sortBy, orderBy);
            //test();
        }

        private async Task test()
        {
            //List<Movie> movies = await MovieRepository.GetMoviesAsync();
            //foreach (Movie M in movies)
            //{
            //    Debug.Write(M.title);
            //    Debug.Write(M.torrents[0].quality);
            //}
        }

        private async Task LoadMovies(int limit = 10, int page = 1, string quality = "all", int minimumRating = 0, string query = "0", string genre = "all", string sortBy = "rating", string orderBy = "desc")
        {
            movieList = await MovieRepository.GetMoviesAsync(limit, page, quality, minimumRating, query, genre, sortBy, orderBy);
            movies.ItemsSource = movieList;
            movies.ScrollTo(movieList[0], ScrollToPosition.Start, false);
        }

        private void MovieFilterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MovieSettings());
        }
    
        private void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (movies.SelectedItem != null) //Debug.WriteLine("No items selected");
            {
                MovieDetails selected = (MovieDetails)movies.SelectedItem;
                Navigation.PushAsync(new MovieDetailsPage(selected));
                movies.SelectedItem = null;
            }
        }

        private void PrevPagebtn_Clicked(object sender, EventArgs e)
        {
            if (pageCounter > 1)
            {
                pageCounter -= 1;
                limit = Preferences.Get("Limit", 10);
                quality = Preferences.Get("Quality", "all");
                minimumRating = Preferences.Get("MinimumRating", 0);
                genre = Preferences.Get("Genre", "all");
                sortBy = Preferences.Get("SortBy", "rating");
                orderBy = Preferences.Get("OrderBy", "desc");
                LoadMovies(limit, pageCounter, quality, minimumRating, query, genre, sortBy, orderBy);
                page.Text = $"Page {pageCounter}";
                //movies.ScrollTo(movieList[0], ScrollToPosition.Start, false);
            }
            if (pageCounter == 1)
            {
                prevPage.BackgroundColor = Color.FromHex("#919191");
                prevPage.TextColor = Color.FromHex("#171717");
            }
        }

        private void NextPagebtn_Clicked(object sender, EventArgs e)
        {
            pageCounter += 1;
            limit = Preferences.Get("Limit", 10);
            quality = Preferences.Get("Quality", "all");
            minimumRating = Preferences.Get("MinimumRating", 0);
            genre = Preferences.Get("Genre", "all");
            sortBy = Preferences.Get("SortBy", "rating");
            orderBy = Preferences.Get("OrderBy", "desc");
            LoadMovies(limit, pageCounter, quality, minimumRating, query, genre, sortBy, orderBy);
            if (pageCounter > 1)
            {
                prevPage.BackgroundColor = Color.FromHex("#5da93c");
                prevPage.TextColor = Color.FromHex("#FFFFFF");
                //movies.ScrollTo(movieList[0], ScrollToPosition.Start, false);
            }
            page.Text = $"Page {pageCounter}";
        }

        //private void coverImage_Error(object sender, CachedImageEvents.ErrorEventArgs e)
        //{
        //    Debug.WriteLine("ERROR FUNCTION");
        //    CachedImage imageobject = (CachedImage)sender;
        //    Uri imageurl = new Uri("https://whetstonefire.org/wp-content/uploads/2020/06/image-not-available.jpg");
        //    imageobject.Source = ImageSource.FromUri(imageurl);
        //}
    }
}




// automatic subtitle download using imdb code
// automatic image download using movie name + /large-screenshot1.jpg 1-3
// 
//
//
//
//
//
//










