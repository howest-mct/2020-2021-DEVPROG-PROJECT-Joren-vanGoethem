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

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string Quality { get; set; }
        public int Minimum_Rating { get; set; }
        public string Query { get; set; }
        public string Genre { get; set; }
        public string Sort_By { get; set; }
        public string Order_By { get; set; }

        public List<Movie> MovieList { get; set; }

        public MainPage(int limit = 10, int page = 1, string quality = "all", int minimum_rating = 0, string query = "0", string genre = "all", string sort_by = "rating", string order_by = "desc")
        {
            Limit = limit;
            Page = page;
            Quality = quality;
            Minimum_Rating = minimum_rating;
            Query = query;
            Genre = genre;
            Sort_By = sort_by;
            Order_By = order_by;
            InitializeComponent();
            LoadMovies(Limit, Page, Quality, Minimum_Rating, Query, Genre, Sort_By, Order_By);
            test();
        }

        private async Task test()
        {
            List<Movie> Movies = await MovieRepository.GetMoviesAsync();
            foreach (Movie M in Movies)
            {
                Debug.Write(M.title);
                Debug.Write(M.torrents[0].quality);
            }
        }

        private async Task LoadMovies(int limit = 10, int page = 1, string quality = "all", int minimum_rating = 0, string query = "0", string genre = "all", string sort_by = "rating", string order_by="desc")
        {
            MovieList = await MovieRepository.GetMoviesAsync(limit, page, quality, minimum_rating, query, genre,sort_by, order_by);
            lvwMovies.ItemsSource = MovieList;
        }

        private async Task PrevPagebtn_Clicked(object sender, EventArgs e)
        {
            if (Page > 1)
            {
                Page -= 1;
                await LoadMovies(page: Page);
                Pagelbl.Text = $"Page {Page}";
                lvwMovies.ScrollTo(MovieList[0], ScrollToPosition.Start, true);
            }
            if (Page == 1)
            {
                PrevPagebtn.BackgroundColor = Color.FromHex("#919191");
                PrevPagebtn.TextColor = Color.FromHex("#171717");
            }
        }

        private async Task NextPagebtn_Clicked(object sender, EventArgs e)
        {
            Page += 1;
            await LoadMovies(page: Page);
            if (Page > 1)
            {
                PrevPagebtn.BackgroundColor = Color.FromHex("#5da93c");
                PrevPagebtn.TextColor = Color.FromHex("#FFFFFF");
                lvwMovies.ScrollTo(MovieList[0], ScrollToPosition.Start, true);
            }
            Pagelbl.Text = $"Page {Page}";
        }

        private async Task MovieFilterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MovieSettings(Limit, Page, Quality, Minimum_Rating, Query, Genre, Sort_By, Order_By));
        }
    }
}
