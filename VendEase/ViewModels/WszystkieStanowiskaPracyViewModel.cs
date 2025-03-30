using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.ViewModels
{
    public class WszystkieStanowiskaPracyViewModel : WszystkieViewModel<StanowiskaPracy>
    {
        #region Constructor
        public WszystkieStanowiskaPracyViewModel()
           : base("Stanowiska pracy")
        {
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "ID", "Nazwa stanowiska", "Dział", "Wymagane doświadczenie", "Status", "Opis", "Data utworzenia" };
        }
        public override void Sort()
        {
            if (SortField == "ID")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.IDStanowiskaPracy));
            if (SortField == "Nazwa stanowiska")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.NazwaStanowiska));
            if (SortField == "Dział")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.Dzial));
            if (SortField == "Wymagane doświadczenie")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.WymaganeDoswiadczenie));
            if (SortField == "Status")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.Status));
            if (SortField == "Opis")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.Opis));
            if (SortField == "Data utworzenia")
                List = new ObservableCollection<StanowiskaPracy>(List.OrderBy(item => item.DataUtworzenia));

        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "ID", "Nazwa stanowiska", "Dział", "Wymagane doświadczenie", "Status", "Opis", "Data utworzenia" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "ID")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.IDStanowiskaPracy != null && item.IDStanowiskaPracy.ToString().StartsWith(FindTextBox)));
            if (FindField == "Nazwa stanowiska")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.NazwaStanowiska != null && item.NazwaStanowiska.StartsWith(FindTextBox)));
            if (FindField == "Dział")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.Dzial != null && item.Dzial.StartsWith(FindTextBox)));
            if (FindField == "Wymagane doświadczenie")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.WymaganeDoswiadczenie != null && item.WymaganeDoswiadczenie.ToString().StartsWith(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.Status != null && item.Status.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
            if (FindField == "Data utworzenia")
                List = new ObservableCollection<StanowiskaPracy>(List.Where(item => item.DataUtworzenia != null && item.DataUtworzenia.ToString().StartsWith(FindTextBox)));
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<StanowiskaPracy>
                (
                    vendingEntities.StanowiskaPracy.ToList()
                );
        }
        #endregion
    }
}
