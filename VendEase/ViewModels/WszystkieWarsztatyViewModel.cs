using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VendEase.Models.EntitiesForView;

namespace VendEase.ViewModels
{
    public class WszystkieWarsztatyViewModel : WszystkieViewModel<Warsztaty>
    {
        #region Constructor
        public WszystkieWarsztatyViewModel()
           : base("Warsztaty")
        {
        }
        #endregion
        #region Properties
        private Warsztaty _WybranyWarsztat;
        public Warsztaty WybranyWarsztat
        {
            get
            {
                return _WybranyWarsztat;
            }
            set
            {
                _WybranyWarsztat = value;
                Messenger.Default.Send(_WybranyWarsztat);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Nazwa", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.IDWarsztatu));
            if (SortField == "Nazwa")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Ulica")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.Ulica));
            if (SortField == "Miasto")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.Miasto));
            if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "Kraj")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.Kraj));
            if (SortField == "Opis")
                List = new ObservableCollection<Warsztaty>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Nazwa", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.IDWarsztatu != null && item.IDWarsztatu.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Kraj")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Warsztaty>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Warsztaty>
                (
                    vendingEntities.Warsztaty.ToList()
                );
        }
        #endregion
    }
}
