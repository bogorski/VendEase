using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class DostawaTowaryForAllView
    {
        public string TowarNazwa { get; set; }
        public int IDZamowieniaZewnetrzne { get; set; }
        public int Ilosc { get; set; }
        public string JednostkaMiary { get; set; }  
        public string Opis { get; set; }
        public DateTime? DataWaznosci { get; set; }
    }
}
