using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class ReisMogelijkheden
    {
        public ReisMogelijkheden()
        {
            Ritten = new HashSet<Ritten>();
            Ticket = new HashSet<Ticket>();
        }

        public int ReisMogelijkhedenId { get; set; }
        public int Vertrek { get; set; }
        public int Aankomst { get; set; }
        public TimeSpan? Vertrektijd { get; set; }
        public TimeSpan? Aankomsttijd { get; set; }
        public decimal? Prijs { get; set; }
        public int? TreinId { get; set; }
        public bool? Paasvakantie { get; set; }
        public bool? Kerstvakantie { get; set; }

        public Steden AankomstNavigation { get; set; }
        public Treinen Trein { get; set; }
        public Steden VertrekNavigation { get; set; }
        public ICollection<Ritten> Ritten { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
