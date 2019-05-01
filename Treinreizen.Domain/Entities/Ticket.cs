using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int TripId { get; set; }
        public int TreinId { get; set; }
        public int Zetelnummer { get; set; }
        public int TreinNummer { get; set; }
        public string VoornaamPassagier { get; set; }
        public string AchternaamPassagier { get; set; }

        public Order Trip { get; set; }
        public Zitplaats Zitplaats { get; set; }
    }
}
