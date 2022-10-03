using System;
using System.Collections.Generic;
using System.Text;

namespace Travelling.Models
{
    public class DestinationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Review { get; set; }
        public string Image { get; set; }
        public string Region { get; set; }
        public string[] Regions {get; set; }
        public string Province { get; set; }
        public string[] Provinces { get; set; }
        public string City { get; set; }
        public string[] Cities { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }

        // Atributos de reserva
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public DestinationModel ()
        {
            this.Price = (decimal) 25.00;
        }
    }
}
