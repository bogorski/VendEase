using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class UtargB : DatabaseClass
    {
        #region Konstruktor
        public UtargB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public decimal UtargOkresTowar(string NumerMaszyny, int IDTowaru, DateTime dataOd, DateTime dataDo) 
        {
            return
                (
                from pozycja in db.MaszynaTowary
                where
                pozycja.NumerMaszyny == NumerMaszyny &&
                pozycja.Data >= dataOd &&
                pozycja.Data <= dataDo
                select pozycja.Stan     
                ).Sum();
        }
        #endregion
    }
}
