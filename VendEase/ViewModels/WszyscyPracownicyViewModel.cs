using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownicyForAllView>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
           : base("Pracownicy")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Stanowisko", "Pensja", "Data zatrudnienia", "Numer rejestracyjny pojazdu", "Trasa", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Imie));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "Stanowisko")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.StanowiskoNazwa));
            if (SortField == "Pensja")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Pensja));
            if (SortField == "Data zatrudnienia")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.DataZatrudnienia));
            if (SortField == "Numer rejestracyjny pojazdu")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.PojazdNumerRejestracyjny));
            if (SortField == "Trasa")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.TrasaNazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<PracownicyForAllView>(List.OrderBy(item => item.Opis));
            
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Stanowisko", "Pensja", "Data zatrudnienia", "Numer rejestracyjny pojazdu", "Trasa", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Imię")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "Stanowisko")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.StanowiskoNazwa != null && item.StanowiskoNazwa.StartsWith(FindTextBox)));
            if (FindField == "Pensja")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Pensja != null && item.Pensja.ToString().StartsWith(FindTextBox)));
            if (FindField == "Data zatrudnienia")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.DataZatrudnienia != null && item.DataZatrudnienia.ToString().StartsWith(FindTextBox)));
            if (FindField == "Numer rejestracyjny pojazdu")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.PojazdNumerRejestracyjny != null && item.PojazdNumerRejestracyjny.StartsWith(FindTextBox)));
            if (FindField == "Trasa")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.TrasaNazwa != null && item.TrasaNazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PracownicyForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownicyForAllView>
                (
                    from pracownicy in vendingEntities.Pracownicy
                    select new PracownicyForAllView
                    {
                        Imie = pracownicy.Imie,
                        Nazwisko = pracownicy.Nazwisko,
                        StanowiskoNazwa = pracownicy.StanowiskaPracy.NazwaStanowiska,
                        Pensja = pracownicy.Pensja,
                        DataZatrudnienia = pracownicy.DataZatrudnienia,
                        PojazdNumerRejestracyjny = pracownicy.Pojazdy.NumerRejestracyjny,
                        TrasaNazwa = pracownicy.Trasy.Nazwa,
                        Opis = pracownicy.Opis
                    }
                );
        }
        #endregion
    }
}
