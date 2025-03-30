using GalaSoft.MvvmLight.Messaging;
using VendEase.Helper;
using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VendEase.ViewModels
{
    public abstract class WszystkieViewModel<T>: WorkspaceViewModel
    {
        #region DB
        protected readonly VendingEntities vendingEntities;
        #endregion
        #region Command
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
        }
        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
            }
        }
        #endregion
        #region List
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayName)
        {
            vendingEntities = new VendingEntities();
            base.DisplayName = displayName; 
        }
        #endregion
        #region Helpers
        public abstract void Load();
        private void add()
        {
            //komunikat odbierze MainWindowViewModel
            Messenger.Default.Send(DisplayName + "Add");
        }
        #endregion
        #region Sort and Find
        //sortowanie
        public string SortField {  get; set; }
        public List<string> SortComboBoxItems 
        {  
            get
            {
                return GetComboBoxSortList();
            }
        }
        public abstract List<string> GetComboBoxSortList();
        private BaseCommand _SortCommand;

        public ICommand SortCommand
        {
            get 
            { 
                if(_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand; 
            }
        }

        public abstract void Sort();

        //filtrowanie
        public string FindField { get; set; }
        public List<string> FindComboBoxItems
        {
            get
            {
                return GetComboBoxFindList();
            }
        }
        public abstract List<string> GetComboBoxFindList();
        public string FindTextBox { get; set; }

        private BaseCommand _FindCommand;

        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }

        public abstract void Find();
        #endregion
    }
}
