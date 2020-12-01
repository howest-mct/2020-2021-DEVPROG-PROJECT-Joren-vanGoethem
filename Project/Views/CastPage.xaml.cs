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

            movieName.Text = Movie.Title;
            cast.ItemsSource = Movie.Cast;
            //Debug.WriteLine(Movie.Text);
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void url_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Launcher.OpenAsync(new Uri(button.Text));
            }
        }
    }
}