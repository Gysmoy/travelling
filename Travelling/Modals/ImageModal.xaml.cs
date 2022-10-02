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
    public partial class ImageModal : ContentPage
    {
        public ImageModal(DestinationModel destination)
        {
            InitializeComponent();
            contentPage.Title = destination.Name;
            image.Source = destination.Image;
        }
    }
}