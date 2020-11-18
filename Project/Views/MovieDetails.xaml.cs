﻿using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetails : ContentPage
    {
        public Movie selectedMovie { get; set; }
        public MovieDetails(Movie movie)
        {
            selectedMovie = movie;
            InitializeComponent();
            LoadMovieDetails();
        }
        private async Task LoadMovieDetails()
        {
            movieName.Text = selectedMovie.title;
            year.Text = Convert.ToString(selectedMovie.year);
            genres.Text = selectedMovie.genreString;
            moviePicture.Source = selectedMovie.largeCoverImage;
            runtime.Text = selectedMovie.runtimeString;
            resolutions.Text = selectedMovie.resolutions;
            rating.Text = Convert.ToString(selectedMovie.rating);
            description.Text = selectedMovie.descriptionFull;
        }

        private void trailer_Clicked(object sender, EventArgs e)
        {
            if (selectedMovie.ytTrailerCode != null) //Debug.WriteLine("No items selected");
            {
                Navigation.PushAsync(new Trailer(selectedMovie.ytTrailerCode));
            }
        }
    }
}