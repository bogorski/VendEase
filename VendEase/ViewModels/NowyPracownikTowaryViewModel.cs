using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Validators;
using System.ComponentModel;

namespace VendEase.ViewModels
{
    public class NowyPracownikTowaryViewModel : JedenViewModel<PracownikTowary>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyPracownikTowaryViewModel()
            : base("Pracownik towary")
        {
            item = new PracownikTowary();
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
        public int Stan
        {
            get
            {
                return item.Stan;
            }
            set
            {
                item.Stan = value;
                OnPropertyChanged(() => Stan);
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

        public DateTime? Data
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

        #endregion
        #region Propertis ComboBox
        public IQueryable<KeyAndValue> PracownicyItems
        {
            get
            {
                return new PracownicyB(vendingEntities).GetPracownicyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowaryB(vendingEntities).GetTowaryKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            //vendingEntities.MagazynTowary.Add(item);
            // vendingEntities.SaveChanges();
            var existingRecord = vendingEntities.PracownikTowary
                .FirstOrDefault(pt => pt.IDPracownika == item.IDPracownika && pt.IDTowaru == item.IDTowaru);

            if (existingRecord != null)
            {
                // Jeśli rekord istnieje zwiększ ilość
                existingRecord.Stan += item.Stan;
            }
            else
            {
                // Jeśli rekord nie istnieje dodaj nowy
                vendingEntities.PracownikTowary.Add(item);
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
                if (name == "Stan")
                    komunikat = QuantityValidator.SprawdzCzyWiekszeRowneZero(this.Stan);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Stan"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
