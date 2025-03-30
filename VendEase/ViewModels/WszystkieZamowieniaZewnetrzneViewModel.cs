using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VendEase.Models.Entities;

namespace VendEase.ViewModels
{
    public class WszystkieZamowieniaZewnetrzneViewModel : WszystkieViewModel<ZamowieniaZewnetrzneForAllView>
    {
        #region Constructor
        public WszystkieZamowieniaZewnetrzneViewModel()
           : base("Zamówienia zewnętrzne")
        {
        }
        #endregion
        #region Properties
        private ZamowieniaZewnetrzneForAllView _WybraneZamowienieZewnetrze;
        public ZamowieniaZewnetrzneForAllView WybraneZamowienieZewnetrze
        {
            get
            {
                return _WybraneZamowienieZewnetrze;
            }
            set
            {
                _WybraneZamowienieZewnetrze = value;
                Messenger.Default.Send(_WybraneZamowienieZewnetrze);
                OnRequestClose();
            }
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer zamówienia", "Nazwa magazynu", "Miasto magazynu", "Nazwa dostawcy", "Numer faktury", "Data", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Numer zamówienia")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.NumerZamowieniaZewnetrznego));
            if (SortField == "Nazwa magazynu")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.MagazynNazwa));
            if (SortField == "Miasto magazynu")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.MagazynMiasto));   
            if (SortField == "Nazwa dostawcy")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.DostawcaNazwa));
            if (SortField == "Numer faktury")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.FakturaNumerFaktury));
            if (SortField == "Data")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.Data));
            if (SortField == "Opis")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.OrderBy(item => item.Opis));
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer zamówienia", "Nazwa magazynu", "Miasto magazynu", "Nazwa dostawcy", "Numer faktury", "Data", "Opis" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Numer zamówienia")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.NumerZamowieniaZewnetrznego != null && item.NumerZamowieniaZewnetrznego.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa magazynu")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.MagazynNazwa != null && item.MagazynNazwa.StartsWith(FindTextBox)));
            if (FindField == "Miasto magazynu")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.MagazynMiasto != null && item.MagazynMiasto.StartsWith(FindTextBox)));
            if (FindField == "Nazwa dostawcy")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.DostawcaNazwa != null && item.DostawcaNazwa.StartsWith(FindTextBox)));
            if (FindField == "Numer faktury")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.FakturaNumerFaktury != null && item.FakturaNumerFaktury.StartsWith(FindTextBox)));
            if (FindField == "Data")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.Data != null && item.Data.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaZewnetrzneForAllView>
                (
                    from zamowieniaZewnetrzne in vendingEntities.ZamowieniaZewnetrzne
                    select new ZamowieniaZewnetrzneForAllView
                    {
                        NumerZamowieniaZewnetrznego = zamowieniaZewnetrzne.IDZamowienieZewnetrzne,
                        MagazynNazwa = zamowieniaZewnetrzne.Magazyny.Nazwa,
                        MagazynMiasto = zamowieniaZewnetrzne.Magazyny.Miasto,
                        DostawcaNazwa = zamowieniaZewnetrzne.Dostawcy.Nazwa,
                        FakturaNumerFaktury = zamowieniaZewnetrzne.Faktury.NumerFaktury,
                        Data = zamowieniaZewnetrzne.Data,
                        Opis = zamowieniaZewnetrzne.Opis
                    }
                );
        }
        #endregion
    }
}
