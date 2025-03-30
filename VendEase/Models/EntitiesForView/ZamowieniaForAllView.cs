using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.EntitiesForView
{
    public class ZamowieniaForAllView
    {
        public string MagazynNazwa { get; set; }
        public string MagazynMiasto { get; set; }
        public string PracownikImie { get; set; }
        public string PracownikNazwisko { get; set; }
        public DateTime? Data { get; set; }
        public string Priorytet { get; set; }
        public string Opis { get; set; }
    }
}
