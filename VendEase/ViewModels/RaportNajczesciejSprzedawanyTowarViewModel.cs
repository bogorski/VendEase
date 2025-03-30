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
    internal class RaportNajczesciejSprzedawanyTowarViewModel : WorkspaceViewModel
    {
        #region DB
        VendingEntities db;
        #endregion
        #region Konstruktor
        public RaportNajczesciejSprzedawanyTowarViewModel()
        {
            base.DisplayName = "Najczęściej sprzedawany towar";
            db = new VendingEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            NazwaTowaru = "brak danych";
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
        private string _NazwaTowaru;
        public string NazwaTowaru
        {
            get
            {
                return _NazwaTowaru;
            }
            set
            {
                if (_NazwaTowaru != value)
                {
                    _NazwaTowaru = value;
                    OnPropertyChanged(() => NazwaTowaru);
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
            NazwaTowaru = new TowarSprzedazB(db).NajlepiejSprzedajacyTowar(NumerMaszyny, DataOd, DataDo);
        }
        #endregion
    }
}
