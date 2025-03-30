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
    public class WszystkieLokalizacjeViewModel : WszystkieViewModel<Lokalizacje>
    {
        #region Constructor
        public WszystkieLokalizacjeViewModel()
           : base("Lokalizacje")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Nazwa klienta", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.IDLokalizacji));
            if (SortField == "Nazwa klienta")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.NazwaKlienta));
            if (SortField == "Ulica")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.Ulica));
            if (SortField == "Miasto")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.Miasto));
            if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.KodPocztowy));
            if (SortField == "Kraj")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.Kraj));
            if (SortField == "Opis")
                List = new ObservableCollection<Lokalizacje>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Nazwa klienta", "Ulica", "Miasto", "Kod pocztowy", "Kraj", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.IDLokalizacji != null && item.IDLokalizacji.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa klienta")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.NazwaKlienta != null && item.NazwaKlienta.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Kraj")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Lokalizacje>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Lokalizacje>
                (
                    vendingEntities.Lokalizacje.ToList()
                );
        }
        #endregion
    }
}
