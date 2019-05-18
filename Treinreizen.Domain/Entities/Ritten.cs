using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Ritten
    {
        public int ReisMogelijkhedenId { get; set; }
        public int TrajectId { get; set; }
        public int? Volgorde { get; set; }

        public ReisMogelijkheden ReisMogelijkheden { get; set; }
        public Traject Traject { get; set; }
    }
}
