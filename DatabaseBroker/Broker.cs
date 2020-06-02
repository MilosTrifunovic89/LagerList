using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBroker
{
    public class Broker
    {
        #region Fields
        private static Broker _instance;
        private LagerListContext context;

        public LagerListContext Context
        {
            get { return context; }
            set { context = value; }
        }

        #endregion

        #region Properties
        public static Broker Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Broker();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private Broker()
        {
            context = new LagerListContext();
        }
        #endregion

        #region Methods
        public ObservableCollection<Length> GetAllLengths()
        {
            ObservableCollection<Length> _lengths = new ObservableCollection<Length>();
            List<Length> listLengths = context.Lengths.ToList();

            foreach (var length in listLengths)
                _lengths.Add(length);

            return _lengths;
        }

        public ObservableCollection<Width> GetAllWidths()
        {
            ObservableCollection<Width> _widths = new ObservableCollection<Width>();
            List<Width> widths = context.Widths.ToList();

            foreach (var width in widths)
                _widths.Add(width);

            return _widths;
        }

        public ObservableCollection<Thickness> GetAllThicknesses()
        {
            ObservableCollection<Thickness> _thicknesses = new ObservableCollection<Thickness>();
            List<Thickness> thicknesses = context.Thicknesses.ToList();

            foreach (var thickness in thicknesses)
                _thicknesses.Add(thickness);

            return _thicknesses;
        }

        public ObservableCollection<TypeOfPanel> GetAllTypes()
        {
            ObservableCollection<TypeOfPanel> _types = new ObservableCollection<TypeOfPanel>();
            List<TypeOfPanel> types = context.TypeOfPanels.ToList();

            foreach (var type in types)
                _types.Add(type);

            return _types;
        }

        public ObservableCollection<Workbench> GetAllWorkbenches()
        {
            ObservableCollection<Workbench> allWorkbenches = new ObservableCollection<Workbench>();

            var workbenches = (from workbench in context.Workbenchs
                               join length in context.Lengths on workbench.LengthId equals length.Id
                               join width in context.Widths on workbench.WidthId equals width.Id
                               join thickness in context.Thicknesses on workbench.ThicknessId equals thickness.Id
                               join type in context.TypeOfPanels on workbench.TypeOfPanelId equals type.Id
                               join operater in context.Operaters on workbench.OperaterId equals operater.Id
                               join updateOperater in context.Operaters on workbench.UpdateOperaterId equals updateOperater.Id
                               select new
                               {
                                   id = workbench.Id,
                                   name = workbench.Name,
                                   length = workbench.Length,
                                   width = workbench.Width,
                                   thickness = workbench.Thickness,
                                   type = workbench.TypeOfPanel,
                                   operater = workbench.Operater,
                                   updateOperater = workbench.UpdateOperater,
                                   quantity = workbench.Quantity,
                                   insertTime = workbench.InsertTime,
                                   updateTime = workbench.UpdateTime,
                                   totalLength = workbench.TotalLength
                               }).ToList();

            foreach (var workbench in workbenches)
            {
                Workbench w = new Workbench()
                {
                    Name = workbench.name,
                    Quantity = workbench.quantity,
                    UpdateTime = workbench.updateTime,
                    Id = workbench.id,
                    InsertTime = workbench.insertTime,
                    Operater = workbench.operater,
                    UpdateOperater = workbench.updateOperater,
                    Length = workbench.length,
                    Thickness = workbench.thickness,
                    TypeOfPanel = workbench.type,
                    Width = workbench.width,
                    TotalLength = workbench.totalLength
                };

                allWorkbenches.Add(w);
            }

            return allWorkbenches;

        }

        public ObservableCollection<Panel> GetAllPanels()
        {
            ObservableCollection<Panel> lagerList = new ObservableCollection<Panel>();

            var panels = (from panel in context.Panels
                          join length in context.Lengths on panel.LengthId equals length.Id
                          join width in context.Widths on panel.WidthId equals width.Id
                          join thickness in context.Thicknesses on panel.ThicknessId equals thickness.Id
                          join type in context.TypeOfPanels on panel.TypeOfPanelId equals type.Id
                          join operater in context.Operaters on panel.OperaterId equals operater.Id
                          join updateOperater in context.Operaters on panel.UpdateOperaterId equals updateOperater.Id
                          select new
                          {
                              id = panel.Id,
                              name = panel.Name,
                              length = panel.Length,
                              width = panel.Width,
                              thickness = panel.Thickness,
                              type = panel.TypeOfPanel,
                              operater = panel.Operater,
                              updateOperater = panel.UpdateOperater,
                              quantity = panel.Quantity,
                              panelSurface = panel.PanelSurface,
                              surfaceInTotal = panel.SurfaceInTotal,
                              insertTime = panel.InsertTime,
                              updateTime = panel.UpdateTime,
                          }).ToList();

            foreach (var panel in panels)
            {
                Panel p = new Panel()
                {
                    Name = panel.name,
                    Quantity = panel.quantity,
                    UpdateTime = panel.updateTime,
                    Id = panel.id,
                    InsertTime = panel.insertTime,
                    Operater = panel.operater,
                    UpdateOperater = panel.updateOperater,
                    Length = panel.length,
                    PanelSurface = panel.panelSurface,
                    Thickness = panel.thickness,
                    TypeOfPanel = panel.type,
                    Width = panel.width,
                    SurfaceInTotal = panel.surfaceInTotal
                };
                lagerList.Add(p);
            }

            return lagerList;
        }

        public ObservableCollection<Panel> GetAllPanels(TypeOfPanel panelType)
        {
            ObservableCollection<Panel> lagerList = new ObservableCollection<Panel>();

            var panels = (from panel in context.Panels
                          join length in context.Lengths on panel.LengthId equals length.Id
                          join width in context.Widths on panel.WidthId equals width.Id
                          join thickness in context.Thicknesses on panel.ThicknessId equals thickness.Id
                          join type in context.TypeOfPanels on panel.TypeOfPanelId equals type.Id
                          join operater in context.Operaters on panel.OperaterId equals operater.Id
                          join updateOperater in context.Operaters on panel.UpdateOperaterId equals updateOperater.Id
                          where panel.TypeOfPanel.PanelType == panelType.PanelType
                          select new
                          {
                              id = panel.Id,
                              name = panel.Name,
                              length = panel.Length,
                              width = panel.Width,
                              thickness = panel.Thickness,
                              type = panel.TypeOfPanel,
                              operater = panel.Operater,
                              updateOperater = panel.UpdateOperater,
                              quantity = panel.Quantity,
                              panelSurface = panel.PanelSurface,
                              surfaceInTotal = panel.SurfaceInTotal,
                              insertTime = panel.InsertTime,
                              updateTime = panel.UpdateTime,
                          }).ToList();

            foreach (var panel in panels)
            {
                Panel p = new Panel()
                {
                    Name = panel.name,
                    Quantity = panel.quantity,
                    UpdateTime = panel.updateTime,
                    Id = panel.id,
                    InsertTime = panel.insertTime,
                    Operater = panel.operater,
                    UpdateOperater = panel.updateOperater,
                    Length = panel.length,
                    PanelSurface = panel.panelSurface,
                    Thickness = panel.thickness,
                    TypeOfPanel = panel.type,
                    Width = panel.width,
                    SurfaceInTotal = panel.surfaceInTotal
                };
                lagerList.Add(p);
            }

            return lagerList;
        }

        public ObservableCollection<Panel> GetAllPanels(string searchText)
        {
            ObservableCollection<Panel> lagerList = new ObservableCollection<Panel>();

            var panels = (from panel in context.Panels
                          join length in context.Lengths on panel.LengthId equals length.Id
                          join width in context.Widths on panel.WidthId equals width.Id
                          join thickness in context.Thicknesses on panel.ThicknessId equals thickness.Id
                          join type in context.TypeOfPanels on panel.TypeOfPanelId equals type.Id
                          join operater in context.Operaters on panel.OperaterId equals operater.Id
                          join updateOperater in context.Operaters on panel.UpdateOperaterId equals updateOperater.Id
                          //where panel.Name.Contains($"{searchText}")
                          //where panel.Name == $"%{searchText}%"
                          where panel.Name.Contains(searchText)
                          select new
                          {
                              id = panel.Id,
                              name = panel.Name,
                              length = panel.Length,
                              width = panel.Width,
                              thickness = panel.Thickness,
                              type = panel.TypeOfPanel,
                              operater = panel.Operater,
                              updateOperater = panel.UpdateOperater,
                              quantity = panel.Quantity,
                              panelSurface = panel.PanelSurface,
                              surfaceInTotal = panel.SurfaceInTotal,
                              insertTime = panel.InsertTime,
                              updateTime = panel.UpdateTime,
                          }).ToList();

            foreach (var panel in panels)
            {
                Panel p = new Panel()
                {
                    Name = panel.name,
                    Quantity = panel.quantity,
                    UpdateTime = panel.updateTime,
                    Id = panel.id,
                    InsertTime = panel.insertTime,
                    Operater = panel.operater,
                    UpdateOperater = panel.updateOperater,
                    Length = panel.length,
                    PanelSurface = panel.panelSurface,
                    Thickness = panel.thickness,
                    TypeOfPanel = panel.type,
                    Width = panel.width,
                    SurfaceInTotal = panel.surfaceInTotal
                };
                lagerList.Add(p);
            }

            return lagerList;
        }

        public ObservableCollection<Panel> GetAllPanels(TypeOfPanel panelType, string searchText)
        {
            ObservableCollection<Panel> lagerList = new ObservableCollection<Panel>();

            var panels = (from panel in context.Panels
                          join length in context.Lengths on panel.LengthId equals length.Id
                          join width in context.Widths on panel.WidthId equals width.Id
                          join thickness in context.Thicknesses on panel.ThicknessId equals thickness.Id
                          join type in context.TypeOfPanels on panel.TypeOfPanelId equals type.Id
                          join operater in context.Operaters on panel.OperaterId equals operater.Id
                          join updateOperater in context.Operaters on panel.UpdateOperaterId equals updateOperater.Id
                          where panel.Name.Contains(searchText) && panel.TypeOfPanel.PanelType == panelType.PanelType
                          select new
                          {
                              id = panel.Id,
                              name = panel.Name,
                              length = panel.Length,
                              width = panel.Width,
                              thickness = panel.Thickness,
                              type = panel.TypeOfPanel,
                              operater = panel.Operater,
                              updateOperater = panel.UpdateOperater,
                              quantity = panel.Quantity,
                              panelSurface = panel.PanelSurface,
                              surfaceInTotal = panel.SurfaceInTotal,
                              insertTime = panel.InsertTime,
                              updateTime = panel.UpdateTime,
                          }).ToList();

            foreach (var panel in panels)
            {
                Panel p = new Panel()
                {
                    Name = panel.name,
                    Quantity = panel.quantity,
                    UpdateTime = panel.updateTime,
                    Id = panel.id,
                    InsertTime = panel.insertTime,
                    Operater = panel.operater,
                    UpdateOperater = panel.updateOperater,
                    Length = panel.length,
                    PanelSurface = panel.panelSurface,
                    Thickness = panel.thickness,
                    TypeOfPanel = panel.type,
                    Width = panel.width,
                    SurfaceInTotal = panel.surfaceInTotal
                };
                lagerList.Add(p);
            }

            return lagerList;
        }
        #endregion
    }
}
