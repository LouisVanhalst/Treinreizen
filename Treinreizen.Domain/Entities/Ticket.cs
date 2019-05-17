using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int OrderId { get; set; }
        public int Zetelnummer { get; set; }
        public string VoornaamPassagier { get; set; }
        public string AchternaamPassagier { get; set; }
        public int? ReismogelijkhedenId { get; set; }

        public Order Order { get; set; }
        public ReisMogelijkheden Reismogelijkheden { get; set; }
    }
}
