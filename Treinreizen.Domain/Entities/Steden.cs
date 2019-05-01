using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Steden
    {
        public Steden()
        {
            Hotels = new HashSet<Hotels>();
            ReisMogelijkhedenAankomstNavigation = new HashSet<ReisMogelijkheden>();
            ReisMogelijkhedenVertrekNavigation = new HashSet<ReisMogelijkheden>();
        }

        public int StadId { get; set; }
        public string Naam { get; set; }

        public ICollection<Hotels> Hotels { get; set; }
        public ICollection<ReisMogelijkheden> ReisMogelijkhedenAankomstNavigation { get; set; }
        public ICollection<ReisMogelijkheden> ReisMogelijkhedenVertrekNavigation { get; set; }
    }
}
