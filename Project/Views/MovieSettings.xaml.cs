using Newtonsoft.Json.Linq;
using Project.Models;
using Project.Repositories;
using Project.Views;
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
    public partial class MovieSettings : ContentPage
    {
        public int limit { get; set; }
        public int page { get; set; }
        public string quality { get; set; }
        public int minimumRating { get; set; }
        public string query { get; set; }
        public string genre { get; set; }
        public string sortBy { get; set; }
        public string orderBy { get; set; }

        public MovieSettings(int limit = 10, int page = 1, string quality = "all", int minimumRating = 0, string query = "0", string genre = "all", string sortBy = "rating", string orderBy = "desc")
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
            LoadSettings(limit, page, quality, minimumRating, query, genre, sortBy, orderBy);
        }

        private async Task LoadSettings(int limit, int page, string quality, int minimum_rating, string query, string genre, string sortBy, string orderBy)
        {
            Debug.WriteLine("test");
        }

        private void Cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(limit, page, quality, minimumRating, query, genre, sortBy, orderBy));
        }
    }
}