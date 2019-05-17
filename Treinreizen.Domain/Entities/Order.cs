using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int OrderId { get; set; }
        public int AantalTickets { get; set; }
        public int StatusId { get; set; }
        public DateTime? Boekingsdatum { get; set; }
        public string KlantId { get; set; }
        public decimal? Prijs { get; set; }
        public int? KlasseId { get; set; }
        public int? TrajectId { get; set; }
        public DateTime? Vertrekdatum { get; set; }
        public DateTime? Aankomstdatum { get; set; }

        public AspNetUsers Klant { get; set; }
        public Klasse Klasse { get; set; }
        public Status Status { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
