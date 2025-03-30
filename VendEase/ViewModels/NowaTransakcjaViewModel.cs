using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    public class NowaTransakcjaViewModel : JedenViewModel<Transakcje>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaTransakcjaViewModel()
            : base("Transakcje")
        {
            item = new Transakcje();
            Data = DateTime.Now;
        }
        #endregion
        #region Properties
        public string NumerMaszyny
        {
            get
            {
                return item.NumerMaszyny;
            }
            set
            {
                item.NumerMaszyny = value;
                OnPropertyChanged(() => NumerMaszyny);
            }
        }
        public int IDTowaru
        {
            get
            {
                return item.IDTowaru;
            }
            set
            {
                item.IDTowaru = value;
                OnPropertyChanged(() => IDTowaru);
            }
        }
        public int Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }
        public string TypPlatnosci
        {
            get
            {
                return item.TypPlatnosci;
            }
            set
            {
                item.TypPlatnosci = value;
                OnPropertyChanged(() => TypPlatnosci);
            }
        }
        public DateTime Data
        {
            get
            {
                return item.Data;
            }
            set
            {
                item.Data = value;
                OnPropertyChanged(() => Data);
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
        #region Propertis ComboBox
        public IQueryable<KeyAndValueString> MaszynyItems
        {
            get
            {
                return new MaszynyB(vendingEntities).GetMaszynyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowaryB(vendingEntities).GetTowaryKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Transakcje.Add(item);
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
                if (name == "Ilosc")
                    komunikat = QuantityValidator.SprawdzCzyPowyzejZera(this.Ilosc);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Ilosc"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
