﻿using System;
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
    public partial class Torrents : ContentPage
    {
        public Torrents()
        {
            InitializeComponent();
            Launcher.OpenAsync(new Uri("http://www.google.com"));
        }
    }
}