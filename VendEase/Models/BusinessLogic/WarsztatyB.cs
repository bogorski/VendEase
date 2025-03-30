using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    internal class WarsztatyB : DatabaseClass
    {
        #region Konstruktor
        public WarsztatyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetWarsztatyKeyAndValueItems()
        {
            return
                (
                    from warsztat in db.Warsztaty
                    select new KeyAndValue
                    {
                        Key = warsztat.IDWarsztatu,
                        Value = warsztat.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
