using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class TransakcjeForAllView
    {
        public string NumerMaszyny { get; set; }
        public string TowarNazwa { get; set; }
        public int Ilosc { get; set; }
        public string JednostkaMiary { get; set; }
        public string TypPlatnosci { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
    }
}
