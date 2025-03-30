using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class DostawcyB : DatabaseClass
    {
        #region Konstruktor
        public DostawcyB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetDostawcyKeyAndValueItems()
        {
            return
                (
                    from dostawca in db.Dostawcy
                    select new KeyAndValue
                    {
                        Key = dostawca.IDDostawcy,
                        Value = dostawca.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
