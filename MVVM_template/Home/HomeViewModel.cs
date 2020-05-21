using DatabaseBroker;
using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Common;
using LagerLista.Edit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LagerLista.Home
{
    public enum HomeViewModelResultType
    {
        AddNew,
        EditExisting
    }

    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        private Panel _selectedMaterial;
        private ObservableCollection<Panel> _lagerList = new ObservableCollection<Panel>();

        private ObservableCollection<TypeOfPanel> _typesOfPanel = new ObservableCollection<TypeOfPanel>();
        private TypeOfPanel _selectedMaterialForSearch;

        private readonly RelayCommand _addNewMaterial;
        private readonly RelayCommand _editSelectedMaterial;
        private readonly RelayCommand _deleteSelectedMaterial;

        public RelayCommand AddNewMaterialCommand => _addNewMaterial;
        public RelayCommand EditSelectedMaterialCommand => _editSelectedMaterial;
        public RelayCommand DeleteSelectedMaterialCommand => _deleteSelectedMaterial;

        public ObservableCollection<Panel> LagerList
        {
            get { return _lagerList; }
            set
            {
                _lagerList = value;
                OnPropertyChanged(nameof(LagerList));
            }
        }
        public bool RoleMode { get; set; }
        public Panel SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }

        public ObservableCollection<TypeOfPanel> TypesOfPanel
        {
            get { return _typesOfPanel; }
            set
            {
                _typesOfPanel = value;
                OnPropertyChanged(nameof(TypesOfPanel));
            }
        }
        public TypeOfPanel SelectedMaterialForSearch
        {
            get { return _selectedMaterialForSearch; }
            set
            {
                _selectedMaterialForSearch = value;
                OnPropertyChanged(nameof(SelectedMaterialForSearch));
            }
        }

        public event EventHandler Started;
        public event EventHandler AddNewMaterial;
        public event EventHandler<PanelEventArgs> EditSelectedMaterial;
        public event EventHandler<PanelEventArgs> DeleteMaterial;

        public HomeViewModel()
        {
            TypesOfPanel = Broker.Instance.GetAllTypes();

            _addNewMaterial = new RelayCommand(executeAddNewMaterialCommand);
            _editSelectedMaterial = new RelayCommand(executeEditExistingMaterialCommand);
            _deleteSelectedMaterial = new RelayCommand(executeDeleteSelectedMaterialCommand);
        }

        private void executeDeleteSelectedMaterialCommand()
        {
            DeleteMaterial?.Invoke(this, new PanelEventArgs(SelectedMaterial));
        }

        private void executeEditExistingMaterialCommand()
        {
            EditSelectedMaterial?.Invoke(this, new PanelEventArgs(SelectedMaterial));
            ResetToDefault();
        }

        private void executeAddNewMaterialCommand()
        {
            AddNewMaterial?.Invoke(this, new EventArgs());
            ResetToDefault();
        }

        private void ResetToDefault()
        {
            SelectedMaterial = null;
        }

        public void Start()
        {
            LagerList = new ObservableCollection<Panel>();
            LagerList = Broker.Instance.GetAllPanels();

            RoleMode = true;

            Started?.Invoke(this, new EventArgs());
        }
    }
}
