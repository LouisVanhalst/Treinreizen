using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Hotels
    {
        public Hotels()
        {
            Order = new HashSet<Order>();
        }

        public int HotelId { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Site { get; set; }
        public int StadId { get; set; }
        public string Foto { get; set; }

        public Steden Stad { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
