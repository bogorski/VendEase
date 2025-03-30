using VendEase.Models.Entities;
using VendEase.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towary>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyTowarViewModel()
            : base("Towar")
        {
            item = new Towary();
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public string JednostkaMiary
        {
            get
            {
                return item.JednostkaMiary;
            }
            set
            {
                item.JednostkaMiary = value;
                OnPropertyChanged(() => JednostkaMiary);
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
        public string KodKreskowy
        {
            get
            {
                return item.KodKreskowy;
            }
            set
            {
                item.KodKreskowy = value;
                OnPropertyChanged(() => KodKreskowy);
            }
        }
        public string Wymiary
        {
            get
            {
                return item.Wymiary;
            }
            set
            {
                item.Wymiary = value;
                OnPropertyChanged(() => Wymiary);
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
            vendingEntities.Towary.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
        #region Validation
        public string Error
        {
            get { return null; }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Nazwa")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                if (name == "KodKreskowy")
                    komunikat = PostCodeValidator.SprawdzCzyPoprawnyKodPocztowy(this.KodKreskowy);
                return komunikat;
            }
        }
        //ta funkcja sprawdza czy wszystkie dane sa poprawne przed zapisem
        public override bool IsValid()
        {
            if (this["Nazwa"]==null && this["KodKreskowy"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
