using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Treinreizen.ViewModel
{
    public class PassagierslijstVM
    {
        public List<PassagierVM> Passagiers { get; set; }
    }

    public class PassagierVM
    {
        [Required (ErrorMessage = "Gelieve de voornaam van de passagier in te vullen")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Gelieve de achternaam van de passagier in te vullen")]
        public string Achternaam { get; set; }
    }
}
