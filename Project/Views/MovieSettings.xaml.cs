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
        public int Limit { get; set; }
        public int Page { get; set; }
        public string Quality { get; set; }
        public int Minimum_Rating { get; set; }
        public string Query { get; set; }
        public string Genre { get; set; }
        public string Sort_By { get; set; }
        public string Order_By { get; set; }

        public MovieSettings(int limit, int page, string quality, int minimum_rating, string query, string genre, string sort_by, string order_by)
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
            LoadSettings(Limit, Page, Quality, Minimum_Rating, Query, Genre, Sort_By, Order_By);
        }

        private async Task LoadSettings(int limit, int page, string quality, int minimum_rating, string query, string genre, string sort_by, string order_by)
        {
            Debug.WriteLine("test");
        }

        private async Task Savebtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(Limit, Page, Quality, Minimum_Rating, Query, Genre, Sort_By, Order_By));
        }

        private async Task Cancelbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}