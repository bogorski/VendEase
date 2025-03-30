using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using VendEase.Helper;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    internal class NowyPojazdViewModel : JedenViewModel<Pojazdy>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyPojazdViewModel()
            : base("Pojazd")
        {
            item = new Pojazdy();
            DataPrzegladu = DateTime.Now;
            DataUbezpieczenia = DateTime.Now;
            Messenger.Default.Register<Warsztaty>(this, getWybranyWarsztat);
        }
        #endregion
        #region Command
        private BaseCommand _ShowWarsztaty;

        public ICommand ShowWarsztaty
        {
            get
            {
                if (_ShowWarsztaty == null)
                    _ShowWarsztaty = new BaseCommand(() => showWarsztaty());
                return _ShowWarsztaty;
            }
        }

        private void showWarsztaty()
        {
            Messenger.Default.Send<string>("WarsztatyAll");
        }
        #endregion
        #region Properties
        public string Marka
        {
            get
            {
                return item.Marka;
            }
            set
            {
                item.Marka = value;
                OnPropertyChanged(() => Marka);
            }
        }
        public string NumerRejestracyjny
        {
            get
            {
                return item.NumerRejestracyjny;
            }
            set
            {
                item.NumerRejestracyjny = value;
                OnPropertyChanged(() => NumerRejestracyjny);
            }
        }
        public DateTime DataPrzegladu
        {
            get
            {
                return item.DataPrzegladu;
            }
            set
            {
                item.DataPrzegladu = value;
                OnPropertyChanged(() => DataPrzegladu);
            }
        }
        public DateTime DataUbezpieczenia
        {
            get
            {
                return item.DataUbezpieczenia;
            }
            set
            {
                item.DataUbezpieczenia = value;
                OnPropertyChanged(() => DataUbezpieczenia);
            }
        }
        public int? IDWarsztatu
        {
            get
            {
                return item.IDWarsztatu;
            }
            set
            {
                item.IDWarsztatu = value;
                OnPropertyChanged(() => IDWarsztatu);
            }
        }
        public string NazwaWarsztatu { get; set; }
        public string MiastoWarsztatu { get; set; }
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
        public string Usterki
        {
            get
            {
                return item.Usterki;
            }
            set
            {
                item.Usterki = value;
                OnPropertyChanged(() => Usterki);
            }
        }
        #endregion
        #region Helpers
        private void getWybranyWarsztat(Warsztaty warsztaty)
        {
            IDWarsztatu = warsztaty.IDWarsztatu;
            NazwaWarsztatu = warsztaty.Nazwa;
            MiastoWarsztatu = warsztaty.Miasto;
        }
        public override void Save()
        {
            vendingEntities.Pojazdy.Add(item);
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
                if (name == "NumerRejestracyjny")
                    komunikat = RegistrationNumberValidator.SprawdzNumerRejestracyjny(this.NumerRejestracyjny);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NumerRejestracyjny"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
