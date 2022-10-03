using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Models;
using Travelling.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelling.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationModal : ContentPage
    {
        private DestinationModel _destination;
        public ReservationModal(DestinationModel destination)
        {
            InitializeComponent();
            BindingContext = _destination = destination;
            //entry_date.MinimumDate = DateTime.Now;
        }

        private void onCloseClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void onQuantityChanged(object sender, TextChangedEventArgs e)
        {
            string _quantity = entry_quantity.Text;
            _destination.Quantity = string.IsNullOrWhiteSpace(_quantity) ? 0 : int.Parse(_quantity);

            decimal total = _destination.Quantity * _destination.Price;
            lbl_total.Text = $"Total: {total}";
        }

        private void onReservationClicked(object sender, EventArgs e)
        {
            _destination.Date = entry_date.Date;
            _destination.Total = _destination.Quantity * _destination.Price;
            if (_destination.Total == 0)
            {
                DisplayAlert("Alerta", "Debes agregar al menos una persona", "OK");
                return;
            }
            ReservationsModel.Add(_destination);
            DisplayAlert("Aviso", "Tu reserva solo estará vigente hasta las 48 horas", "Entendido");

            Menu menu = new Menu
            {
                Detail = new NavigationPage(new HomePage())
            };
            Application.Current.MainPage = menu;
        }
    }
}