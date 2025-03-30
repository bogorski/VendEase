using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendEase.Helper;
using VendEase.Models.Entities;
using GalaSoft.MvvmLight.Messaging;

namespace VendEase.ViewModels
{
    public class WszystkieDostawyTowaryViewModel : WszystkieViewModel<DostawaTowaryForAllView>
    {
        #region Constructor
        public WszystkieDostawyTowaryViewModel()
           : base("Dostawy")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa towaru", "Numer zamówienia", "Ilość", "Jednostka miary", "Opis", "Data ważności" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa towaru")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.TowarNazwa));
            if (SortField == "Numer zamówienia")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.IDZamowieniaZewnetrzne));
            if (SortField == "Ilość")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.Ilosc));
            if (SortField == "Jednostka miary")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Opis")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Data ważności")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.OrderBy(item => item.DataWaznosci));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa towaru", "Numer zamówienia", "Ilość", "Jednostka miary", "Opis", "Data ważności" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa towaru")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindTextBox)));
            if (FindField == "Numer zamówienia")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.IDZamowieniaZewnetrzne != null && item.IDZamowieniaZewnetrzne.ToString().StartsWith(FindTextBox)));
            if (FindField == "Ilość")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.Ilosc != null && item.Ilosc.ToString().StartsWith(FindTextBox)));
            if (FindField == "Jednostka miary")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data ważności")
                List = new ObservableCollection<DostawaTowaryForAllView>(List.Where(item => item.DataWaznosci != null && item.DataWaznosci.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<DostawaTowaryForAllView>
                (
                    from dostawaTowary in vendingEntities.DostawaTowary
                    select new DostawaTowaryForAllView
                    {
                        TowarNazwa = dostawaTowary.Towary.Nazwa,
                        IDZamowieniaZewnetrzne = dostawaTowary.ZamowieniaZewnetrzne.IDZamowienieZewnetrzne,
                        Ilosc = dostawaTowary.Ilosc,
                        JednostkaMiary = dostawaTowary.Towary.JednostkaMiary,
                        Opis = dostawaTowary.Opis,
                        DataWaznosci = dostawaTowary.DataWaznosci
                    }
                );
        }
        #endregion
    }
}
