using VendEase.Helper;
using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    public class NowyWarsztatViewModel : JedenViewModel<Warsztaty>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyWarsztatViewModel()
            :base("Warsztat")
        {
            item = new Warsztaty();
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
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                item.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                item.Kraj = value;
                OnPropertyChanged(() => Kraj);
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
            vendingEntities.Warsztaty.Add(item);
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
                if (name == "KodPocztowy")
                    komunikat = PostCodeValidator.SprawdzCzyPoprawnyKodPocztowy(this.KodPocztowy);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["KodPocztowy"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
