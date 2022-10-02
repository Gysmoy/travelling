using System;
using System.Collections.Generic;
using System.Text;

namespace Travelling.Views
{
    public class Views
    {
        static public object getPage(string page)
        {
            object obj = null;
            switch(page)
            {
                case "HomePage":
                    obj = new HomePage();
                    break;
                case "DestinationPage":
                    obj = new DestinationPage();
                    break;
                case "FavouritePage":
                    obj = new FavouritePage();
                    break;
                case "ReservationPage":
                    obj = new ReservationPage();
                    break;
                case "VisitedPage":
                    obj = new VisitedPage();
                    break;
                case "AboutPage":
                    obj = new AboutPage();
                    break;
            }
            return obj;
        }
    }
}
