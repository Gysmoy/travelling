using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Modals;
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
            onRefresh();
        }

        private void onRefresh(object sender = null, EventArgs e = null)
        {
            collectionView.ItemsSource = FavoritesModel.All();
            refreshView.IsRefreshing = false;
        }

        private void onImageClicked(object sender = null, EventArgs e = null)
        {
            Image button = (Image)sender;
            string id = button.ClassId;
            Navigation.PushAsync(new ImageModal(DestinationsModel.Get(id)));
        }

        private void onReservationClicked(object sender = null, EventArgs e = null)
        {
            Frame button = (Frame)sender;
            string id = button.ClassId;
            Navigation.PushModalAsync(new ReservationModal(DestinationsModel.Get(id)));
        }

        private void onDetailClicked(object sender = null, EventArgs e = null)
        {
            Frame button = (Frame)sender;
            string id = button.ClassId;
            Navigation.PushAsync(new DetailModal(DestinationsModel.Get(id)));
        }

        private void onCleaningClicked(object sender, EventArgs e)
        {
            FavoritesModel.Clean();
            onRefresh();
        }

        private void onRemoveClicked(object sender, EventArgs e)
        {
            FavoritesModel.Remove(((Frame)sender).ClassId);
            onRefresh();
        }
    }
}