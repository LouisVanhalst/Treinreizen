using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Klasse
    {
        public Klasse()
        {
            Order = new HashSet<Order>();
        }

        public int KlasseId { get; set; }
        public string Klassenaam { get; set; }
        public float? Toeslag { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
