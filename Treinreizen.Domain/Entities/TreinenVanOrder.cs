using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class TreinenVanOrder
    {
        public int OrderId { get; set; }
        public int TrajectId { get; set; }
        public DateTime? Vertrekdatum { get; set; }
        public DateTime? Aankomstdatum { get; set; }

        public Order Order { get; set; }
        public Traject Traject { get; set; }
    }
}
