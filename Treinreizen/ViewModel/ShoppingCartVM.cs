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
        public int TrajectId { get; set; }
        public int AantalTickets { get; set; }
        public string Class { get; set; }
        public decimal Prijs  { get; set; }
    }





    public class HotelOrderVM
    {
        public int OrderId { get; set; }
        public string HotelNaam { get; set; }
        public string StadNaam { get; set; }
        public string Foto { get; set; }
    }
  
}
