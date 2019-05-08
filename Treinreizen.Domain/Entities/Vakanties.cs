using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Vakanties
    {
        public int VakantieId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime Einde { get; set; }
        public float PercentExtraPlaatsen { get; set; }
        public bool IsKerst { get; set; }
    }
}
