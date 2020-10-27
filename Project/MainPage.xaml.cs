using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            test();
        }

        private async void test()
        {
            List<Movie> Movies = await MovieRepository.GetMoviesAsync();
            foreach (Movie M in Movies)
            {
                Debug.Write(M.title);
                Debug.Write(M.torrents[0].quality);
            }
        }
    }
}
