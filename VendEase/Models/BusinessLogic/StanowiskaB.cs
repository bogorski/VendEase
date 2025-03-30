using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class StanowiskaB : DatabaseClass
    {
        #region Konstruktor
        public StanowiskaB(VendingEntities db)
            :base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetStanowiskaKeyAndValueItems()
        {
            return
                (
                    from stanowisko in db.StanowiskaPracy
                    select new KeyAndValue
                    {
                        Key = stanowisko.IDStanowiskaPracy,
                        Value = stanowisko.NazwaStanowiska
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
