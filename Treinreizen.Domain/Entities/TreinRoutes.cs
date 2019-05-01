using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class TreinRoutes
    {
        public TreinRoutes()
        {
            TreinenVanOrder = new HashSet<TreinenVanOrder>();
        }

        public int RouteId { get; set; }
        public int ReisMogelijkhedenId { get; set; }
        public DateTime Vertrekdatum { get; set; }
        public int TreinNummer { get; set; }

        public ReisMogelijkheden ReisMogelijkheden { get; set; }
        public Treinen TreinNummerNavigation { get; set; }
        public ICollection<TreinenVanOrder> TreinenVanOrder { get; set; }
    }
}
