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
            // try catch so it wont crash on a non-int type
            try
            {
                Limit = Convert.ToUInt16(Preferences.Get("Limit", 10));
            }
            catch (Exception ex)
            {
                Limit = 10;
            }
            try
            {
                MinimumRating = Convert.ToUInt16(Preferences.Get("MinimumRating", 0));
            }
            catch (Exception ex)
            {
                MinimumRating = 0;
            }
            Quality = Preferences.Get("Quality", "all");
            Genre = Preferences.Get("Genre", "all");
            SortBy = Preferences.Get("SortBy", "rating");
            OrderBy = Preferences.Get("OrderBy", "desc");
            InitializeComponent();
            LoadSettings();
        }

        // load all saved settings
        private async Task LoadSettings()
        {
            movieCount.Text = Convert.ToString(Limit);

            List <RadioButton> radioButtonList = new List<RadioButton>() {allQualities, res720, res1080, res2160, res3D };
            foreach (RadioButton R in radioButtonList)
            {
                if (R.Text == Quality)
                    R.IsChecked = true;
            }

            List<RadioButton> OrderRadios = new List<RadioButton>() { asc, desc };
            foreach (RadioButton R in OrderRadios)
            {
                if (R.Text == OrderBy)
                    R.IsChecked = true;
            }


            imdbRating.Text = Convert.ToString(MinimumRating);

            loadPicker();
        }

        // create picker with correct items
        private async Task loadPicker()
        {
            Dictionary<string, string> Options = new Dictionary<string, string>
            {
                { "Title", "title" }, { "Year", "year" },
                { "Rating", "rating" }, { "Peers", "peers" },
                { "Seeds", "seeds" }, { "Downloads", "download_count" },
                { "Likes", "like_count" }, { "Date Added", "date_added" }
            };

            //Picker picker = sortByPicker;

            foreach (string Option in Options.Keys)
            {
                sortByPicker.Items.Add(Option);
            }
            List<string> values = new List<string>(Options.Values);
            for (int x = 1; x < Options.Values.Count; x++)
            {
                if (values[x] == SortBy)
                {
                    sortByPicker.SelectedIndex = x;
                }
            }
            // Create BoxView for displaying picked Color

            sortByPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (sortByPicker.SelectedIndex == -1)
                {
                    Preferences.Set("SortBy", "rating");
                    SortBy = "rating";
                }
                else
                {
                    string Option = sortByPicker.Items[sortByPicker.SelectedIndex];
                    Preferences.Set("Limit", Options[Option]);
                    SortBy = Options[Option];
                }
            };
        }

        private void Cancelbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        //save everything to preferences and load new page with movies
        private void Savebtn_Clicked(object sender, EventArgs e)
        {
            App.Cache.RemoveAll();
            try
            {
                Limit = Convert.ToInt16(movieCount.Text);
            }
            catch (Exception ex)
            {
                Limit = 10;
            }
            try
            {
                MinimumRating = Convert.ToInt16(imdbRating.Text);
            }
            catch (Exception ex)
            {
                MinimumRating = 0;
            }

            List<RadioButton> ResolutionRadios = new List<RadioButton>() { allQualities, res720, res1080, res2160, res3D };
            foreach (RadioButton R in ResolutionRadios)
            {
                if (R.IsChecked == true)
                    Quality = R.Text;
            }

            List<RadioButton> OrderRadios = new List<RadioButton>() { asc, desc };
            foreach (RadioButton R in OrderRadios)
            {
                if (R.IsChecked == true)
                    OrderBy = R.Text;
            }



            Query = movieQuery.Text;

            Preferences.Set("Limit", Convert.ToUInt16(Limit));
            Preferences.Set("Quality", Quality);
            Preferences.Set("MinimumRating", Convert.ToUInt16(MinimumRating));
            Preferences.Set("Query", Query);
            Preferences.Set("Genre", Genre);
            Preferences.Set("SortBy", SortBy);
            Preferences.Set("OrderBy", OrderBy);

            Navigation.PushAsync(new MainPage(limit: Limit, quality: Quality, minimumRating: MinimumRating, query: Query, genre: Genre, sortBy: SortBy, orderBy: OrderBy)) ;
        }

        
    }
}