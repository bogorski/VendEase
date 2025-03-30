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
    public class WszystkieMagazynyTowaryViewModel : WszystkieViewModel<MagazynTowaryForAllView>
    {
        #region Constructor
        public WszystkieMagazynyTowaryViewModel()
           : base("Stany magazynowe")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa magazynu", "Miasto magazynu", "Nazwa towaru", "Jednostka miary", "Stan", "Opis", "Data" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa magazynu")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.MagazynNazwa));
            if (SortField == "Miasto magazynu")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.MagazynMiasto));
            if (SortField == "Nazwa towaru")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.TowarNazwa));
            if (SortField == "Jednostka miary")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Stan")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.Stan));
            if (SortField == "Opis")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Data")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.OrderBy(item => item.Data));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa magazynu", "Miasto magazynu", "Nazwa towaru", "Jednostka miary", "Stan", "Opis", "Data" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa magazynu")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.MagazynNazwa != null && item.MagazynNazwa.StartsWith(FindTextBox)));
            if (FindField == "Miasto magazynu")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.MagazynMiasto != null && item.MagazynMiasto.StartsWith(FindTextBox)));
            if (FindField == "Nazwa towaru")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindTextBox)));
            if (FindField == "Jednostka miary")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Stan")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.Stan != null && item.Stan.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<MagazynTowaryForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox))); ;
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MagazynTowaryForAllView>
                (
                    from magazynTowary in vendingEntities.MagazynTowary
                    select new MagazynTowaryForAllView
                    {
                        MagazynNazwa = magazynTowary.Magazyny.Nazwa,
                        MagazynMiasto = magazynTowary.Magazyny.Miasto,
                        TowarNazwa = magazynTowary.Towary.Nazwa,
                        JednostkaMiary = magazynTowary.Towary.JednostkaMiary,
                        Stan = magazynTowary.Stan,
                        Opis = magazynTowary.Opis,
                        Data = magazynTowary.Data
                    }
                );
        }
        #endregion
    }
}
