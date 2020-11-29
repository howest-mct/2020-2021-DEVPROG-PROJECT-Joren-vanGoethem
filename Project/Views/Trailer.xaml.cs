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
    public partial class Trailer : ContentPage
    {
        public Trailer(string trailerCode)
        {
            InitializeComponent();
            trailer.Source = $"https://www.youtube.com/embed/{trailerCode}";
        }
    }
}