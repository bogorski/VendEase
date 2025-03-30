using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class WizytyForAllView
    {
        public string PracownikImie { get; set; }
        public string PracownikNazwisko { get; set; }
        public string MaszynyNumerMaszyny { get; set; }
        public DateTime? Data { get; set; }
        public string TypWizyty{ get; set; }
        public string Opis { get; set; }
    }
}
