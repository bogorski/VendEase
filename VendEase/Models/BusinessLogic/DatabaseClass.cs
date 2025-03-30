using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Contex
        public VendingEntities db {  get; set; }
        #endregion

        #region Konstruktor
        public DatabaseClass(VendingEntities db)
        {
            this.db = db;
        }
        #endregion
    }
}
