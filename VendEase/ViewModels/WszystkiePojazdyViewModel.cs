using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace VendEase.ViewModels
{
    internal class WszystkiePojazdyViewModel : WszystkieViewModel<PojazdForAllView>
    {
        #region Constructor
        public WszystkiePojazdyViewModel()
           : base("Pojazdy")
        {
        }
        #endregion
        #region Properties
        private PojazdForAllView _WybranyPojazd;
        public PojazdForAllView WybranyPojazd
        {
            get
            {
                return _WybranyPojazd;
            }
            set
            {
                _WybranyPojazd = value;
                Messenger.Default.Send(_WybranyPojazd);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Marka", "Numer rejestracyjny", "Data przeglądu", "Data ubezpieczenia", "Nazwa warsztatu", "Opis", "Usterki" };
        }
        public override void Sort()
        {
            if (SortField == "Marka")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.Marka));
            if (SortField == "Numer rejestracyjny")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.NumerRejestracyjny));
            if (SortField == "Data przeglądu")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.DataPrzegladu));
            if (SortField == "Data ubezpieczenia")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.DataUbezpieczenia));
            if (SortField == "Nazwa warsztatu")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.WarsztatNazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Usterki")
                List = new ObservableCollection<PojazdForAllView>(List.OrderBy(item => item.Usterki));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Marka", "Numer rejestracyjny", "Data przeglądu", "Data ubezpieczenia", "Nazwa warsztatu", "Opis", "Usterki" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Marka")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.Marka != null && item.Marka.StartsWith(FindTextBox)));
            if (FindField == "Numer rejestracyjny")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.NumerRejestracyjny != null && item.NumerRejestracyjny.StartsWith(FindTextBox)));
            if (FindField == "Data przeglądu")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.DataPrzegladu != null && item.DataPrzegladu.ToString().StartsWith(FindTextBox)));
            if (FindField == "Data ubezpieczenia")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.DataUbezpieczenia != null && item.DataUbezpieczenia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa warsztatu")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.WarsztatNazwa != null && item.WarsztatNazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Usterki")
                List = new ObservableCollection<PojazdForAllView>(List.Where(item => item.Usterki != null && item.Usterki.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PojazdForAllView>
                (
                    from pojazd in vendingEntities.Pojazdy
                    select new PojazdForAllView
                    {
                        Marka = pojazd.Marka,
                        NumerRejestracyjny = pojazd.NumerRejestracyjny,
                        DataPrzegladu = pojazd.DataPrzegladu,
                        DataUbezpieczenia = pojazd.DataUbezpieczenia,
                        WarsztatNazwa = pojazd.Warsztaty.Nazwa,
                        Opis = pojazd.Opis,
                        Usterki = pojazd.Usterki
                    }
                );
        }
        #endregion
    }
}
