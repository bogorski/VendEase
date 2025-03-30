using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class MagazynyB : DatabaseClass
    {
        #region Konstruktor
        public MagazynyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetMagazynyKeyAndValueItems()
        {
            return
                (
                    from magazyn in db.Magazyny
                    select new KeyAndValue
                    {
                        Key = magazyn.IDMagazynu,
                        Value = magazyn.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
