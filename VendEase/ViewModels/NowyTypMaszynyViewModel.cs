using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class NowyTypMaszynyViewModel : JedenViewModel<TypyMaszyn>
    {
        #region Konstruktor
        public NowyTypMaszynyViewModel()
            : base("Typ maszyny")
        {
            item = new TypyMaszyn();
        }
        #endregion
        #region Properties
        public string Typ
        {
            get
            {
                return item.Typ;
            }
            set
            {
                item.Typ = value;
                OnPropertyChanged(() => Typ);
            }
        }
        public string Producent
        {
            get
            {
                return item.Producent;
            }
            set
            {
                item.Producent = value;
                OnPropertyChanged(() => Producent);
            }
        }
        public string Model
        {
            get
            {
                return item.Model;
            }
            set
            {
                item.Model = value;
                OnPropertyChanged(() => Model);
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.TypyMaszyn.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
