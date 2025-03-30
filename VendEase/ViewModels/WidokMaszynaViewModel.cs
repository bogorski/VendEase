using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.BusinessLogic;
using VendEase.Models.Entities;
using VendEase.Models.EntitiesForView;

namespace VendEase.ViewModels
{
    public class WidokMaszynaViewModel : WidokViewModel<MaszynyForAllView>
    {
        #region Constructor
        public WidokMaszynaViewModel()
           : base("Maszyny")
        {
        }
        #endregion
        #region Pola
        private MaszynyForAllView _selectedMaszyna;
        public MaszynyForAllView SelectedMaszyna
        {
            get => _selectedMaszyna;
            set
            {
                if (_selectedMaszyna != value)
                {
                    _selectedMaszyna = value;
                    OnPropertyChanged(() => SelectedMaszyna);
                }
            }
        }
        private int _liczbaMaszyn;

        public int liczbaMaszyn
        {
            get => _liczbaMaszyn;
            set
            {
                if (_liczbaMaszyn != value)
                {
                    _liczbaMaszyn = value;
                }
            }
        }
        private int _liczbaMaszynZamontowanych;
        public int liczbaMaszynZamontowanych
        {
            get => _liczbaMaszynZamontowanych;
            set
            {
                if (_liczbaMaszynZamontowanych != value)
                {
                    _liczbaMaszynZamontowanych = value;
                }
            }
        }
        
        private int _liczbaMaszynNiezamontowanych;
        public int liczbaMaszynNiezamontowanych
        {
            get => _liczbaMaszynNiezamontowanych;
            set
            {
                if (_liczbaMaszynNiezamontowanych != value)
                {
                    _liczbaMaszynNiezamontowanych = value;
                }
            }
        }

        private int _liczbaMaszynKawowych;
        public int liczbaMaszynKawowych
        {
            get => _liczbaMaszynKawowych;
            set
            {
                if (_liczbaMaszynKawowych != value)
                {
                    _liczbaMaszynKawowych = value;
                }
            }
        }

        private int _liczbaMaszynPrzekaskowych;
        public int liczbaMaszynPrzekaskowych
        {
            get => _liczbaMaszynPrzekaskowych;
            set
            {
                if (_liczbaMaszynPrzekaskowych != value)
                {
                    _liczbaMaszynPrzekaskowych = value;
                }
            }
        }
        
        private int _liczbaLokalizacji;
        public int liczbaLokalizacji
        {
            get => _liczbaLokalizacji;
            set
            {
                if (_liczbaLokalizacji != value)
                {
                    _liczbaLokalizacji = value;
                }
            }
        } 
        
        private List<TowarMaszynaStan> _towarNaWyczerpaniu;
        public List<TowarMaszynaStan> towarNaWyczerpaniu
        {
            get => _towarNaWyczerpaniu;
            set
            {
                if (_towarNaWyczerpaniu != value)
                {
                    _towarNaWyczerpaniu = value;
                }
            }
        }
        #endregion
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<MaszynyForAllView>
                (
                    from maszyna in vendingEntities.Maszyny
                    let towaryList = maszyna.MaszynaTowary
                        .Select(mt => new TowarMaszynaStan
                        {
                            Towar = mt.Towary,
                            Stan = mt.Stan
                        })
                        .ToList()
                    select new MaszynyForAllView
                    {
                        NumerMaszyny = maszyna.NumerMaszyny,
                        LokalizacjaNazwaKlienta = maszyna.Lokalizacje.FirstOrDefault().NazwaKlienta ?? "Niezamontowany",
                        LokalizacjaUlica = maszyna.Lokalizacje.FirstOrDefault().Ulica ?? "Magazyn",
                        LokalizacjaMiasto = maszyna.Lokalizacje.FirstOrDefault().Miasto ?? "Warszawa",
                        MaszynyTypMaszynny = maszyna.TypyMaszyn.Typ,
                        LokalizacjeList = maszyna.Lokalizacje.ToList(),

                        TowaryList = towaryList,

                        TowaryNiskiStan = towaryList
                            .Where(mt =>
                                (mt.Towar.JednostkaMiary == "szt" && mt.Stan < 50 && maszyna.TypyMaszyn.Typ == "Coffee") ||   // Jeśli jednostka miary to szt, stan poniżej 50
                                (mt.Towar.JednostkaMiary == "gram" && mt.Stan < 500 && maszyna.TypyMaszyn.Typ == "Coffee") ||  // Jeśli jednostka miary nie jest szt, stan poniżej 500
                                (mt.Stan < 5 && maszyna.TypyMaszyn.Typ == "Snack")
                            )
                            .ToList()
                    }
                );
         
            liczbaMaszyn = List.Count;
            liczbaMaszynNiezamontowanych = List.Count(m => m.LokalizacjaNazwaKlienta == "Niezamontowany");
            liczbaMaszynZamontowanych = liczbaMaszyn - liczbaMaszynNiezamontowanych;
            liczbaMaszynKawowych = List.Count(m => m.MaszynyTypMaszynny == "Coffee");
            liczbaMaszynPrzekaskowych = List.Count(m => m.MaszynyTypMaszynny == "Snack");

            liczbaLokalizacji = List
                .SelectMany(maszyna => maszyna.LokalizacjeList)
                .Distinct()
                .ToList().Count();

            if (List.Any())
            {
                SelectedMaszyna = List.First();
            }
        }
        #endregion
    }
}
