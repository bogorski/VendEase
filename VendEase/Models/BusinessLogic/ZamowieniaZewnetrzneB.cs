using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class ZamowieniaZewnetrzneB : DatabaseClass
    {
        #region Konstruktor
        public ZamowieniaZewnetrzneB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public IQueryable<KeyAndValue> GetZamowieniaZewnetrzneKeyAndValueItems()
        {
            return
                (
                    from zamowieniaZewnetrzne in db.ZamowieniaZewnetrzne
                    select new KeyAndValue
                    {
                        Key = zamowieniaZewnetrzne.IDZamowienieZewnetrzne,
                        Value = zamowieniaZewnetrzne.IDZamowienieZewnetrzne.ToString()
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
