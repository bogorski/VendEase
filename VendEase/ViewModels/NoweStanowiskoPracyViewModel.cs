using VendEase.Helper;
using VendEase.Models;
using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VendEase.ViewModels
{
    public class NoweStanowiskoPracyViewModel : JedenViewModel<StanowiskaPracy>
    {
        #region Konstruktor
        public NoweStanowiskoPracyViewModel()
            :base("Stanowisko pracy")
        {
            item = new StanowiskaPracy();
        }
        #endregion
        #region Properties
        public string NazwaStanowiska
        {
            get
            {
                return item.NazwaStanowiska;
            }
            set
            {
                item.NazwaStanowiska = value;
                OnPropertyChanged(() => NazwaStanowiska);
            }
        }
        public string Dzial
        {
            get
            {
                return item.Dzial;
            }
            set
            {
                item.Dzial = value;
                OnPropertyChanged(() => Dzial);
            }
        }
        public int WymaganeDoswiadczenie
        {
            get
            {
                return item.WymaganeDoswiadczenie;
            }
            set
            {
                item.WymaganeDoswiadczenie = value;
                OnPropertyChanged(() => WymaganeDoswiadczenie);
            }
        }
        public string Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                item.Status = value;
                OnPropertyChanged(() => Status);
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
        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.StanowiskaPracy.Add(item);
            vendingEntities.SaveChanges();
        }
        #endregion
    }
}
