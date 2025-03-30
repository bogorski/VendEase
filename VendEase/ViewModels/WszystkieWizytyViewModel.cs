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
    public class WszystkieWizytyViewModel : WszystkieViewModel<WizytyForAllView>
    {
        #region Constructor
        public WszystkieWizytyViewModel()
           : base("Wizyty")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Numer maszyny", "Data", "Typ wizyty", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.PracownikImie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.PracownikNazwisko));
            if (SortField == "Numer maszyny")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.MaszynyNumerMaszyny));
            if (SortField == "Data")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.Data));
            if (SortField == "Typ wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.TypWizyty));
            if (SortField == "Opis")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Numer maszyny", "Data", "Typ wizyty", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Imię")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.PracownikNazwisko != null && item.PracownikNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Numer maszyny")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.MaszynyNumerMaszyny != null && item.MaszynyNumerMaszyny.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
            if (FindField == "Typ wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.TypWizyty != null && item.TypWizyty.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WizytyForAllView>
                (
                    from wizyty in vendingEntities.Wizyty
                    select new WizytyForAllView
                    {
                        PracownikImie = wizyty.Pracownicy.Imie,
                        PracownikNazwisko = wizyty.Pracownicy.Nazwisko,
                        MaszynyNumerMaszyny = wizyty.Maszyny.NumerMaszyny,
                        Data = wizyty.Data,
                        TypWizyty = wizyty.TypWizyty,
                        Opis = wizyty.Opis
                    }
                );
        }
        #endregion
    }
}
