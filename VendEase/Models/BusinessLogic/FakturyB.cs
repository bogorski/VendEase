using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class FakturyB : DatabaseClass
    {
        #region Konstruktor
        public FakturyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetFakturyKeyAndValueItems()
        {
            return
                (
                    from faktura in db.Faktury
                    select new KeyAndValue
                    {
                        Key = faktura.IDFaktury,
                        Value = faktura.NumerFaktury
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
