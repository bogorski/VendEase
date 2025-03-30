using VendEase.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendEase.Models.Entities;

namespace VendEase.ViewModels
{
    public class WszystkieMaszynyViewModel : WszystkieViewModel<MaszynyForAllView>
    {
        #region Constructor
        public WszystkieMaszynyViewModel()
           : base("Maszyny")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer maszyny", "Typ maszyny", "Numer seryjny", "Rok produkcji", "Opis", "Data montażu" };
        }
        public override void Sort()
        {
            if (SortField == "Numer maszyny")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.NumerMaszyny));
            if (SortField == "Typ maszyny")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.MaszynyTypMaszynny));
            if (SortField == "Numer seryjny")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.NumerSeryjny));
            if (SortField == "Rok produkcji")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.RokProdukcji));
            if (SortField == "Opis")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.Opis));
            if (SortField == "Data montażu")
                List = new ObservableCollection<MaszynyForAllView>(List.OrderBy(item => item.DataMontazu));
            
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer maszyny", "Typ maszyny", "Numer seryjny", "Opis", "Data montażu" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Numer maszyny")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.NumerMaszyny != null && item.NumerMaszyny.StartsWith(FindTextBox)));
            if (FindField == "Typ maszyny")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.MaszynyTypMaszynny != null && item.MaszynyTypMaszynny.StartsWith(FindTextBox)));
            if (FindField == "Numer seryjny")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.NumerSeryjny != null && item.NumerSeryjny.StartsWith(FindTextBox)));
            if (FindField == "Rok produkcji")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.RokProdukcji != null && item.RokProdukcji.ToString().StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data montażu")
                List = new ObservableCollection<MaszynyForAllView>(List.Where(item => item.DataMontazu != null && item.DataMontazu.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<MaszynyForAllView>
                (
                    from maszyny in vendingEntities.Maszyny
                    select new MaszynyForAllView
                    {
                        NumerMaszyny = maszyny.NumerMaszyny,
                        MaszynyTypMaszynny = maszyny.TypyMaszyn.Typ,
                        NumerSeryjny = maszyny.NumerSeryjny,
                        RokProdukcji = maszyny.RokProdukcji,
                        Opis = maszyny.Opis,
                        DataMontazu = maszyny.DataMontazu
                    }
                );
        }
        #endregion
    }
}
