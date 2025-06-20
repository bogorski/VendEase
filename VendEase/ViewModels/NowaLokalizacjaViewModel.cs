﻿using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VendEase.Models.Validators;

namespace VendEase.ViewModels
{
    public class NowaLokalizacjaViewModel : JedenViewModel<Lokalizacje>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaLokalizacjaViewModel()
            : base("Lokalizacja")
        {
            item = new Lokalizacje();
        }
        #endregion
        #region Properties
        public string NazwaKlienta
        {
            get
            {
                return item.NazwaKlienta;
            }
            set
            {
                item.NazwaKlienta = value;
                OnPropertyChanged(() => NazwaKlienta);
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

        #endregion
        #region Helpers
        public override void Save()
        {
            vendingEntities.Lokalizacje.Add(item);
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
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["KodPocztowy"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
