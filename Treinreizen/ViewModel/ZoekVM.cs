using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Treinreizen.ViewModel
{
    public class ZoekVM
    {
        [Display(Name = "Heen en terug")]
        public bool isEnkel { get; set; }

        [Required(ErrorMessage = "Vul de plaats van vertrek in.")]
        public string Van { get; set; }

        [Required(ErrorMessage = "Vul de bestemming in.")]
        public string Naar { get; set; }

        [Display(Name = "Vertrek datum heenreis")]
        [Required(ErrorMessage = "Vul datum van vertrek heenreis in.")]
        public string HeenDate { get; set; }

        [Display(Name = "tijdstip heenreis")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Vul tijdstip van vertrek heenreis in.")]
        public DateTime HeenTime { get; set; }

        [Display(Name = "Vertrek datum terugreis")]
        [Required(ErrorMessage = "Vul datum van vertrek terugreis in.")]
        public string TerugDate { get; set; }

        [Display(Name = "Vertrek uur terugreis")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Vul tijdstip van vertrek terugreis in.")]
        public DateTime TerugTime { get; set; }

        [Required(ErrorMessage = "Vul het aantal passagiers in.")]
        public int Aantal { get; set; }
    }
}
