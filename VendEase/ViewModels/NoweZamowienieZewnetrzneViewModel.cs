using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using VendEase.Helper;

namespace VendEase.ViewModels
{
    public class NoweZamowienieZewnetrzneViewModel : JedenViewModel<ZamowieniaZewnetrzne>
    {
        #region Konstruktor
        public NoweZamowienieZewnetrzneViewModel()
            : base("Zamówienia")
        {
            item = new ZamowieniaZewnetrzne();
            Data = DateTime.Now;
            Messenger.Default.Register<Faktury>(this, getWybranaFaktura);
        }
        #endregion
        #region Command
        private BaseCommand _ShowFaktury;

        public ICommand ShowFaktury
        {
            get
            {
                if (_ShowFaktury == null)
                    _ShowFaktury = new BaseCommand(() => showFaktury());
                return _ShowFaktury;
            }
        }

        private void showFaktury()
        {
            Messenger.Default.Send<string>("FakturyAll");
        }
        #endregion
        #region Properties
        public int IDMagazynu
        {
            get
            {
                return item.IDMagazynu;
            }
            set
            {
                item.IDMagazynu = value;
                OnPropertyChanged(() => IDMagazynu);
            }
        }
        public int IDDostawcy
        {
            get
            {
                return item.IDDostawcy;
            }
            set
            {
                item.IDDostawcy = value;
                OnPropertyChanged(() => IDDostawcy);
            }
        }
        public int IDFaktury
        {
            get
            {
                return item.IDFaktury;
            }
            set
            {
                item.IDFaktury = value;
                OnPropertyChanged(() => IDFaktury);
            }
        }
        public string NumerFaktury { get; set; }
        public string NIP { get; set; }
        public DateTime Data
        {
            get
            {
                return item.Data;
            }
            set
            {
                item.Data = value;
                OnPropertyChanged(() => Data);
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
        #endregion
        #region Propertis ComboBox
        public IQueryable<KeyAndValue> MagazynyItems
        {
            get
            {
                return new MagazynyB(vendingEntities).GetMagazynyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> DostawcyItems
        {
            get
            {
                return new DostawcyB(vendingEntities).GetDostawcyKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        private void getWybranaFaktura(Faktury faktury)
        {
            IDFaktury = faktury.IDFaktury;
            NumerFaktury = faktury.NumerFaktury;
            NIP = faktury.NIP;
        }
        public override void Save()
        {
            vendingEntities.ZamowieniaZewnetrzne.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
