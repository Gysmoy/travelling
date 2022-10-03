using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Modals;
using Travelling.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace Travelling.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitedPage : ContentPage
    {
        public VisitedPage()
        {
            InitializeComponent();
            onRefresh();
        }

        private void onRefresh(object sender = null, EventArgs e = null)
        {
            List<DestinationModel> destinations = ReservationsModel.All();
            List<DestinationModel> reservations = new List<DestinationModel>();
            foreach (DestinationModel dest in destinations)
            {
                if (dest.Date <= DateTime.Now)
                {
                    reservations.Add(dest);
                }
            }
            collectionView.ItemsSource = reservations;
            refreshView.IsRefreshing = false;
        }
        private void onImageClicked(object sender, EventArgs e)
        {
            Image button = (Image)sender;
            string id = button.ClassId;
            Navigation.PushAsync(new ImageModal(DestinationsModel.Get(id)));
        }
    }
}