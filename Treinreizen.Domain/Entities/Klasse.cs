using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Klasse
    {
        public Klasse()
        {
            Zitplaats = new HashSet<Zitplaats>();
        }

        public int KlasseId { get; set; }
        public string Klassenaam { get; set; }
        public float? Toeslag { get; set; }

        public ICollection<Zitplaats> Zitplaats { get; set; }
    }
}
