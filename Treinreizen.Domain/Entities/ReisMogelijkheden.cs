using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class ReisMogelijkheden
    {
        public ReisMogelijkheden()
        {
            TreinRoutes = new HashSet<TreinRoutes>();
        }

        public int ReisMogelijkhedenId { get; set; }
        public int Vertrek { get; set; }
        public int Aankomst { get; set; }
        public TimeSpan? Vertrektijd { get; set; }
        public TimeSpan? Aankomsttijd { get; set; }
        public Decimal? Prijs { get; set; }

        public Steden AankomstNavigation { get; set; }
        public Steden VertrekNavigation { get; set; }
        public ICollection<TreinRoutes> TreinRoutes { get; set; }
    }
}
