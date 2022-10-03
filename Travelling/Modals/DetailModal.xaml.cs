using System;
using Travelling.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelling.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailModal : ContentPage
    {
        private DestinationModel _destination;
        public DetailModal(DestinationModel destination)
        {
            InitializeComponent();
            BindingContext = _destination = destination;
            checkIfFavourite();
        }

        private void checkIfFavourite()
        {
            if (FavoritesModel.Exists(_destination.Id))
            {
                toolbarItem.IconImageSource = "star_fill_1.png";
            } else
            {
                toolbarItem.IconImageSource = "star_fill_0.png";
            }
        }

        private void onFavouriteClicked(object sender, EventArgs e)
        {
            string icon = toolbarItem.IconImageSource.ToString();
            if (icon.Equals("File: star_fill_0.png"))
            {
                FavoritesModel.Add(_destination);
            } else
            {
                FavoritesModel.Remove(_destination.Id);
            }
            checkIfFavourite();
        }

        private void onReservationClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReservationModal(_destination));
        }
    }
}