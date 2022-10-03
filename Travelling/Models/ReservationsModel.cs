using gLibraries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travelling.Models
{
    public class ReservationsModel
    {
        static public List<DestinationModel> All()
        {
            string favorites = (string)gCookie.get("reservations");
            List<DestinationModel> result = new List<DestinationModel>();
            if (favorites != null)
            {
                result = JsonConvert.DeserializeObject<List<DestinationModel>>(favorites);
            }
            return result;
        }
        static public DestinationModel Get(string id)
        {
            return All().Find(d => d.Id.Equals(id));
        }

        static public bool Exists(string id)
        {
            return All().Exists(d => d.Id.Equals(id));
        }
        static public void Add(DestinationModel destination)
        {
            List<DestinationModel> destinations = All();
            destinations.Add(destination);
            gCookie.set("reservations", JsonConvert.SerializeObject(destinations));

        }
        static public void Remove(string id)
        {
            List<DestinationModel> new_destinations = new List<DestinationModel>();
            foreach (DestinationModel d in All())
            {
                if (!d.Id.Equals(id))
                {
                    new_destinations.Add(d);
                }
            }
            gCookie.set("reservations", JsonConvert.SerializeObject(new_destinations));
        }
        static public void Clean()
        {
            gCookie.clean("reservations");
        }
    }
}
