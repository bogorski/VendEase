using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TowaryB : DatabaseClass
    {
        #region Konstruktor
        public TowaryB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetTowaryKeyAndValueItems()
        {
            return
                (
                    from towar in db.Towary
                    select new KeyAndValue
                    {
                        Key = towar.IDTowaru,
                        Value = towar.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
