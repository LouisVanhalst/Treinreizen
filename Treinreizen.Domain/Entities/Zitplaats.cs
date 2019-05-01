using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Zitplaats
    {
        public Zitplaats()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int TreinNummer { get; set; }
        public int Zetelnummer { get; set; }
        public int KlasseId { get; set; }

        public Klasse Klasse { get; set; }
        public Treinen TreinNummerNavigation { get; set; }
        public ICollection<Ticket> Ticket { get; set; }
    }
}
