using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace VendEase.ViewModels
{
     public class WszystkieMagazynyViewModel : WszystkieViewModel<Magazyny>
     {
        #region Constructor
        public WszystkieMagazynyViewModel()
           : base("Magazyny")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Ulica")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.Ulica));
            if (SortField == "Miasto")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.Miasto));
            if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "Kraj")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.Kraj));
            if (SortField == "Opis")
                List = new ObservableCollection<Magazyny>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Kraj")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Magazyny>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Magazyny>
                (
                    vendingEntities.Magazyny.ToList()
                );
        }
        #endregion
     }
}
