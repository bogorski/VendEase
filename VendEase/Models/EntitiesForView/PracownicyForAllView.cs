using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Entities;

namespace VendEase.Models.EntitiesForView
{
    public class PracownicyForAllView
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string StanowiskoNazwa { get; set; }
        public string StanowiskoDzial { get; set; }
        public int StanowiskoWymaganeDoswiadczenie { get; set; }
        public string StanowiskoStatus { get; set; }
        public string StanowiskoOpis { get; set; }
        public DateTime StanowiskoDataUtowrzenia { get; set; }
        public decimal Pensja { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public string PojazdNumerRejestracyjny { get; set; }
        public string PojazdMarka { get; set; }
        public DateTime PojazdDataPrzegladu { get; set; }
        public DateTime PojazdDataUbezpieczenia { get; set; }
        public string PojazdWarsztatNazwa { get; set; }
        public string PojazdWarsztatUlica { get; set; }
        public string PojazdWarsztatMiasto { get; set; }
        public string PojazdWarsztatKodPocztowy { get; set; }
        public string PojazdWarsztatKraj { get; set; }
        public string PojazdWarsztatOpis { get; set; }
        public string PojazdOpis { get; set; }
        public string PojazdUsterki { get; set; }
        public string TrasaNazwa { get; set; }
        public string Opis { get; set; }
        public List<Maszyny> NumeryMaszynList { get; set; }
        public List<Lokalizacje> LokalizacjeList { get; set; }
    }
}
