using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CastPage : ContentPage
    {
        public MovieDetails Movie { get; set; }
        public CastPage(MovieDetails selectedMovie)
        {
            InitializeComponent();
            Movie = selectedMovie;

            // load the cast and movie title
            movieName.Text = Movie.Title;
            cast.ItemsSource = Movie.Cast;
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        //redirect to actor's imdb page
        private void url_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Launcher.OpenAsync(new Uri(button.Text));
            }
        }
    }
}