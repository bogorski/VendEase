using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class PojazdyB : DatabaseClass
    {
        #region Konstruktor
        public PojazdyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetPojazdyKeyAndValueItems()
        {
            return
                (
                    from pojazd in db.Pojazdy
                    select new KeyAndValue
                    {
                        Key = pojazd.IDPojazdu,
                        Value = pojazd.NumerRejestracyjny
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
