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
using VendEase.Models.Validators;
using System.ComponentModel;

namespace VendEase.ViewModels
{
    public class NowyPracownikViewModel : JedenViewModel<Pracownicy>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyPracownikViewModel()
            : base("Pracownik")
        {
            item = new Pracownicy();
            DataZatrudnienia = DateTime.Now;
            Messenger.Default.Register<PojazdForAllView>(this, getWybranyPojazd);
        }
        #endregion
        #region Command
        private BaseCommand _ShowPojazdy;

        public ICommand ShowPojazdy
        {
            get
            {
                if (_ShowPojazdy == null)
                    _ShowPojazdy = new BaseCommand(() => showPojazdy());
                return _ShowPojazdy;
            }
        }

        private void showPojazdy()
        {
            Messenger.Default.Send<string>("PojazdyAll");
        }
        #endregion
        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                item.Imie = value;
                OnPropertyChanged(() => Imie);
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                item.Nazwisko = value;
                OnPropertyChanged(() => Nazwisko);
            }
        }
        public int IDStanowiskaPracy
        {
            get
            {
                return item.IDStanowiskaPracy;
            }
            set
            {
                item.IDStanowiskaPracy = value;
                OnPropertyChanged(() => IDStanowiskaPracy);
            }
        }
        public decimal Pensja
        {
            get
            {
                return item.Pensja;
            }
            set
            {
                item.Pensja = value;
                OnPropertyChanged(() => Pensja);
            }
        }
        public DateTime DataZatrudnienia
        {
            get
            {
                return item.DataZatrudnienia;
            }
            set
            {
                item.DataZatrudnienia = value;
                OnPropertyChanged(() => DataZatrudnienia);
            }
        }
        public int? IDPojazdu
        {
            get
            {
                return item.IDPojazdu;
            }
            set
            {
                item.IDPojazdu = value;
                OnPropertyChanged(() => IDPojazdu);
            }
        }
        public string NumerRejestracyjny { get; set; }
        public string Marka { get; set; }
        public int? IDTrasy
        {
            get
            {
                return item.IDTrasy;
            }
            set
            {
                item.IDTrasy = value;
                OnPropertyChanged(() => IDTrasy);
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
        public IQueryable<KeyAndValue> StanowiskaItems
        {
            get
            {
                return new StanowiskaB(vendingEntities).GetStanowiskaKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> TrasyItems
        {
            get
            {
                return new TrasyB(vendingEntities).GetTrasyKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        private void getWybranyPojazd(PojazdForAllView pojazd)
        {
            IDPojazdu = pojazd.IDPojazdu;
            NumerRejestracyjny = pojazd.NumerRejestracyjny;
            Marka = pojazd.Marka;
        }
        public override void Save()
        {
            vendingEntities.Pracownicy.Add(item);
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
                if (name == "Pensja")
                    komunikat = QuantityValidator.SprawdzCzyPowyzejZera(this.Pensja);
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["Pensja"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
