using VendEase.Helper;
using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VendEase.ViewModels
{
    public class RaportSprzedazyViewModel : WorkspaceViewModel
    {
        #region DB
        VendingEntities db;
        #endregion
        #region Konstruktor
        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport sprzedaży";
            db = new VendingEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            Ilosc = 0;
        }
        #endregion
        #region Pola
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private string _NumerMaszyny;
        public string NumerMaszyny
        {
            get
            {
                return _NumerMaszyny;
            }
            set
            {
                if (_NumerMaszyny != value)
                {
                    _NumerMaszyny = value;
                    OnPropertyChanged(() => NumerMaszyny);
                }
            }
        }
        private int _IDTowaru;
        public int IDTowaru
        {
            get
            {
                return _IDTowaru;
            }
            set
            {
                if (_IDTowaru != value)
                {
                    _IDTowaru = value;
                    OnPropertyChanged(() => IDTowaru);
                }
            }
        }
        private int? _Ilosc;
        public int? Ilosc
        {
            get
            {
                return _Ilosc;
            }
            set
            {
                if (_Ilosc != value)
                {
                    _Ilosc = value;
                    OnPropertyChanged(() => Ilosc);
                }
            }
        }
        public IQueryable<KeyAndValueString> MaszynyItems
        {
            get
            {
                return new MaszynyB(db).GetMaszynyKeyAndValueItems();
            }
        }
        public IQueryable<KeyAndValue> TowaryItems
        {
            get
            {
                return new TowaryB(db).GetTowaryKeyAndValueItems();
            }
        }
        #endregion
        #region Komendy
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczIloscClick());
                return _ObliczCommand;
            }
        }
        private void obliczIloscClick()
        {
            Ilosc = new TransakcjeMaszynyTowarB(db).TransakcjeOkresMaszynaTowar(NumerMaszyny, IDTowaru, DataOd, DataDo);
        }
        #endregion
    }
}
