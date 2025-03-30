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
    public class NowaWizytaViewModel : JedenViewModel<Wizyty>
    {
        #region Konstruktor
        public NowaWizytaViewModel()
            : base("Wizyty")
        {
            item = new Wizyty();
            Data = DateTime.Now;
        }
        #endregion
        #region Properties
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
        public string NumerMaszyny
        {
            get
            {
                return item.NumerMaszyny;
            }
            set
            {
                item.NumerMaszyny = value;
                OnPropertyChanged(() => NumerMaszyny);
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
        public string TypWizyty
        {
            get
            {
                return item.TypWizyty;
            }
            set
            {
                item.TypWizyty = value;
                OnPropertyChanged(() => TypWizyty);
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
        public IQueryable<KeyAndValue> PracownicyItems
        {
            get
            {
                return new PracownicyB(vendingEntities).GetPracownicyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValueString> MaszynyItems
        {
            get
            {
                return new MaszynyB(vendingEntities).GetMaszynyKeyAndValueItems();
            }
        }
       
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Wizyty.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
