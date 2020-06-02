using DatabaseBroker;
using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Common;
using LagerLista.Edit;
using System;
using System.Collections.ObjectModel;
using System.Windows;

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
        private Workbench _selectedWorkbench;
        private ObservableCollection<Panel> _lagerList = new ObservableCollection<Panel>();
        private ObservableCollection<Workbench> _workbenches = new ObservableCollection<Workbench>();
        private ObservableCollection<TypeOfPanel> _typesOfPanel = new ObservableCollection<TypeOfPanel>();
        private TypeOfPanel _selectedMaterialForSearch;
        private string _searchText;
        private bool _isPanelVisible;
        private bool _isWorkbenchVisible;

        private readonly RelayCommand _addNewMaterial;
        private readonly RelayCommand _editSelectedMaterial;
        private readonly RelayCommand _deleteSelectedMaterial;
        private readonly RelayCommand _search;

        public RelayCommand AddNewMaterialCommand => _addNewMaterial;
        public RelayCommand EditSelectedMaterialCommand => _editSelectedMaterial;
        public RelayCommand DeleteSelectedMaterialCommand => _deleteSelectedMaterial;
        public RelayCommand SearchCommand => _search;

        public ObservableCollection<Panel> LagerList
        {
            get { return _lagerList; }
            set
            {
                _lagerList = value;
                OnPropertyChanged(nameof(LagerList));
            }
        }
        public ObservableCollection<Workbench> Workbenches
        {
            get { return _workbenches; }
            set
            {
                _workbenches = value;
                OnPropertyChanged(nameof(Workbenches));
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
                    if (_selectedMaterial != null)
                        _selectedWorkbench = null;
                    OnPropertyChanged(nameof(SelectedMaterial));
                }
            }
        }
        public Workbench SelectedWorkbench
        {
            get { return _selectedWorkbench; }
            set
            {
                _selectedWorkbench = value;
                if (_selectedWorkbench != null)
                    _selectedMaterial = null;
                OnPropertyChanged(nameof(SelectedWorkbench));
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
                if (_selectedMaterialForSearch != null)
                    ChoseType();
                SearchText = null;
                OnPropertyChanged(nameof(SelectedMaterialForSearch));
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public bool IsWorkbenchVisible
        {
            get { return _isWorkbenchVisible; }
            set
            {
                _isWorkbenchVisible = value;
                OnPropertyChanged(nameof(IsWorkbenchVisible));
            }
        }
        public bool IsPanelVisible
        {
            get { return _isPanelVisible; }
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged(nameof(IsPanelVisible));
            }
        }

        public event EventHandler Started;
        public event EventHandler AddNewMaterial;
        public event EventHandler<PanelEventArgs> EditSelectedPanel;
        public event EventHandler<WorkbenchEventArgs> EditSelectedWorkbench;
        public event EventHandler<PanelEventArgs> DeleteMaterial;

        TypeOfPanel defaultselect;

        public HomeViewModel()
        {
            defaultselect = new TypeOfPanel()
            {
                Id = -1,
                PanelType = "Прикажи све"
            };

            SelectedMaterialForSearch = defaultselect;

            TypesOfPanel.Add(defaultselect);

            foreach (var item in Broker.Instance.GetAllTypes())
                TypesOfPanel.Add(item);

            _addNewMaterial = new RelayCommand(executeAddNewMaterialCommand);
            _editSelectedMaterial = new RelayCommand(executeEditExistingMaterialCommand);
            _deleteSelectedMaterial = new RelayCommand(executeDeleteSelectedMaterialCommand);
            _search = new RelayCommand(executeSearchCommand);
        }

        private void ChoseType()
        {
            if (SelectedMaterialForSearch == defaultselect)
            {
                LagerList = new ObservableCollection<Panel>();
                LagerList = Broker.Instance.GetAllPanels();
                IsPanelVisible = true;
                IsWorkbenchVisible = false;
            }
            else if (SelectedMaterialForSearch.PanelType == "Radna Ploca")
            {
                Workbenches = new ObservableCollection<Workbench>();
                Workbenches = Broker.Instance.GetAllWorkbenches();
                IsPanelVisible = false;
                IsWorkbenchVisible = true;
            }
            else
            {
                LagerList = new ObservableCollection<Panel>();
                LagerList = Broker.Instance.GetAllPanels(SelectedMaterialForSearch);
                IsPanelVisible = true;
                IsWorkbenchVisible = false;
            }
        }

        private void executeSearchCommand()
        {
            if (SelectedMaterialForSearch.PanelType == "Прикажи све")
            {
                if (SearchText == null)
                {
                    LagerList = new ObservableCollection<Panel>();
                    LagerList = Broker.Instance.GetAllPanels();
                }
                else
                {
                    LagerList = new ObservableCollection<Panel>();
                    LagerList = Broker.Instance.GetAllPanels(SearchText);
                }
            }
            else if (SelectedMaterialForSearch != null && SelectedMaterialForSearch.PanelType != "Radna Ploca")
            {
                if (SearchText == null)
                {
                    LagerList = new ObservableCollection<Panel>();
                    LagerList = Broker.Instance.GetAllPanels(SelectedMaterialForSearch);
                }
                else
                {
                    LagerList = new ObservableCollection<Panel>();
                    LagerList = Broker.Instance.GetAllPanels(SelectedMaterialForSearch, SearchText);
                }
            }
        }

        private void executeDeleteSelectedMaterialCommand()
        {
            DeleteMaterial?.Invoke(this, new PanelEventArgs(SelectedMaterial));
        }

        private void executeEditExistingMaterialCommand()
        {
            if (SelectedWorkbench != null)
            {
                EditSelectedWorkbench?.Invoke(this, new WorkbenchEventArgs(SelectedWorkbench));
            }
            else if (SelectedMaterial != null)
            {
                EditSelectedPanel?.Invoke(this, new PanelEventArgs(SelectedMaterial));
            }
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
            SelectedWorkbench = null;
        }

        public void Start()
        {
            LagerList = new ObservableCollection<Panel>();
            LagerList = Broker.Instance.GetAllPanels();

            SelectedMaterialForSearch = defaultselect;

            //IsPanelVisible = true;
            //IsWorkbenchVisible = false;

            RoleMode = true;

            Started?.Invoke(this, new EventArgs());
        }
    }
}