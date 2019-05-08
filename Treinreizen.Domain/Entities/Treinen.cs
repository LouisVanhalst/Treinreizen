﻿using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Treinen
    {
        public Treinen()
        {
            ReisMogelijkheden = new HashSet<ReisMogelijkheden>();
            Zitplaats = new HashSet<Zitplaats>();
        }

        public int TreinNummer { get; set; }
        public string TreinNaam { get; set; }
        public int AantalPlaatsenEc { get; set; }
        public int AantalPlaatsenBus { get; set; }

        public ICollection<ReisMogelijkheden> ReisMogelijkheden { get; set; }
        public ICollection<Zitplaats> Zitplaats { get; set; }
    }
}
