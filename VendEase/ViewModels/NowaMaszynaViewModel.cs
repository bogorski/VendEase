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
    public class NowaMaszynaViewModel : JedenViewModel<Maszyny>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaMaszynaViewModel()
            : base("Maszyny")
        {
            item = new Maszyny();
            RokProdukcji = DateTime.Now;
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
        public int IDTypMaszyny
        {
            get
            {
                return item.IDTypMaszyny;
            }
            set
            {
                item.IDTypMaszyny = value;
                OnPropertyChanged(() => IDTypMaszyny);
            }
        }
        public string NumerSeryjny
        {
            get
            {
                return item.NumerSeryjny;
            }
            set
            {
                item.NumerSeryjny = value;
                OnPropertyChanged(() => NumerSeryjny);
            }
        }

        public DateTime RokProdukcji
        {
            get
            {
                return item.RokProdukcji;
            }
            set
            {
                item.RokProdukcji = value;
                OnPropertyChanged(() => RokProdukcji);
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
        public DateTime? DataMontazu
        {
            get
            {
                return item.DataMontazu;
            }
            set
            {
                item.DataMontazu = value;
                OnPropertyChanged(() => DataMontazu);
            }
        }

        #endregion
        #region Propertis ComboBox
        public IQueryable<KeyAndValue> TypyMaszynItems
        {
            get
            {
                return new TypyMaszynB(vendingEntities).GetTypyMaszynKeyAndValueItems();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Maszyny.Add(item);
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
                if (name == "RokProdukcji")
                    komunikat = DateValidator.SprawdzCzyDataJestPrzedDzis(this.RokProdukcji);
                return komunikat;
            }
        }

        public override bool IsValid()
        {
            if (this["RokProdukcji"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
