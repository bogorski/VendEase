using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;

namespace VendEase.ViewModels
{
    public class WidokPracownikViewModel : WidokViewModel<PracownicyForAllView>
    {
        #region Constructor
        public WidokPracownikViewModel()
           : base("Pracownicy")
        {
        }
        #endregion
        #region Pola
        private PracownicyForAllView _selectedPracownik;
        public PracownicyForAllView SelectedPracownik
        {
            get => _selectedPracownik;
            set
            {
                if (_selectedPracownik != value)
                {
                    _selectedPracownik = value;
                    OnPropertyChanged(() => SelectedPracownik);

                    if (_selectedPracownik != null && _selectedPracownik.LokalizacjeList.Any())
                    {
                        SelectedLokalizacja = _selectedPracownik.LokalizacjeList.First();
                    }
                }
            }
        }
        private Lokalizacje _selectedLokalizacja;
        public Lokalizacje SelectedLokalizacja
        {
            get => _selectedLokalizacja;
            set
            {
                if (_selectedLokalizacja != value)
                {
                    _selectedLokalizacja = value;
                    OnPropertyChanged(() => SelectedLokalizacja);
                }
            }
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<PracownicyForAllView>
                (
                    from pracownicy in vendingEntities.Pracownicy
                    select new PracownicyForAllView
                    {
                        Imie = pracownicy.Imie,
                        Nazwisko = pracownicy.Nazwisko,
                        StanowiskoNazwa = pracownicy.StanowiskaPracy.NazwaStanowiska,
                        StanowiskoDzial = pracownicy.StanowiskaPracy.Dzial,
                        PojazdNumerRejestracyjny = pracownicy.Pojazdy.NumerRejestracyjny,
                        PojazdMarka = pracownicy.Pojazdy.Marka,
                        PojazdDataPrzegladu = pracownicy.Pojazdy.DataPrzegladu,
                        PojazdDataUbezpieczenia = pracownicy.Pojazdy.DataUbezpieczenia,
                        PojazdOpis = pracownicy.Pojazdy.Opis,
                        PojazdUsterki = pracownicy.Pojazdy.Usterki,
                        PojazdWarsztatNazwa = pracownicy.Pojazdy.Warsztaty.Nazwa,
                        PojazdWarsztatUlica = pracownicy.Pojazdy.Warsztaty.Ulica,
                        PojazdWarsztatMiasto = pracownicy.Pojazdy.Warsztaty.Miasto,
                        PojazdWarsztatKodPocztowy = pracownicy.Pojazdy.Warsztaty.KodPocztowy,
                        PojazdWarsztatKraj = pracownicy.Pojazdy.Warsztaty.Kraj,
                        Pensja = pracownicy.Pensja,
                        DataZatrudnienia = pracownicy.DataZatrudnienia,
                        TrasaNazwa = pracownicy.Trasy.Nazwa,
                        Opis = pracownicy.Opis,
                        NumeryMaszynList = pracownicy.Trasy.Maszyny.ToList(),
                        LokalizacjeList = pracownicy.Trasy.Maszyny.SelectMany(t => t.Lokalizacje).Distinct().ToList(),
                    }
                );

            if (List.Any())
            {
                SelectedPracownik = List.First();
                SelectedLokalizacja = SelectedPracownik.LokalizacjeList.First();
            }
        }
        #endregion
    }
}
