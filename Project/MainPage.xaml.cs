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
        public int limit { get; set; }
        public int page { get; set; }
        public string quality { get; set; }
        public int minimumRating { get; set; }
        public string query { get; set; }
        public string genre { get; set; }
        public string sortBy { get; set; }
        public string orderBy { get; set; }

        public List<Movie> movieList { get; set; }

        public MainPage(int limit = 10, int page = 1, string quality = "all", int minimumRating = 0, string query = "0", string genre = "all", string sortBy = "rating", string orderBy = "desc")
        {
            //limit = limit;
            //page = page;
            //quality = quality;
            //minimumRating = minimumRating;
            //query = query;
            //genre = genre;
            //sortBy = sortBy;
            //orderBy = orderBy;
            InitializeComponent();
            LoadMovies(limit, page, quality, minimumRating, query, genre, sortBy, orderBy);
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
            Debug.WriteLine("test1");
            movieList = await MovieRepository.GetMoviesAsync(limit, page, quality, minimumRating, query, genre, sortBy, orderBy);
            Debug.WriteLine("test2");
            movies.ItemsSource = movieList;
        }

        private void MovieFilterBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MovieSettings(limit, page, quality, minimumRating, query, genre, sortBy, orderBy));
        }
    
        private void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (movies.SelectedItem != null) //Debug.WriteLine("No items selected");
            {
                Movie selected = (Movie)movies.SelectedItem;
                Navigation.PushAsync(new MovieDetails(selected));
                movies.SelectedItem = null;
            }
        }



        private void PrevPagebtn_Clicked(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page -= 1;
                LoadMovies(page: page);
                Pagelbl.Text = $"Page {page}";
                movies.ScrollTo(movieList[0], ScrollToPosition.Start, true);
            }
            if (page == 1)
            {
                PrevPagebtn.BackgroundColor = Color.FromHex("#919191");
                PrevPagebtn.TextColor = Color.FromHex("#171717");
            }
        }

        private void NextPagebtn_Clicked(object sender, EventArgs e)
        {
            page += 1;
            LoadMovies(page: page);
            if (page > 1)
            {
                PrevPagebtn.BackgroundColor = Color.FromHex("#5da93c");
                PrevPagebtn.TextColor = Color.FromHex("#FFFFFF");
                movies.ScrollTo(movieList[0], ScrollToPosition.Start, true);
            }
            Pagelbl.Text = $"Page {page}";
        }
    }
}
