﻿using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Traject
    {
        public Traject()
        {
            Order = new HashSet<Order>();
            Ritten = new HashSet<Ritten>();
        }

        public int TrajectId { get; set; }
        public int? VertrekStad { get; set; }
        public int? AankomstStad { get; set; }

        public Steden AankomstStadNavigation { get; set; }
        public Steden VertrekStadNavigation { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Ritten> Ritten { get; set; }
    }
}
