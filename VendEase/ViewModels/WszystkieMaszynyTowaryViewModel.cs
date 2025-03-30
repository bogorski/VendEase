using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Entities;

namespace VendEase.ViewModels
{
    internal class WszystkieMaszynyTowaryViewModel : WszystkieViewModel<MaszynaTowarForAllView>
    {
        #region Constructor
        public WszystkieMaszynyTowaryViewModel()
           : base("Towary w maszynach")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer maszyny", "Nazwa towaru", "Stan", "Jednostka miary", "Opis", "Data" };
        }
        public override void Sort()
        {
            if (SortField == "Numer maszyny")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.MaszynyNumerMaszyny));
            if (SortField == "Nazwa towaru")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.TowarNazwa));
            if (SortField == "Stan")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.Stan));
            if (SortField == "Jednostka miary")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Opis")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Data")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.OrderBy(item => item.Data));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer maszyny", "Nazwa towaru", "Stan", "Jednostka miary", "Opis", "Data" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Numer maszyny")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.MaszynyNumerMaszyny != null && item.MaszynyNumerMaszyny.StartsWith(FindTextBox)));
            if (FindField == "Nazwa towaru")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindTextBox)));
            if (FindField == "Stan")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.Stan != null && item.Stan.ToString().StartsWith(FindTextBox)));
            if (FindField == "Jednostka miary")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<MaszynaTowarForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MaszynaTowarForAllView>
                (
                    from maszynaTowary in vendingEntities.MaszynaTowary
                    select new MaszynaTowarForAllView
                    {
                        MaszynyNumerMaszyny = maszynaTowary.Maszyny.NumerMaszyny,
                        TowarNazwa = maszynaTowary.Towary.Nazwa,
                        JednostkaMiary = maszynaTowary.Towary.JednostkaMiary,
                        Stan = maszynaTowary.Stan,
                        Opis = maszynaTowary.Opis,
                        Data = maszynaTowary.Data
                    }
                );
        }
        #endregion
    }
}
