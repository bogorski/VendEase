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
    public class WszystkieZamowieniaViewModel : WszystkieViewModel<ZamowieniaForAllView>
    {
        #region Constructor
        public WszystkieZamowieniaViewModel()
           : base("Zamówienia")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa magazynu", "Miasto magazynu", "Imie pracownika", "Nazwisko pracownika", "Data", "Priorytet", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa magazynu")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.MagazynNazwa));
            if (SortField == "Miasto magazynu")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.MagazynMiasto));
            if (SortField == "Imie pracownika")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.PracownikImie));
            if (SortField == "Nazwisko pracownika")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.PracownikNazwisko));
            if (SortField == "Data")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.Data));
            if (SortField == "Priorytet")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.Priorytet));
            if (SortField == "Opis")
                List = new ObservableCollection<ZamowieniaForAllView>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa magazynu", "Miasto magazynu", "Imie pracownika", "Nazwisko pracownika", "Data", "Priorytet", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa magazynu")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.MagazynNazwa != null && item.MagazynNazwa.StartsWith(FindTextBox)));
            if (FindField == "Miasto magazynu")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.MagazynMiasto != null && item.MagazynMiasto.StartsWith(FindTextBox)));
            if (FindField == "Imie pracownika")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko pracownika")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.PracownikNazwisko != null && item.PracownikNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
            if (FindField == "Priorytet")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.Priorytet != null && item.Priorytet.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<ZamowieniaForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaForAllView>
                (
                    from zamowienia in vendingEntities.Zamowienia
                    select new ZamowieniaForAllView
                    {
                        MagazynNazwa = zamowienia.Magazyny.Nazwa,
                        MagazynMiasto = zamowienia.Magazyny.Miasto,
                        PracownikImie = zamowienia.Pracownicy.Imie,
                        PracownikNazwisko = zamowienia.Pracownicy.Nazwisko,
                        Data = zamowienia.Data,
                        Priorytet = zamowienia.Priorytet,
                        Opis = zamowienia.Opis
                    }
                );
        }
        #endregion
    }
}
