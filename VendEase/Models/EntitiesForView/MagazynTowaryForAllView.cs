using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class MagazynTowaryForAllView
    {
        public string MagazynNazwa { get; set; }
        public string MagazynMiasto { get; set; }
        public string TowarNazwa { get; set; }
        public int Stan { get; set; }
        public string JednostkaMiary { get; set; }
        public string Opis { get; set; }
        public DateTime? Data { get; set; }
    }
}
