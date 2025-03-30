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
    public class WszyscyPracownicyTowaryViewModel : WszystkieViewModel<PracownikTowaryForAllView>
    {
        #region Constructor
        public WszyscyPracownicyTowaryViewModel()
           : base("Pracownik towary")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Nazwa towaru", "Stan", "Jedostka miary", "Opis", "Data" };
        }
        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.PracownikImie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.PracownikNazwisko));
            if (SortField == "Nazwa towaru")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.TowarNazwa));
            if (SortField == "Stan")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.Stan));
            if (SortField == "Jedostka miary")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.JednostkaMiary));
            if (SortField == "Opis")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Data")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.OrderBy(item => item.Data));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Nazwa towaru", "Stan", "Jedostka miary", "Opis", "Data" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Imię")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.PracownikNazwisko != null && item.PracownikNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Nazwa towaru")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.TowarNazwa != null && item.TowarNazwa.StartsWith(FindTextBox)));
            if (FindField == "Stan")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.Stan != null && item.Stan.ToString().StartsWith(FindTextBox)));
            if (FindField == "Jedostka miary")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.JednostkaMiary != null && item.JednostkaMiary.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<PracownikTowaryForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownikTowaryForAllView>
                (
                    from pracownikTowary in vendingEntities.PracownikTowary
                    select new PracownikTowaryForAllView
                    {
                        PracownikImie = pracownikTowary.Pracownicy.Imie,
                        PracownikNazwisko = pracownikTowary.Pracownicy.Nazwisko,
                        TowarNazwa = pracownikTowary.Towary.Nazwa,
                        Stan = pracownikTowary.Stan,
                        JednostkaMiary = pracownikTowary.Towary.JednostkaMiary,
                        Opis = pracownikTowary.Opis,
                        Data = pracownikTowary.Data
                    }
                );
        }
        #endregion
    }
}
