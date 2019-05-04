using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treinreizen.ViewModel
{
    public class ShoppingCartVM
    {
        public List<CartVM> Cart { get; set; }
    }
    public class CartVM
    {
        public int OrderId { get; set; }
        public int AantalTickets { get; set; }
        public List<OverstappenVM> Overstappen { get; set; }
        public string Class { get; set; }
        public float Prijs  { get; set; }
        public System.DateTime Boekingsdatum { get; set; }
        public string Status { get; set; }

    }
    public class OverstappenVM
    {
        public string Vertrek { get; set; }
        public string Aankomst { get; set; }
        public string TreinNaam { get; set; }
    }
}
