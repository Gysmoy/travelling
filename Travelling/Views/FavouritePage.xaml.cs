using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritePage : ContentPage
    {
        public FavouritePage()
        {
            InitializeComponent();
        }

        private void onCleaningClicked(object sender, EventArgs e)
        {
            FavoritesModel.Clean();
        }
    }
}