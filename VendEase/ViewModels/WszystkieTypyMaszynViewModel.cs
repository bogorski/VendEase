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
    public class WszystkieTypyMaszynViewModel : WszystkieViewModel<TypyMaszyn>
    {
        #region Constructor
        public WszystkieTypyMaszynViewModel()
           : base("Typy maszyn")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Typ", "Producent", "Model", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<TypyMaszyn>(List.OrderBy(item => item.IDTypMaszyny));
            if (SortField == "Typ")
                List = new ObservableCollection<TypyMaszyn>(List.OrderBy(item => item.Typ));
            if (SortField == "Producent")
                List = new ObservableCollection<TypyMaszyn>(List.OrderBy(item => item.Producent));
            if (SortField == "Model")
                List = new ObservableCollection<TypyMaszyn>(List.OrderBy(item => item.Model));
            if (SortField == "Opis")
                List = new ObservableCollection<TypyMaszyn>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Typ", "Producent", "Model", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<TypyMaszyn>(List.Where(item => item.IDTypMaszyny != null && item.IDTypMaszyny.ToString().StartsWith(FindTextBox)));
            if (FindField == "Typ")
                List = new ObservableCollection<TypyMaszyn>(List.Where(item => item.Typ != null && item.Typ.StartsWith(FindTextBox)));
            if (FindField == "Producent")
                List = new ObservableCollection<TypyMaszyn>(List.Where(item => item.Producent != null && item.Producent.StartsWith(FindTextBox)));
            if (FindField == "Model")
                List = new ObservableCollection<TypyMaszyn>(List.Where(item => item.Model != null && item.Model.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<TypyMaszyn>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypyMaszyn>
                (
                    vendingEntities.TypyMaszyn.ToList()
                );
        }
        #endregion
    }
}
