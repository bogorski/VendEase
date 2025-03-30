using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TrasyB : DatabaseClass
    {
        #region Konstruktor
        public TrasyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetTrasyKeyAndValueItems()
        {
            return
                (
                    from trasa in db.Trasy
                    select new KeyAndValue
                    {
                        Key = trasa.IDTrasy,
                        Value = trasa.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
