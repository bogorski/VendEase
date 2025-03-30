using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class TransakcjeMaszynyTowarB : DatabaseClass
    {
        #region Konstruktor
        public TransakcjeMaszynyTowarB(VendingEntities db)
            : base(db) { }
        #endregion
        #region Funkcje biznesowe
        public int TransakcjeOkresMaszynaTowar(string NumerMaszyny, int IDTowaru, DateTime dataOd, DateTime dataDo)
        {
            var transakcje =
                from pozycja in db.Transakcje
                where
                pozycja.NumerMaszyny == NumerMaszyny &&
                pozycja.IDTowaru == IDTowaru &&
                pozycja.Data >= dataOd &&
                pozycja.Data <= dataDo
                select pozycja.Ilosc;

            if (transakcje.Any())
            {
                return transakcje.Sum();
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
