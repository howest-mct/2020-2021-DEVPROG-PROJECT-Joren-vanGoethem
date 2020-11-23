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
using Xamarin.Essentials;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieSettings : ContentPage
    {
        public int limit { get; set; }
        public string quality { get; set; }
        public int minimumRating { get; set; }
        public string query { get; set; }
        public string genre { get; set; }
        public string sortBy { get; set; }
        public string orderBy { get; set; }

        public MovieSettings()
        {
            limit = Preferences.Get("Limit", 10);
            quality = Preferences.Get("Quality", "all");
            minimumRating = Preferences.Get("MinimumRating", 0);
            genre = Preferences.Get("Genre", "all");
            sortBy = Preferences.Get("SortBy", "rating");
            orderBy = Preferences.Get("OrderBy", "desc");
            InitializeComponent();
            LoadSettings();
        }

        private async Task LoadSettings()
        {
            movieCount.Text = Convert.ToString(limit);
            List <RadioButton> radioButtonList = new List<RadioButton>() {allQualities, res720, res1080, res2160, res3D };

            foreach (RadioButton R in radioButtonList)
            {
                if (R.Text == quality)
                    R.IsChecked = true;
            }

            imdbRating.Text = Convert.ToString(minimumRating);
        }

        private void Cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            limit = Convert.ToUInt16(movieCount.Text);
            List<RadioButton> radioButtonList = new List<RadioButton>(){allQualities, res720, res1080, res2160, res3D };

            foreach(RadioButton R in radioButtonList)
            {
                if (R.IsChecked == true)
                    quality = R.Text;
            }

            minimumRating = Convert.ToUInt16(imdbRating.Text);
            query = movieQuery.Text;

            Preferences.Set("Limit", limit);
            Preferences.Set("Quality", quality);
            Preferences.Set("MinimumRating", minimumRating);
            Preferences.Set("Genre", genre);
            Preferences.Set("SortBy", sortBy);
            Preferences.Set("OrderBy", orderBy);
            Debug.WriteLine(minimumRating);

            Navigation.PushAsync(new MainPage(limit: limit, quality: quality, minimumRating: minimumRating, query: query, genre: genre, sortBy: sortBy, orderBy: orderBy)) ;
        }
    }
}