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
    public class WszystkieTransakcjeViewModel : WszystkieViewModel<TransakcjeForAllView>
    {
        #region Constructor
        public WszystkieTransakcjeViewModel()
           : base("Transakcje")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer maszyny", "Nazwa towaru", "Ilość", "Jednostka miary", "Typ płatności", "Data", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Numer maszyny")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.NumerMaszyny));
            if (SortField == "Nazwa towaru")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.TowarNazwa));
            if (SortField == "Ilość")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.Ilosc));
            if (SortField == "Jednostka miary")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Typ płatności")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.TypPlatnosci));
            if (SortField == "Data")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.Data));
            if (SortField == "Opis")
                List = new ObservableCollection<TransakcjeForAllView>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer maszyny", "Nazwa towaru", "Ilość", "Jednostka miary", "Typ płatności", "Data", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Numer maszyny")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.NumerMaszyny != null && item.NumerMaszyny.StartsWith(FindTextBox)));
            if (FindField == "Nazwa towaru")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindTextBox)));
            if (FindField == "Ilość")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.Ilosc != null && item.Ilosc.ToString().StartsWith(FindTextBox)));
            if (FindField == "Jednostka miary")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Typ płatności")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.TypPlatnosci != null && item.TypPlatnosci.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<TransakcjeForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TransakcjeForAllView>
                (
                    from transakcje in vendingEntities.Transakcje
                    select new TransakcjeForAllView
                    {
                        NumerMaszyny = transakcje.Maszyny.NumerMaszyny,
                        TowarNazwa = transakcje.Towary.Nazwa,
                        Ilosc = transakcje.Ilosc,
                        JednostkaMiary = transakcje.Towary.JednostkaMiary,
                        TypPlatnosci = transakcje.TypPlatnosci,
                        Data = transakcje.Data,
                        Opis = transakcje.Opis
                    }
                );
        }
        #endregion
    }
}
