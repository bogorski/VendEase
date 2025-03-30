using VendEase.Helper;
using VendEase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VendEase.ViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region DB
        protected VendingEntities vendingEntities;
        #endregion
        #region Item
        protected T item;
        #endregion
        #region Command
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => SaveAndClose());
                return _SaveCommand;
            }
        }
        #endregion
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            vendingEntities = new VendingEntities();
        }
        #endregion
        #region Helpers
        public abstract void Save();
        public void SaveAndClose()
        {
            //przed Save sprawdzamy czy wszystko jest dobrze
            if(IsValid())
            {
                Save();
                base.OnRequestClose();
            }
           
        }
        #endregion
        #region Validation
        public virtual bool IsValid()
        {
            return true; // domyslnie wszystko jest dobrze
        }
        #endregion
    }
}
