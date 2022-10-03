using gLibraries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            onRefresh();
        }

        private void onRefresh(object sender = null, EventArgs e = null)
        {
            top_destination.ItemsSource = DestinationsModel.Limit(5);

            // Favorites initializer
            List<DestinationModel> favs = FavoritesModel.All();
            if (favs.Count() > 0)
            {
                fav_destination.ItemsSource = favs;
                lbl_fav.IsVisible = false;
                btn_fav.IsVisible = true;
                sv_fav.IsVisible = true;
            }
            else
            {
                lbl_fav.IsVisible = true;
                btn_fav.IsVisible = false;
                sv_fav.IsVisible = false;
            }

            // Visiteds initializer
            List<DestinationModel> reservations = ReservationsModel.All();
            List<DestinationModel> visiteds = new List<DestinationModel>();
            foreach (DestinationModel reservation in reservations)
            {
                if (reservation.Date < DateTime.Now)
                {
                    visiteds.Add(reservation);
                }
            }
            if (visiteds.Count() > 0)
            {
                visited_destination.ItemsSource = visiteds;
                lbl_visited.IsVisible = false;
                btn_visited.IsVisible = true;
                sv_visited.IsVisible = true;
            }
            else
            {
                lbl_visited.IsVisible = true;
                btn_visited.IsVisible = false;
                sv_visited.IsVisible = false;
            }
        }

        private void onWatchMoreClicked(object sender, EventArgs e)
        {
            Frame button = (Frame) sender;
            string _class = button.ClassId;
            object page = Views.getPage(_class);

            Menu menu = new Menu
            {
                Detail = new NavigationPage((Page)page)
            };
            Application.Current.MainPage = menu;
        }

        private void onImageClicked(object sender, EventArgs e)
        {
            Image button = (Image) sender;
            string id = button.ClassId;
            Navigation.PushAsync(new ImageModal(DestinationsModel.Get(id)));
        }

        private void onDetailClicked(object sender, EventArgs e)
        {
            Frame button = (Frame) sender;
            string id = button.ClassId;
            Navigation.PushAsync(new DetailModal(DestinationsModel.Get(id)));
        }

        private async void onFavMenuClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Que deseas hacer?", "Cancelar", null, "Ver detalles", "Reservar", "Quitar");
            switch (action)
            {
                case "Ver detalles":
                    onDetailClicked(sender, null);
                    break;
                case "Reservar":
                    await Navigation.PushModalAsync(new ReservationModal(
                        DestinationsModel.Get(((Frame)sender).ClassId)
                    ));
                    break;
                case "Quitar":
                    FavoritesModel.Remove(((Frame)sender).ClassId);
                    onRefresh();
                    break;
            }
        }

        private async void onDestinationMenuClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Que deseas hacer?", "Cancelar", null, "Ver detalles", "Reservar");
            switch (action)
            {
                case "Ver detalles":
                    onDetailClicked(sender, null);
                    break;
                case "Reservar":
                    await Navigation.PushModalAsync(new ReservationModal(
                        DestinationsModel.Get(((Frame)sender).ClassId)
                    ));
                    break;
            }
        }
    }
}