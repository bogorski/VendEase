using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class PracownikTowaryForAllView
    {
        public string PracownikImie { get; set; }
        public string PracownikNazwisko { get; set; }
        public string TowarNazwa { get; set; }
        public int Stan { get; set; }
        public string JednostkaMiary { get; set; }
        public string Opis { get; set; }
        public DateTime? Data { get; set; }
    }
}
