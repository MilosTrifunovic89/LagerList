using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Common;
using LagerLista.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DatabaseBroker;

namespace LagerLista.Edit
{
    public class EditViewModel : ViewModelBase, IEditViewModel
    {
        private bool _updateVisible;
        private bool _newVisible;
        private HomeViewModelResultType _result;
        private Panel _panel;
        private Workbench _workbench;
        private string _name;
        private Length _selectedLength = new Length();
        private Width _selectedWidth = new Width();
        private Thickness _selectedThickness = new Thickness();
        private int? _quantity;
        private string _panelSurface;
        private string _surfaceInTotal;
        private ObservableCollection<Length> _lengths = new ObservableCollection<Length>();
        private ObservableCollection<Width> _widths = new ObservableCollection<Width>();
        private ObservableCollection<Thickness> _thicknesses = new ObservableCollection<Thickness>();
        private TypeOfPanel _selectedTypeOfPanel = new TypeOfPanel();
        private ObservableCollection<TypeOfPanel> _typesOfPanel = new ObservableCollection<TypeOfPanel>();
        private bool _isEnabledQuantity;
        private bool _updateQuantityVisible;
        private int? _updateQuantity;
        private string _totalLength;
        private bool _typeIsEnabled;
        private bool _workbenchVisible;
        private bool _panelVisible;
        private bool _isEnabledDimensions;

        private RelayCommand _goBack;
        private RelayCommand _createNew;
        private RelayCommand _update;

