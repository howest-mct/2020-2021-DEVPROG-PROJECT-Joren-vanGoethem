using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TorrentPage : ContentPage
    {
        public MovieDetails Movie { get; set; }
        public TorrentPage(MovieDetails selectedMovie)
        {
            Movie = selectedMovie;
            InitializeComponent();
            LoadTorrents();
        }

        // load all torrents into listview
        private async void LoadTorrents()
        {
            movieName.Text = Movie.Title;
            torrents.ItemsSource = Movie.Torrents;
        }

        // redirect to url for downloading the .torrent file
        private void download_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Launcher.OpenAsync(new Uri(Convert.ToString(button.BindingContext)));
            }
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}