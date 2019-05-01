using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string Naam { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
