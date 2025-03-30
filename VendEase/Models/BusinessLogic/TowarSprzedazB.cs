using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TowarSprzedazB : DatabaseClass
    {
        #region Konstruktor
        public TowarSprzedazB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public string NajlepiejSprzedajacyTowar(string numerMaszyny, DateTime dataOd, DateTime dataDo)
        {
            var towarySprzedane =
                from pozycja in db.Transakcje
                where
                    pozycja.NumerMaszyny == numerMaszyny &&
                    pozycja.Data >= dataOd &&
                    pozycja.Data <= dataDo
                group pozycja by new { pozycja.Towary.Nazwa } into grupowaneTowary
                select new
                {
                    Towar = grupowaneTowary.Key.Nazwa,
                    SumaSprzedanych = grupowaneTowary.Sum(p => p.Ilosc)
                };


            if (towarySprzedane.Any())
            {
                var maksymalnaSprzedaz = towarySprzedane.Max(t => t.SumaSprzedanych);

                var towaryZNajwiekszaSprzedaza =
                    towarySprzedane
                    .Where(t => t.SumaSprzedanych == maksymalnaSprzedaz)
                    .ToList();
                StringBuilder wynik = new StringBuilder();
                foreach (var pozycja in towaryZNajwiekszaSprzedaza)
                {
                    wynik.AppendLine($"Towar: {pozycja.Towar}, Ilość: {pozycja.SumaSprzedanych}");
                }
                return wynik.ToString();
            }
            else
            {
                return "brak danych";
            }
        }
        #endregion
    }
}
