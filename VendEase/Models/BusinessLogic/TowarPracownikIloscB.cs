using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TowarPracownikIloscB : DatabaseClass
    {
        #region Konstruktor
        public TowarPracownikIloscB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public string IloscTowarPracownik(int IDTowaru, int iloscOd, int iloscDo)
        {
            var stanTowaru =
               from pozycja in db.PracownikTowary
               where
               pozycja.IDTowaru == IDTowaru &&
               pozycja.Stan >= iloscOd &&
               pozycja.Stan <= iloscDo
               select new { pozycja.Stan, pozycja.Pracownicy.Imie, pozycja.Pracownicy.Nazwisko };

            if (stanTowaru.Any())
            {
                StringBuilder wynik = new StringBuilder();
                foreach (var pozycja in stanTowaru)
                {
                    wynik.AppendLine($"Pracownik: {pozycja.Imie} {pozycja.Nazwisko}, Ilość: {pozycja.Stan}");
                }
                return wynik.ToString();
            }
            else
            {
                return "brak";
            }
        }
        #endregion
    }
}
