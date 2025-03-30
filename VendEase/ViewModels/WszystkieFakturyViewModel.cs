using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using GalaSoft.MvvmLight.Messaging;
using VendEase.Models.EntitiesForView;

namespace VendEase.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<Faktury>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
           : base("Faktury")
        {
        }
        #endregion
        #region Properties
        private Faktury _WybranaFaktura;
        public Faktury WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }
            set
            {
                _WybranaFaktura = value;
                Messenger.Default.Send(_WybranaFaktura);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "NIP", "Nazwa sprzedawcy", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Wartość netto", "Wartość brutto", "VAT", "Data wystawienia", "Numer faktury" };
        }
        public override void Sort()
        {
            if (SortField == "NIP")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.NIP));
            if (SortField == "Nazwa sprzedawcy")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.NazwaSprzedawcy));
            if (SortField == "Ulica")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.Ulica));
            if (SortField == "Miasto")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.Miasto));
            if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "Kraj")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.Kraj));
            if (SortField == "Wartość netto")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.WartoscNetto));
            if (SortField == "Wartość brutto")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.WartoscBrutto));
            if (SortField == "VAT")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.VAT));
            if (SortField == "Data wystawienia")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.DataWystawienia));
            if (SortField == "Numer faktury")
                List = new ObservableCollection<Faktury>(List.OrderBy(item => item.NumerFaktury));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "NIP", "Nazwa sprzedawcy", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Wartość netto", "Wartość brutto", "VAT", "Data wystawienia", "Numer faktury" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "NIP")
                List = new ObservableCollection<Faktury>(List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
            if (FindField == "Nazwa sprzedawcy")
                List = new ObservableCollection<Faktury>(List.Where(item => item.NazwaSprzedawcy != null && item.NazwaSprzedawcy.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<Faktury>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<Faktury>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<Faktury>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Kraj")
                List = new ObservableCollection<Faktury>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            if (FindField == "Wartość netto")
                List = new ObservableCollection<Faktury>(List.Where(item => item.WartoscNetto != null && item.WartoscNetto.ToString().StartsWith(FindTextBox)));
            if (FindField == "Wartość brutto")
                List = new ObservableCollection<Faktury>(List.Where(item => item.WartoscBrutto != null && item.WartoscBrutto.ToString().StartsWith(FindTextBox)));
            if (FindField == "VAT")
                List = new ObservableCollection<Faktury>(List.Where(item => item.VAT != null && item.VAT.ToString().StartsWith(FindTextBox)));
            if (FindField == "Data wystawienia")
                List = new ObservableCollection<Faktury>(List.Where(item => item.DataWystawienia != null && item.DataWystawienia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Numer faktury")
                List = new ObservableCollection<Faktury>(List.Where(item => item.NumerFaktury != null && item.NumerFaktury.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Faktury>
                (
                    vendingEntities.Faktury.ToList()
                );
        }
        #endregion
    }
}
