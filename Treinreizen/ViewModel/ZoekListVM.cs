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
        public int? Naar { get; set; }

        [Display(Name = "Vertrek datum heenreis")]
        [Required(ErrorMessage = "Vul datum van vertrek heenreis in.")]
        public string HeenDate { get; set; }

        [Display(Name = "Vertrek datum terugreis")]
        [Required(ErrorMessage = "Vul datum van vertrek terugreis in.")]
        public string TerugDate { get; set; }

        [Required(ErrorMessage = "Vul het aantal passagiers in.")]
        public int Aantal { get; set; }

        public SelectList Steden { get; set; }

        public IEnumerable<TreinRoutes> Routes { get; set; }
    }
}
