﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Treinreizen.Domain.Entities;

namespace Treinreizen.ViewModel
{
    public class ZoekListVM
    {
        [Required(ErrorMessage = "Vul de plaats van vertrek in.")]
        public int Van { get; set; }

        [Required(ErrorMessage = "Vul de bestemming in.")]
        public int Naar { get; set; }

        [Display(Name = "Vertrekdatum heenreis")]
        [Required(ErrorMessage = "Vul datum van vertrek heenreis in.")]
        public string HeenDate { get; set; }

        [Display(Name = "Vertrekdatum terugreis")]
        public string TerugDate { get; set; }

        [Display(Name = "Aantal Tickets")]
        [Required(ErrorMessage = "Vul het aantal passagiers in.")]
        public int Aantal { get; set; }

        public int Klasse { get; set; }

        public SelectList Klasses { get; set; }

        public int TrajectId { get; set; }

        public Klasse GeselecteerdeKlasse { get; set; }

        public SelectList Steden { get; set; }

        public IEnumerable<Ritten> RoutesHeen { get; set; }

        public IEnumerable<Ritten> RoutesTerug { get; set; }

        public PassagierslijstVM Passagierslijst { get; set; }
    

    //public class PassagierVM
    //{

    //    public string Voornaam { get; set; }
    //    public string Achternaam { get; set; }
    //}
}
}
