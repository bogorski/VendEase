using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Entities;

namespace VendEase.Models.EntitiesForView
{
    public class MaszynyForAllView
    {
        public string NumerMaszyny { get; set; }
        public string MaszynyTypMaszynny { get; set; }
        public string NumerSeryjny { get; set; }
        public DateTime RokProdukcji { get; set; }
        public string Opis { get; set; }
        public DateTime? DataMontazu { get; set; }
        public string LokalizacjaNazwaKlienta { get; set; }
        public string LokalizacjaUlica { get; set; }
        public string LokalizacjaMiasto { get; set; }
        public List<Lokalizacje> LokalizacjeList { get; set; }
        public List<TowarMaszynaStan> TowaryList { get; set; }
        public List<TowarMaszynaStan> TowaryNiskiStan { get; set; }

    }
}
