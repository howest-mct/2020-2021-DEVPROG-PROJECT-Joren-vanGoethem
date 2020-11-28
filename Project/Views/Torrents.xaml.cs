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
    public partial class Torrents : ContentPage
    {
        public MovieDetails movie { get; set; }
        public Torrents(MovieDetails selectedmovie)
        {
            movie = selectedmovie;
            InitializeComponent();
            LoadTorrents();
        }

        private async void LoadTorrents()
        {
            movieName.Text = movie.title;
            torrents.ItemsSource = movie.torrents;
        }

        private void download_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Launcher.OpenAsync(new Uri(button.Text));
            }
        }

    }
}