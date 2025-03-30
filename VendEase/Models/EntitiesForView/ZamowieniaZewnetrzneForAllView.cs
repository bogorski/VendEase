using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class ZamowieniaZewnetrzneForAllView
    {
        public int NumerZamowieniaZewnetrznego { get; set; }
        public string MagazynNazwa { get; set; }
        public string MagazynMiasto { get; set; }
        public string DostawcaNazwa { get; set; }
        public string FakturaNumerFaktury { get; set; }
        public DateTime? Data { get; set; }
        public string Opis { get; set; }
    }
}
