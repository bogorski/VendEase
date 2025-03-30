using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class PracownicyB : DatabaseClass
    {
        #region Konstruktor
        public PracownicyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetPracownicyKeyAndValueItems()
        {
            return
                (
                    from pracownik in db.Pracownicy
                    select new KeyAndValue
                    {
                        Key = pracownik.IDPracownika,
                        Value = pracownik.Imie + " " + pracownik.Nazwisko
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
