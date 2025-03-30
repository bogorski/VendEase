using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using VendEase.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Data.Entity.Core.Metadata.Edm;
using GalaSoft.MvvmLight.Messaging;
using VendEase.Models.Entities;
using VendEase.Views;

namespace VendEase.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            //messenger oczekuje na stringa i wywołuje metodę open
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Dostawcy",
                    new BaseCommand(() => this.ShowAllViews<WszyscyDostawcyViewModel>())),

                new CommandViewModel(
                    "Dostawy",
                    new BaseCommand(() => this.ShowAllViews<WszystkieDostawyTowaryViewModel>())),

                new CommandViewModel(
                    "Faktury",
                    new BaseCommand(() => this.ShowAllViews<WszystkieFakturyViewModel>())),

                new CommandViewModel(
                    "Lokalizacje",
                    new BaseCommand(() => this.ShowAllViews<WszystkieLokalizacjeViewModel>())),

                new CommandViewModel(
                    "Magazyny",
                    new BaseCommand(() => this.ShowAllViews<WszystkieMagazynyViewModel>())),

                new CommandViewModel(
                    "Maszyny",
                    new BaseCommand(() => this.ShowAllViews<WszystkieMaszynyViewModel>())),

                new CommandViewModel(
                    "Pojazdy",
                    new BaseCommand(() => this.ShowAllViews<WszystkiePojazdyViewModel>())),

                new CommandViewModel(
                    "Pracownicy",
                    new BaseCommand(() => this.ShowAllViews<WszyscyPracownicyViewModel>())),

                new CommandViewModel(
                    "Pracownik towary",
                    new BaseCommand(() => this.ShowAllViews<WszyscyPracownicyTowaryViewModel>())),

                new CommandViewModel(
                    "Stanowiska pracy",
                    new BaseCommand(() => this.ShowAllViews<WszystkieStanowiskaPracyViewModel>())),

                new CommandViewModel(
                    "Stany magazynowe",
                    new BaseCommand(() => this.ShowAllViews<WszystkieMagazynyTowaryViewModel>())),

                new CommandViewModel(
                    "Towary w maszynach",
                    new BaseCommand(() => this.ShowAllViews<WszystkieMaszynyTowaryViewModel>())),

                new CommandViewModel(
                    "Towary",
                    new BaseCommand(() => this.ShowAllViews<WszystkieTowaryViewModel>())),

                new CommandViewModel(
                    "Transakcje",
                    new BaseCommand(() => this.ShowAllViews<WszystkieTransakcjeViewModel>())),

                new CommandViewModel(
                    "Trasy",
                    new BaseCommand(() => this.ShowAllViews<WszystkieTrasyViewModel>())),

                new CommandViewModel(
                    "Typy maszyn",
                    new BaseCommand(() => this.ShowAllViews<WszystkieTypyMaszynViewModel>())),

                new CommandViewModel(
                    "Warsztaty",
                    new BaseCommand(() => this.ShowAllViews<WszystkieWarsztatyViewModel>())),

                new CommandViewModel(
                    "Wizyty",
                    new BaseCommand(() => this.ShowAllViews<WszystkieWizytyViewModel>())),
                new CommandViewModel(
                    "Zamówienia",
                    new BaseCommand(() => this.ShowAllViews<WszystkieZamowieniaViewModel>())),
                 new CommandViewModel(
                    "Zamówienia zewnętrzne",
                    new BaseCommand(() => this.ShowAllViews<WszystkieZamowieniaZewnetrzneViewModel>())),

                 new CommandViewModel(
                    "Raport sprzedaży",
                    new BaseCommand(() => this.ShowAllViews<RaportSprzedazyViewModel>())),

                 new CommandViewModel(
                    "Raport pracownik towar",
                    new BaseCommand(() => this.ShowAllViews<RaportPracownikTowaryViewModel>())),
                
                new CommandViewModel(
                    "Najczęściej sprzedawany towar",
                    new BaseCommand(() => this.ShowAllViews<RaportNajczesciejSprzedawanyTowarViewModel>())),

                new CommandViewModel(
                    "Pracownik",
                    new BaseCommand(() => this.ShowAllViews<WidokPracownikViewModel>())),
                
                new CommandViewModel(
                    "Maszyna",
                    new BaseCommand(() => this.ShowAllViews<WidokMaszynaViewModel>())),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        { 
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }

        //new() - publiczny konstruktor bez parametrów, WorkspaceViewModel - klasa musi dziedziczyć po WorkspaceViewModel
        private void ShowAllViews<T>() where T : WorkspaceViewModel, new()
        {
            T workspace = this.Workspaces.OfType<T>().FirstOrDefault();

            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllZamowieniaZewnetrzne()
        {
            WszystkieZamowieniaZewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieZamowieniaZewnetrzneViewModel) as WszystkieZamowieniaZewnetrzneViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieZamowieniaZewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllWarsztaty()
        {
            WszystkieWarsztatyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieWarsztatyViewModel) as WszystkieWarsztatyViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieWarsztatyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPojazdy()
        {
            WszystkiePojazdyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePojazdyViewModel) as WszystkiePojazdyViewModel;

            if (workspace == null)
            {
                workspace = new WszystkiePojazdyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }  
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;

            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string name)
        {
            if (name == "DostawyAdd")
                CreateView(new NowaDostawaTowaryViewModel());
            if (name == "DostawcyAdd")
                CreateView(new NowyDostawcaViewModel());
            if (name=="FakturyAdd")
                CreateView(new NowaFakturaViewModel());
            if (name == "LokalizacjeAdd")
                CreateView(new NowaLokalizacjaViewModel());
            if (name == "PracownicyAdd")
                CreateView(new NowyPracownikViewModel());
            if (name == "Pracownik towaryAdd")
                CreateView(new NowyPracownikTowaryViewModel());
            if (name == "MagazynyAdd")
                CreateView(new NowyMagazynViewModel());
            if (name == "MaszynyAdd")
                CreateView(new NowaMaszynaViewModel());
            if (name == "PojazdyAdd")
                CreateView(new NowyPojazdViewModel());
            if (name == "Stanowiska pracyAdd")
                CreateView(new NoweStanowiskoPracyViewModel());
            if (name == "Stany magazynoweAdd")
                CreateView(new NowyMagazynTowaryViewModel());
            if (name == "Towary w maszynachAdd")
                CreateView(new NowaMaszynaTowaryViewModel());          
            if (name == "TowaryAdd")
                CreateView(new NowyTowarViewModel());
            if (name == "TransakcjeAdd")
                CreateView(new NowaTransakcjaViewModel());
            if (name == "TrasyAdd")
                CreateView(new NowaTrasaViewModel());
            if (name == "Typy maszynAdd")
                CreateView(new NowyTypMaszynyViewModel());
            if (name == "WarsztatyAdd")
                CreateView(new NowyWarsztatViewModel());
            if (name == "WizytyAdd")
                CreateView(new NowaWizytaViewModel());
            if (name == "ZamówieniaAdd")
                CreateView(new NoweZamowienieViewModel());
            if (name == "Zamówienia zewnętrzneAdd")
                CreateView(new NoweZamowienieZewnetrzneViewModel());
            if (name == "ZamowieniaZewnetrzneAll")
                ShowAllZamowieniaZewnetrzne();
            if (name == "WarsztatyAll")
                ShowAllWarsztaty();
            if (name == "PojazdyAll")
                ShowAllPojazdy();
            if (name == "FakturyAll")
                ShowAllFaktury();
        }
        #endregion
    }
}
