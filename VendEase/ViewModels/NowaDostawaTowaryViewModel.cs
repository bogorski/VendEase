using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendEase.Helper;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Markup;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    public class NowaDostawaTowaryViewModel : JedenViewModel<DostawaTowary>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaDostawaTowaryViewModel()
            : base("Dostawa")
        {
            item = new DostawaTowary();
            Messenger.Default.Register<ZamowieniaZewnetrzneForAllView>(this, getWybraneZamowienieZewnetrze);
        }
        #endregion
        #region Command
        private BaseCommand _ShowZamowieniaZewnetrzne;

        public ICommand ShowZamowieniaZewnetrzne
        {
            get
            {
                if (_ShowZamowieniaZewnetrzne == null)
                    _ShowZamowieniaZewnetrzne = new BaseCommand(() => showZamowieniaZewnetrzne());
                return _ShowZamowieniaZewnetrzne;
            }
        }

        private void showZamowieniaZewnetrzne()
        {
            Messenger.Default.Send<string>("ZamowieniaZewnetrzneAll");
        }
        #endregion
        #region Properties
        public int IDTowaru
        {
            get
            {
                return item.IDTowaru;
            }
            set
            {
                item.IDTowaru = value;
                OnPropertyChanged(() => IDTowaru);
            }
        }
        public int IDZamowienieZewnetrzne
        {
            get
            {
                return item.IDZamowienieZewnetrzne;
            }
            set
            {
                item.IDZamowienieZewnetrzne = value;
                OnPropertyChanged(() => IDZamowienieZewnetrzne);
            }
        }

        public int NumerZamowienia { get; set; }
        public DateTime? DataZamowienia { get; set; }
        public int Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                item.Ilosc = value;
                OnPropertyChanged(() => Ilosc);
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                item.Opis = value;
                OnPropertyChanged(() => Opis);
            }
        }
        public DateTime? DataWaznosci
        {
            get
            {
                return item.DataWaznosci;
            }
            set
            {
                item.DataWaznosci = value;
                OnPropertyChanged(() => DataWaznosci);
            }
        }
        #endregion
        #region Propertis ComboBox
        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowaryB(vendingEntities).GetTowaryKeyAndValueItems();
            }
        }

        #endregion
        #region Helpers
        private void getWybraneZamowienieZewnetrze(ZamowieniaZewnetrzneForAllView zamowieniaZewnetrzne)
        {
            IDZamowienieZewnetrzne = zamowieniaZewnetrzne.NumerZamowieniaZewnetrznego;
            NumerZamowienia = zamowieniaZewnetrzne.NumerZamowieniaZewnetrznego;
            DataZamowienia = zamowieniaZewnetrzne.Data;
        }
        public override void Save()
        {
            var existingRecord = vendingEntities.DostawaTowary
                .FirstOrDefault(mt => mt.IDZamowienieZewnetrzne == item.IDZamowienieZewnetrzne && mt.IDTowaru == item.IDTowaru);

            if (existingRecord != null)
            {
                // Jeśli rekord istnieje dodaj komunikat że już wprowadzono dany towar
                var towarName = existingRecord.Towary.Nazwa; 
                MessageBox.Show("Towar " + towarName + " został już wprowadzony do zamówienia ", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Jeśli rekord nie istnieje dodaj nowy
                vendingEntities.DostawaTowary.Add(item);
            }
            vendingEntities.SaveChanges();
        }
        #endregion
        #region Validation
        public string Error
        {
            get { return null; }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Ilosc")
                    komunikat = QuantityValidator.SprawdzCzyPowyzejZera(this.Ilosc);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Ilosc"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
