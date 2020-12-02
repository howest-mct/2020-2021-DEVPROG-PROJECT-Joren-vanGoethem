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
        public int Limit { get; set; }
        public int PageCounter { get; set; }
        public string Quality { get; set; }
        public int MinimumRating { get; set; }
        public string Query { get; set; }
        public string Genre { get; set; }
        public string SortBy { get; set; }
        public string OrderBy { get; set; }

        public List<MovieDetails> MovieList { get; set; }

        public MainPage(int limit = 10, int page = 1, string quality = "all", int minimumRating = 0, string query = "0", string genre = "all", string sortBy = "rating", string orderBy = "desc")
        {
            PageCounter = page;
            try
            {
                Limit = Convert.ToUInt16(Preferences.Get("Limit", limit));
            }
            catch (Exception ex)
            {
                Limit = 10;
            }
            try
            {
                MinimumRating = Convert.ToUInt16(Preferences.Get("MinimumRating", minimumRating));
            }
            catch (Exception ex)
            {
                MinimumRating = 0;
            }
            Quality = Preferences.Get("Quality", quality);
            Query = query;
            Genre = Preferences.Get("Genre", genre);
            SortBy = Preferences.Get("SortBy", sortBy);
            OrderBy = Preferences.Get("OrderBy", orderBy);
            InitializeComponent();
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                DisplayAlert("Alert", "This app requires a network connection.", "OK");
            }
            loadingImage.IsVisible = true;
            LoadMovies(Limit, PageCounter, Quality, MinimumRating, Query, Genre, SortBy, OrderBy);
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
            MovieList = App.Cache.Get<List<MovieDetails>>($"moviepage {page}");

            if (MovieList == null) { 
                MovieList = await MovieRepository.GetMoviesAsync(limit, page, quality, minimumRating, query, genre, sortBy, orderBy);
                App.Cache.Set<List<MovieDetails>>($"moviepage {page}", MovieList);
            }

            movies.ItemsSource = MovieList;
            movies.ScrollTo(MovieList[0], ScrollToPosition.Start, false);
            loadingImage.IsVisible = false;
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
            if (PageCounter > 1)
            {
                loadingImage.IsVisible = true;
                PageCounter -= 1;
                Limit = Convert.ToUInt16(Preferences.Get("Limit", 10));
                Quality = Preferences.Get("Quality", "all");
                MinimumRating = Convert.ToUInt16(Preferences.Get("MinimumRating", 0));
                Genre = Preferences.Get("Genre", "all");
                SortBy = Preferences.Get("SortBy", "rating");
                OrderBy = Preferences.Get("OrderBy", "desc");
                LoadMovies(Limit, PageCounter, Quality, MinimumRating, Query, Genre, SortBy, OrderBy);
                page.Text = $"Page {PageCounter}";
                //movies.ScrollTo(movieList[0], ScrollToPosition.Start, false);
            }
            if (PageCounter == 1)
            {
                prevPage.BackgroundColor = Color.FromHex("#919191");
                prevPage.TextColor = Color.FromHex("#171717");
            }
        }

        private void NextPagebtn_Clicked(object sender, EventArgs e)
        {
            loadingImage.IsVisible = true;
            PageCounter += 1;
            Limit = Convert.ToUInt16(Preferences.Get("Limit", 10));
            Quality = Preferences.Get("Quality", "all");
            MinimumRating = Convert.ToUInt16(Preferences.Get("MinimumRating", 0));
            Genre = Preferences.Get("Genre", "all");
            SortBy = Preferences.Get("SortBy", "rating");
            OrderBy = Preferences.Get("OrderBy", "desc");
            LoadMovies(Limit, PageCounter, Quality, MinimumRating, Query, Genre, SortBy, OrderBy);
            if (PageCounter > 1)
            {
                prevPage.BackgroundColor = Color.FromHex("#5da93c");
                prevPage.TextColor = Color.FromHex("#FFFFFF");
                //movies.ScrollTo(movieList[0], ScrollToPosition.Start, false);
            }
            page.Text = $"Page {PageCounter}";
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










