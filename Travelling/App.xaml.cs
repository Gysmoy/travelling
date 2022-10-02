﻿using gLibraries;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Travelling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            gCookie.clean("destinations");
            MainPage = new Menu();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
