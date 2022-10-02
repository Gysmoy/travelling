using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Models;
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
        }

        private void onCloseClicked(object sender, EventArgs e)
        {
            //Navigation.PopModalAsync();
        }
    }
}