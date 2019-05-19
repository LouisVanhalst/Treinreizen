using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treinreizen.Domain.Entities;

namespace Treinreizen.ViewModel
{
    public class ShoppingCartVM
    {
        public List<CartVM> Cart { get; set; }
    }
    public class CartVM
    {
        public int TrajectId { get; set; }
        public string Van { get; set; }
        public string Naar { get; set; }
        public int AantalTickets { get; set; }
        public int Klasse { get; set; }
        public double Prijs { get; set; }
        public DateTime Vertrekdatum { get; set; }
        public DateTime Aankomstdatum { get; set; }
        public List<string> Voornamen { get; set; }
        public List<string> Achternamen { get; set; }
    }
}
