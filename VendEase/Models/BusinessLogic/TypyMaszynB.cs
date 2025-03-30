using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TypyMaszynB : DatabaseClass
    {
        #region Konstruktor
        public TypyMaszynB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetTypyMaszynKeyAndValueItems()
        {
            return
                (
                    from typyMaszyn in db.TypyMaszyn
                    select new KeyAndValue
                    {
                        Key = typyMaszyn.IDTypMaszyny,
                        Value = typyMaszyn.Model
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
