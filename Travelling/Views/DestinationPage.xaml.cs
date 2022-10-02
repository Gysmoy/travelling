using gLibraries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Modals;
using Travelling.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DestinationPage : ContentPage
    {
        public DestinationPage()
        {
            InitializeComponent();
            collectionView.ItemsSource = DestinationsModel.All();
            Clipboard.SetTextAsync(JsonConvert.SerializeObject(FavoritesModel.All()));
        }

        private void onRefresh(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = true;

            gCookie.clean("destinations");

            entry.Text = "";
            collectionView.ItemsSource = DestinationsModel.All();
            refreshView.IsRefreshing = false;
        }

        private void onSearch(object sender, EventArgs e)
        {
            string value = entry.Text;
            collectionView.ItemsSource = DestinationsModel.Search(value);
        }

        private void onImageClicked(object sender, EventArgs e)
        {
            Image button = (Image)sender;
            string id = button.ClassId;
            Navigation.PushAsync(new ImageModal(DestinationsModel.Get(id)));
        }
    }
}