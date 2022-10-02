using gLibraries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
using System.Text;

namespace Travelling.Models
{
    public class DestinationsModel
    {
        public static List<DestinationModel> All()
        {

            List<DestinationModel> destinations = null;

            string data = (string)gCookie.get("destinations");

            if (data == null)
            {
                var request = new WebClient();
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
                (
                    delegate { return true; }
                );
                try
                {
                    data = request.DownloadString("https://sode.me/locations.php");
                } catch
                {
                    data = "[]";
                }

                gCookie.set("destinations", data);
            }

            destinations = JsonConvert.DeserializeObject<List<DestinationModel>>(data);

            return destinations;
        }

        static public DestinationModel Get(string id)
        {
            return All().Find(d => d.Id.Equals(id));
        }
        static public List<DestinationModel> Search(string value)
        {
            value = value.ToLower();
            return All().FindAll(all =>
                all.Id.ToLower().Equals(value) ||
                all.Name.ToLower().Contains(value) ||
                all.Region.ToLower().Contains(value) ||
                all.Province.ToLower().Contains(value) ||
                all.City.ToLower().Contains(value) ||
                all.Location.ToLower().Contains(value)
            );
        }
        static public List<DestinationModel> Limit(int limit)
        {
            var result = new List<DestinationModel>();
            var list = All();
            limit = list.Count < limit ? list.Count : limit;
            for(int i = 0; i < limit; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
