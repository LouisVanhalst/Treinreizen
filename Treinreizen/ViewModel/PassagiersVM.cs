using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treinreizen.ViewModel
{
    public class PassagierslijstVM
    {
        public List<PassagierVM> passagiers { get; set; }
    }

    public class PassagierVM
    {

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    }
}
