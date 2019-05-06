using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Display(Name = "Heen en terug")]
        public bool isEnkel { get; set; }


        [Required(ErrorMessage = "Vul de plaats van vertrek in.")]
        public int? Van { get; set; }

        [Required(ErrorMessage = "Vul de bestemming in.")]
        //testen naar != van
        public int? Naar { get; set; }

        [Display(Name = "Vertrekdatum heenreis")]
        [Required(ErrorMessage = "Vul datum van vertrek heenreis in.")]
        public string HeenDate { get; set; }

        [Display(Name = "Vertrekdatum terugreis")]
        [Required(ErrorMessage = "Vul datum van vertrek terugreis in.")]
        public string TerugDate { get; set; }

        [Display(Name = "Aantal Tickets")]
        [Required(ErrorMessage = "Vul het aantal passagiers in.")]
        [Range(1, 9, ErrorMessage = "Er kunnen maximum 9 tickets besteld worden. Indien u er meer wenst gelieve contact op te nemen.")]
        public int Aantal { get; set; }

        public int Klasse { get; set; }

        public SelectList Klasses { get; set; }

        public IEnumerable<Klasse> GeselecteerdeKlasse { get; set; }

        public SelectList Steden { get; set; }

        public IEnumerable<TreinRoutes> RoutesHeen { get; set; }

        public IEnumerable<TreinRoutes> RoutesTerug { get; set; }
    }
}
