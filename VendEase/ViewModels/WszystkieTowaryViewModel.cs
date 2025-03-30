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
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towary>
    {
        #region Constructor
        public WszystkieTowaryViewModel()
           : base("Towary")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Nazwa", "Jednostka miary", "Producent", "Kod kreskowy", "Wymiary", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.IDTowaru));
            if (SortField == "Nazwa")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Jednostka miary")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Producent")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Producent));
            if (SortField == "Kod kreskowy")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.KodKreskowy));
            if (SortField == "Wymiary")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Wymiary));
            if (SortField == "Opis")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Nazwa", "Jednostka miary", "Producent", "Kod kreskowy", "Wymiary", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<Towary>(List.Where(item => item.IDTowaru != null && item.IDTowaru.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<Towary>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Jednostka miary")
                List = new ObservableCollection<Towary>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Producent")
                List = new ObservableCollection<Towary>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "Kod kreskowy")
                List = new ObservableCollection<Towary>(List.Where(item => item.KodKreskowy != null && item.KodKreskowy.StartsWith(FindTextBox)));
            if (FindField == "Wymiary")
                List = new ObservableCollection<Towary>(List.Where(item => item.Wymiary != null && item.Wymiary.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Towary>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Towary>
                (
                    vendingEntities.Towary.ToList()
                );
        }
        #endregion
    }
}
