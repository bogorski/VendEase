using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class MaszynyB : DatabaseClass
    {
        #region Konstruktor
        public MaszynyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValueString> GetMaszynyKeyAndValueItems()
        {
            return
                (
                    from maszyna in db.Maszyny
                    select new KeyAndValueString
                    {
                        Key = maszyna.NumerMaszyny,
                        Value = maszyna.NumerMaszyny
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