        public Panel Panel
        {
            get { return _panel; }
            set
            {
                _panel = value;
                OnPropertyChanged(nameof(Panel));
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public Length SelectedLength
        {
            get { return _selectedLength; }
            set
            {
                _selectedLength = value;
                OnPropertyChanged(nameof(SelectedLength));
            }
        }
        public Width SelectedWidth
        {
            get { return _selectedWidth; }
            set
            {
                _selectedWidth = value;
                OnPropertyChanged(nameof(SelectedWidth));
            }
        }
        public Thickness SelectedThickness
        {
            get { return _selectedThickness; }
            set
            {
                _selectedThickness = value;
                OnPropertyChanged(nameof(SelectedThickness));
            }
        }
        public int? Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public string PanelSurface
        {
            get { return _panelSurface; }
            set
            {
                _panelSurface = value;
                OnPropertyChanged(nameof(PanelSurface));
            }
        }
        public string SurfaceInTotal
        {
            get { return _surfaceInTotal; }
            set
            {
                _surfaceInTotal = value;
                OnPropertyChanged(nameof(SurfaceInTotal));
            }
        }
        public ObservableCollection<Length> Lengths
        {
            get { return _lengths; }
            set
            {
                _lengths = value;
                OnPropertyChanged(nameof(Lengths));
            }
        }
        public ObservableCollection<Width> Widths
        {
            get { return _widths; }
            set
            {
                _widths = value;
                OnPropertyChanged(nameof(Widths));
            }
        }
        public ObservableCollection<Thickness> Thicknesses
        {
            get { return _thicknesses; }
            set
            {
                _thicknesses = value;
                OnPropertyChanged(nameof(Thicknesses));
            }
        }
        public TypeOfPanel SelectedTypeOfPanel
        {
            get { return _selectedTypeOfPanel; }
            set
            {
                _selectedTypeOfPanel = value;
                if (_selectedTypeOfPanel != null && _selectedTypeOfPanel.PanelType == "Radna Ploca")
                {
                    IsEnabledDimensions = true;
                    LoadDimensions();
                    WorkbenchVisible = true;
                    PanelVisible = false;
                }
                else if (_selectedTypeOfPanel != null && _selectedTypeOfPanel.PanelType != "Radna Ploca")
                {
                    IsEnabledDimensions = true;
                    LoadDimensions();
                    WorkbenchVisible = false;
                    PanelVisible = true;
                }
                OnPropertyChanged(nameof(SelectedTypeOfPanel));
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
        public string Caption { get; set; }
        public bool NewVisible
        {
            get { return _newVisible; }
            set
            {
                if (_newVisible != value)
                {
                    _newVisible = value;
                    OnPropertyChanged(nameof(NewVisible));
                }
            }
        }
        public bool UpdateVisible
        {
            get { return _updateVisible; }
            set
            {
                if (_updateVisible != value)
                {
                    _updateVisible = value;
                    OnPropertyChanged(nameof(UpdateVisible));
                }
            }
        }
        public bool IsEnabledQuantity
        {
            get { return _isEnabledQuantity; }
            set
            {
                _isEnabledQuantity = value;
                OnPropertyChanged(nameof(IsEnabledQuantity));
            }
        }
        public bool UpdateQuantityVisible
        {
            get { return _updateQuantityVisible; }
            set
            {
                _updateQuantityVisible = value;
                OnPropertyChanged(nameof(UpdateQuantityVisible));
            }
        }
        public int? UpdateQuantity
        {
            get { return _updateQuantity; }
            set
            {
                _updateQuantity = value;
                OnPropertyChanged(nameof(UpdateQuantity));
            }
        }
        public Workbench Workbench
        {
            get { return _workbench; }
            set
            {
                _workbench = value;
                OnPropertyChanged(nameof(Workbench));
            }
        }
        public string TotalLength
        {
            get { return _totalLength; }
            set
            {
                _totalLength = value;
                OnPropertyChanged(nameof(TotalLength));
            }
        }
        public bool TypeIsEnabled
        {
            get { return _typeIsEnabled; }
            set
            {
                _typeIsEnabled = value;
                OnPropertyChanged(nameof(TypeIsEnabled));
            }
        }
        public bool PanelVisible
        {
            get { return _panelVisible; }
            set
            {
                _panelVisible = value;
                OnPropertyChanged(nameof(PanelVisible));
            }
        }
        public bool WorkbenchVisible
        {
            get { return _workbenchVisible; }
            set
            {
                _workbenchVisible = value;
                OnPropertyChanged(nameof(WorkbenchVisible));
            }
        }
        public bool IsEnabledDimensions
        {
            get { return _isEnabledDimensions; }
            set
            {
                _isEnabledDimensions = value;
                OnPropertyChanged(nameof(IsEnabledDimensions));
            }
        }

        public RelayCommand GoBackCommand => _goBack;
        public RelayCommand CreateNewCommand => _createNew;
        public RelayCommand UpdateCommand => _update;

        public EditViewModel()
        {
            //Lengths = Broker.Instance.GetAllLengths();
            //Widths = Broker.Instance.GetAllWidths();
            //Thicknesses = Broker.Instance.GetAllThicknesses();
            TypesOfPanel = Broker.Instance.GetAllTypes();

            _goBack = new RelayCommand(executeGoBackCommand);
            _createNew = new RelayCommand(executeCreateNewCommand);
            _update = new RelayCommand(executeUpdateCommand);
        }

        public event EventHandler Started;
        public event EventHandler Succeeded;
        public event EventHandler<PanelEventArgs> CreateNewPanel;
        public event EventHandler<WorkbenchEventArgs> CreateNewWorkbench;
        public event EventHandler<PanelEventArgs> Update;

        private void LoadDimensions()
        {
            Lengths = new ObservableCollection<Length>(Broker.Instance.Context.Lengths.Where(x => x.Types.Any(t => t.Id == SelectedTypeOfPanel.Id)));

            Widths = new ObservableCollection<Width>(Broker.Instance.Context.Widths.Where(x => x.Types.Any(t => t.Id == SelectedTypeOfPanel.Id)));

            Thicknesses = new ObservableCollection<Thickness>(Broker.Instance.Context.Thicknesses.Where(x => x.Types.Any(t => t.Id == SelectedTypeOfPanel.Id)));
        }

        private void executeUpdateCommand()
        {
            if (SelectedTypeOfPanel.PanelType == "Radna Ploca")
            {
                Workbench workbench = EditExistingWorkbench(Broker.Instance.Context.Workbenchs.Find(Workbench.Id));
                Broker.Instance.Context.SaveChanges();
                TotalLength = workbench.TotalLength.ToString();
            }
            else
            {
                Panel panel = EditExistingPanel(Broker.Instance.Context.Panels.Find(Panel.Id));
                Broker.Instance.Context.SaveChanges();
                PanelSurface = Math.Round(panel.PanelSurface, 2).ToString();
                SurfaceInTotal = Math.Round(panel.SurfaceInTotal, 2).ToString();
            }
        }

        internal bool IsLessThenZero()
        {
            if (Quantity + UpdateQuantity < 0)
                return true;
            return false;
        }

        private Workbench EditExistingWorkbench(Workbench workbench)
        {
            workbench.Name = Name;
            workbench.LengthId = SelectedLength.Id;
            workbench.WidthId = SelectedWidth.Id;
            workbench.ThicknessId = SelectedThickness.Id;
            if (UpdateQuantity == null)
                UpdateQuantity = 0;
            workbench.Quantity = (int)Quantity + (int)UpdateQuantity;
            Quantity += UpdateQuantity;
            workbench.TotalLength = (double)SelectedLength.PanelLength / 1000 * (int)Quantity;
            workbench.UpdateTime = DateTime.Now;
            workbench.UpdateOperaterId = 1;

            return workbench;
        }

        private Panel EditExistingPanel(Panel panel)
        {
            panel.Name = Name;
            panel.TypeOfPanelId = SelectedTypeOfPanel.Id;
            panel.LengthId = SelectedLength.Id;
            panel.WidthId = SelectedWidth.Id;
            panel.ThicknessId = SelectedThickness.Id;
            if (UpdateQuantity == null)
                UpdateQuantity = 0;
            panel.Quantity = (int)Quantity + (int)UpdateQuantity;
            Quantity += UpdateQuantity;
            panel.PanelSurface = Math.Round(((double)SelectedLength.PanelLength / 1000 * SelectedWidth.PanelWidth / 1000), 2);
            panel.SurfaceInTotal = Math.Round(((double)SelectedLength.PanelLength / 1000 * SelectedWidth.PanelWidth / 1000 * (int)Quantity), 2);
            panel.UpdateTime = DateTime.Now;
            panel.UpdateOperaterId = 1;

            return panel;
        }

        private void executeCreateNewCommand()
        {
            if (!IsEmptyFields())
            {
                if (SelectedTypeOfPanel.PanelType == "Radna Ploca")
                {
                    Workbench = CreateWorkbench();
                    TotalLength = Workbench.TotalLength.ToString();

                    CreateNewWorkbench?.Invoke(this, new WorkbenchEventArgs(Workbench));
                }
                else
                {
                    Panel = CreatePanel();
                    PanelSurface = Math.Round(Panel.PanelSurface, 2).ToString();
                    SurfaceInTotal = Math.Round(Panel.SurfaceInTotal, 2).ToString();

                    CreateNewPanel?.Invoke(this, new PanelEventArgs(Panel));
                }
                UpdateVisible = true;
                //NewVisible = false;
            }
        }

        internal bool IsExistPanelOrWorkbench()
        {
            if (SelectedTypeOfPanel.PanelType == "Radna Ploca")
                return Broker.Instance.Context.Workbenchs.Any(x => x.Name == Name);
            else if (SelectedTypeOfPanel.PanelType != "Radna Ploca")
                return Broker.Instance.Context.Panels.Any(x => x.Name == Name);
            return false;
        }

        private Workbench CreateWorkbench()
        {
            return new Workbench()
            {
                Name = Name,
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                LengthId = SelectedLength.Id,

                WidthId = SelectedWidth.Id,

                Quantity = (int)Quantity,

                TotalLength = (double)SelectedLength.PanelLength / 1000 * (int)Quantity,

                ThicknessId = SelectedThickness.Id,

                TypeOfPanelId = SelectedTypeOfPanel.Id,

                OperaterId = 1,

                UpdateOperaterId = 1
            };
        }

        private Panel CreatePanel()
        {
            return new Panel()
            {
                Name = Name,
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                LengthId = SelectedLength.Id,

                WidthId = SelectedWidth.Id,

                PanelSurface = Math.Round(((double)SelectedLength.PanelLength / 1000 * SelectedWidth.PanelWidth / 1000), 2),

                Quantity = (int)Quantity,
                SurfaceInTotal = Math.Round(((double)SelectedLength.PanelLength / 1000 * SelectedWidth.PanelWidth / 1000 * (int)Quantity), 2),
                ThicknessId = SelectedThickness.Id,

                TypeOfPanelId = SelectedTypeOfPanel.Id,

                OperaterId = 1,

                UpdateOperaterId = 1
            };
        }

        private void executeGoBackCommand()
        {
            Succeeded?.Invoke(this, new EventArgs());
            ResetToDefault();
        }

        private void ResetToDefault()
        {
            Panel = null;
            Workbench = null;
            SelectedLength = null;
            SelectedThickness = null;
            SelectedWidth = null;
            SelectedTypeOfPanel = null;
            Name = null;
            Quantity = null;
            PanelSurface = null;
            SurfaceInTotal = null;
            UpdateQuantity = null;
            WorkbenchVisible = false;
            PanelVisible = false;
            IsEnabledDimensions = false;
        }

        private void SetPanel()
        {
            Name = Panel.Name;
            SelectedTypeOfPanel = Broker.Instance.Context.TypeOfPanels.Find(Panel.TypeOfPanel.Id);
            SelectedLength = Broker.Instance.Context.Lengths.Find(Panel.Length.Id);
            SelectedWidth = Broker.Instance.Context.Widths.Find(Panel.Width.Id);
            SelectedThickness = Broker.Instance.Context.Thicknesses.Find(Panel.Thickness.Id);
            Quantity = Panel.Quantity;
            PanelSurface = Math.Round(Panel.PanelSurface, 2).ToString();
            SurfaceInTotal = Math.Round(Panel.SurfaceInTotal, 2).ToString();
        }

        private void SetWorkbench()
        {
            Name = Workbench.Name;
            SelectedTypeOfPanel = Broker.Instance.Context.TypeOfPanels.Find(Workbench.TypeOfPanel.Id);
            SelectedLength = Broker.Instance.Context.Lengths.Find(Workbench.Length.Id);
            SelectedWidth = Broker.Instance.Context.Widths.Find(Workbench.Width.Id);
            SelectedThickness = Broker.Instance.Context.Thicknesses.Find(Workbench.Thickness.Id);
            Quantity = Workbench.Quantity;
            TotalLength = Workbench.TotalLength.ToString();
        }

        private bool IsEmptyFields()
        {
            if (Name == string.Empty)
                return true;
            else if (SelectedLength.Id < 1)
                return true;
            else if (SelectedLength.Id < 1)
                return true;
            else if (SelectedWidth.Id < 1)
                return true;
            else if (SelectedThickness.Id < 1)
                return true;
            else if (Quantity < 1 || Quantity == null)
                return true;
            return false;
        }

        public void Start(HomeViewModelResultType result)
        {
            if (Panel != null)
                SetPanel();
            else if (Workbench != null)
                SetWorkbench();

            _result = result;
            if (_result == HomeViewModelResultType.AddNew)
            {
                IsEnabledDimensions = false;
                Caption = $"Додавање новог материјала";
                NewVisible = true;
                UpdateVisible = false;
                IsEnabledQuantity = true;
                UpdateQuantityVisible = false;
                TypeIsEnabled = true;
            }
            else if (_result == HomeViewModelResultType.EditExisting)
            {
                TypeIsEnabled = false;
                Caption = $"Ажурирање постојећег материјала";
                UpdateVisible = true;
                NewVisible = false;
                IsEnabledQuantity = false;
                UpdateQuantityVisible = true;
                if (SelectedTypeOfPanel.PanelType == "Radna Ploca")
                {
                    WorkbenchVisible = true;
                    PanelVisible = false;
                }
                else
                {
                    WorkbenchVisible = false;
                    PanelVisible = true;
                }
            }
            Started?.Invoke(this, new EventArgs());
        }
    }
}
