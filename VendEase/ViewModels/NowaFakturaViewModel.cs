using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Validators;
using System.ComponentModel;

namespace VendEase.ViewModels
{
    public class NowaFakturaViewModel : JedenViewModel<Faktury>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item = new Faktury();
            DataWystawienia = DateTime.Now;
        }
        #endregion
        #region Properties
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                item.NIP = value;
                OnPropertyChanged(() => NIP);
            }
        }
        public string NazwaSprzedawcy
        {
            get
            {
                return item.NazwaSprzedawcy;
            }
            set
            {
                item.NazwaSprzedawcy = value;
                OnPropertyChanged(() => NazwaSprzedawcy);
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                item.Ulica = value;
                OnPropertyChanged(() => Ulica);
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                item.Miasto = value;
                OnPropertyChanged(() => Miasto);
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                item.KodPocztowy = value;
                OnPropertyChanged(() => KodPocztowy);
            }
        }
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                item.Kraj = value;
                OnPropertyChanged(() => Kraj);
            }
        }
        public decimal WartoscNetto
        {
            get
            {
                return item.WartoscNetto;
            }
            set
            {
                item.WartoscNetto = value;
                OnPropertyChanged(() => WartoscNetto);
            }
        }
        public decimal WartoscBrutto
        {
            get
            {
                return item.WartoscBrutto;
            }
            set
            {
                item.WartoscBrutto = value;
                OnPropertyChanged(() => WartoscBrutto);
            }
        }
        public int VAT
        {
            get
            {
                return item.VAT;
            }
            set
            {
                item.VAT = value;
                OnPropertyChanged(() => VAT);
            }
        }
        public DateTime DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                item.DataWystawienia = value;
                OnPropertyChanged(() => DataWystawienia);
            }
        }
        public string NumerFaktury
        {
            get
            {
                return item.NumerFaktury;
            }
            set
            {
                item.NumerFaktury = value;
                OnPropertyChanged(() => NumerFaktury);
            }
        }

        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Faktury.Add(item);
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
                if (name == "KodPocztowy")
                    komunikat = PostCodeValidator.SprawdzCzyPoprawnyKodPocztowy(this.KodPocztowy);
                if (name == "WartoscNetto")
                    komunikat = QuantityValidator.SprawdzCzyWiekszeRowneZero(this.WartoscNetto);
                if (name == "WartoscBrutto")
                    komunikat = QuantityValidator.SprawdzCzyWiekszeRowneZero(this.WartoscBrutto);
                if (name == "VAT")
                    komunikat = BusinessValidator.SprawdzVat(this.VAT);
                if (name == "NIP")
                    komunikat = NIPValidator.SprawdzNIP(this.NIP);
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["KodPocztowy"] == null && this["WartoscNetto"] == null && this["WartoscBrutto"] == null && this["VAT"] == null && this["NIP"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
