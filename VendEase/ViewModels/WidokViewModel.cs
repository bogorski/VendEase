using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VendEase.Helper;
using VendEase.Models.Entities;

namespace VendEase.ViewModels
{
    public abstract class WidokViewModel<T> : WorkspaceViewModel
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
        public WidokViewModel(String displayName)
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
    }
}