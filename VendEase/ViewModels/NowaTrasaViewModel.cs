using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class NowaTrasaViewModel : JedenViewModel<Trasy>
    {
        #region Konstruktor
        public NowaTrasaViewModel()
            : base("Trasa")
        {
            item = new Trasy();
            DataUtworzenia = DateTime.Now;
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                item.Nazwa = value;
                OnPropertyChanged(() => Nazwa);
            }
        }
        public DateTime? DataUtworzenia
        {
            get
            {
                return item.DataUtworzenia;
            }
            set
            {
                item.DataUtworzenia = value;
                OnPropertyChanged(() => DataUtworzenia);
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
        public string Ocena
        {
            get
            {
                return item.Ocena;
            }
            set
            {
                item.Ocena = value;
                OnPropertyChanged(() => Ocena);
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Trasy.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
