using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class PojazdForAllView
    {
        public int IDPojazdu { get; set; }
        public string Marka { get; set; }
        public string NumerRejestracyjny { get; set; }
        public DateTime DataPrzegladu { get; set; }
        public DateTime DataUbezpieczenia { get; set; }
        public string WarsztatNazwa { get; set; }
        public string Opis { get; set; }
        public string Usterki { get; set; }
    }
}
