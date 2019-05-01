using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class TreinenVanOrder
    {
        public int OrderId { get; set; }
        public int RouteId { get; set; }

        public Order Order { get; set; }
        public TreinRoutes Route { get; set; }
    }
}
