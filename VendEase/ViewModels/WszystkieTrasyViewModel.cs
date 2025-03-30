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
    public class WszystkieTrasyViewModel : WszystkieViewModel<Trasy>
    {
        #region Constructor
        public WszystkieTrasyViewModel()
           : base("Trasy")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Nazwa", "Data utowrzenia", "Opis", "Ocena" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<Trasy>(List.OrderBy(item => item.IDTrasy));
            if (SortField == "Nazwa")
                List = new ObservableCollection<Trasy>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Data utowrzenia")
                List = new ObservableCollection<Trasy>(List.OrderBy(item => item.DataUtworzenia));
            if (SortField == "Opis")
                List = new ObservableCollection<Trasy>(List.OrderBy(item => item.Opis));
            if (SortField == "Ocena")
                List = new ObservableCollection<Trasy>(List.OrderBy(item => item.Ocena));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Nazwa", "Data utowrzenia", "Opis", "Ocena" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<Trasy>(List.Where(item => item.IDTrasy != null && item.IDTrasy.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa")
                List = new ObservableCollection<Trasy>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Data utowrzenia")
                List = new ObservableCollection<Trasy>(List.Where(item => item.DataUtworzenia != null && item.DataUtworzenia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Trasy>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Ocena")
                List = new ObservableCollection<Trasy>(List.Where(item => item.Ocena != null && item.Ocena.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Trasy>
                (
                    vendingEntities.Trasy.ToList()
                );
        }
        #endregion
    }
}
