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
        public int Limit { get; set; }
        public string Quality { get; set; }
        public int MinimumRating { get; set; }
        public string Query { get; set; }
        public string Genre { get; set; }
        public string SortBy { get; set; }
        public string OrderBy { get; set; }

        public MovieSettings()
        {
            Limit = Preferences.Get("Limit", 10);
            Quality = Preferences.Get("Quality", "all");
            MinimumRating = Preferences.Get("MinimumRating", 0);
            Genre = Preferences.Get("Genre", "all");
            SortBy = Preferences.Get("SortBy", "rating");
            OrderBy = Preferences.Get("OrderBy", "desc");
            InitializeComponent();
            LoadSettings();
        }

        private async Task LoadSettings()
        {
            movieCount.Text = Convert.ToString(Limit);
            List <RadioButton> radioButtonList = new List<RadioButton>() {allQualities, res720, res1080, res2160, res3D };

            foreach (RadioButton R in radioButtonList)
            {
                if (R.Text == Quality)
                    R.IsChecked = true;
            }

            imdbRating.Text = Convert.ToString(MinimumRating);
        }

        private void Cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            Limit = Convert.ToUInt16(movieCount.Text);
            List<RadioButton> radioButtonList = new List<RadioButton>(){allQualities, res720, res1080, res2160, res3D };

            foreach(RadioButton R in radioButtonList)
            {
                if (R.IsChecked == true)
                    Quality = R.Text;
            }

            MinimumRating = Convert.ToUInt16(imdbRating.Text);
            Query = movieQuery.Text;

            Preferences.Set("Limit", Limit);
            Preferences.Set("Quality", Quality);
            Preferences.Set("MinimumRating", MinimumRating);
            Preferences.Set("Query", Query);
            Preferences.Set("Genre", Genre);
            Preferences.Set("SortBy", SortBy);
            Preferences.Set("OrderBy", OrderBy);

            Navigation.PushAsync(new MainPage(limit: Limit, quality: Quality, minimumRating: MinimumRating, query: Query, genre: Genre, sortBy: SortBy, orderBy: OrderBy)) ;
        }
    }
}