using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Travelling
{
    public partial class Menu : FlyoutPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void onMenuClicked(object sender, SelectionChangedEventArgs e)
        {
            Components.FlyoutItem flyout = collectionView.SelectedItem as Components.FlyoutItem;
            if (flyout != null)
            {
                Detail = new NavigationPage((Page) Activator.CreateInstance(flyout.TargetPage));
                // collectionView.SelectedItem = null;
                IsPresented = false;
            }
        }

        public void goToPrivate(Page page)
        {
            Detail = new NavigationPage(page);
        }
    }
}
