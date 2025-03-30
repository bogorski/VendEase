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
    public class RaportPracownikTowaryViewModel : WorkspaceViewModel
    {
        #region DB
        VendingEntities db;
        #endregion
        #region Konstruktor
        public RaportPracownikTowaryViewModel()
        {
            base.DisplayName = "Raport ilości danego towaru na stanie pracownika";
            db = new VendingEntities();
            IloscOd = 0;
            IloscDo = 0;
            Ilosc = "brak";
        }
        #endregion
        #region Pola
        private int _IloscOd;
        public int IloscOd
        {
            get
            {
                return _IloscOd;
            }
            set
            {
                if (_IloscOd != value)
                {
                    _IloscOd = value;
                    OnPropertyChanged(() => IloscOd);
                }
            }
        }
        private int _IloscDo;
        public int IloscDo
        {
            get
            {
                return _IloscDo;
            }
            set
            {
                if (_IloscDo != value)
                {
                    _IloscDo = value;
                    OnPropertyChanged(() => IloscDo);
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
        private string _Ilosc;
        public string Ilosc
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
            Ilosc = new TowarPracownikIloscB(db).IloscTowarPracownik(IDTowaru, IloscOd, IloscDo);
        }
        #endregion
    }
}
