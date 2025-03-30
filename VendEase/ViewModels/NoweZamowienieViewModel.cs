using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class NoweZamowienieViewModel : JedenViewModel<Zamowienia>
    {
        #region Konstruktor
        public NoweZamowienieViewModel()
            : base("Zamówienia")
        {
            item = new Zamowienia();
            Data = DateTime.Now;
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
        public int IDPracownika
        {
            get
            {
                return item.IDPracownika;
            }
            set
            {
                item.IDPracownika = value;
                OnPropertyChanged(() => IDPracownika);
            }
        }
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
        public string Priorytet
        {
            get
            {
                return item.Priorytet;
            }
            set
            {
                item.Priorytet = value;
                OnPropertyChanged(() => Priorytet);
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
        public IQueryable<KeyAndValue> PracownicyItems
        {
            get
            {
                return new PracownicyB(vendingEntities).GetPracownicyKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Zamowienia.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
