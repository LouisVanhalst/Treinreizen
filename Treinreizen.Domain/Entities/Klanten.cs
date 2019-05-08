using System;
using System.Collections.Generic;

namespace Treinreizen.Domain.Entities
{
    public partial class Klanten
    {
        public int KlantId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Straat { get; set; }
        public int? StraatNr { get; set; }
        public int? Postcode { get; set; }
        public string Land { get; set; }
        public string Paswoord { get; set; }
        public string Email { get; set; }
    }
}
