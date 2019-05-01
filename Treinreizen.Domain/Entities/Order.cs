using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            Ticket = new HashSet<Ticket>();
            TreinenVanOrder = new HashSet<TreinenVanOrder>();
        }

        public int OrderId { get; set; }
        public int KlantId { get; set; }
        public int AantalTickets { get; set; }
        public string Class { get; set; }
        public decimal Prijs { get; set; }
        public int HotelId { get; set; }
        public int StatusId { get; set; }
        public DateTime? Boekingsdatum { get; set; }

        public Hotels Hotel { get; set; }
        public Klanten Klant { get; set; }
        public Status Status { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
        public ICollection<TreinenVanOrder> TreinenVanOrder { get; set; }
    }
}
