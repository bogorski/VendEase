using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    public class NowaMaszynaTowaryViewModel : JedenViewModel<MaszynaTowary>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaMaszynaTowaryViewModel()
            : base("Towar w maszynach")
        {
            item = new MaszynaTowary();
            Data = DateTime.Now;
        }
        #endregion
        #region Properties
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
        public IQueryable<KeyAndValueString> MaszynyItems
        {
            get
            {
                return new MaszynyB(vendingEntities).GetMaszynyKeyAndValueItems();
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
            var existingRecord = vendingEntities.MaszynaTowary
                .FirstOrDefault(mt => mt.NumerMaszyny == item.NumerMaszyny && mt.IDTowaru == item.IDTowaru);

            if (existingRecord != null)
            {
                // Jeśli rekord istnieje zwiększ ilość
                existingRecord.Stan += item.Stan;
            }
            else
            {
                // Jeśli rekord nie istnieje dodaj nowy
                vendingEntities.MaszynaTowary.Add(item);
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
