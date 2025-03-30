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
    public class NowyMagazynTowaryViewModel : JedenViewModel<MagazynTowary>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyMagazynTowaryViewModel()
            : base("Stany magazynowe")
        {
            item = new MagazynTowary();
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
        public IQueryable<KeyAndValue> MagazynyItems
        {
            get
            {
                return new MagazynyB(vendingEntities).GetMagazynyKeyAndValueItems();
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
            var existingRecord = vendingEntities.MagazynTowary
                .FirstOrDefault(mt => mt.IDMagazynu == item.IDMagazynu && mt.IDTowaru == item.IDTowaru);

            if (existingRecord != null)
            {
                // Jeśli rekord istnieje zwiększ ilość
                existingRecord.Stan += item.Stan;
            }
            else
            {
                // Jeśli rekord nie istnieje dodaj nowy
                vendingEntities.MagazynTowary.Add(item);
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
