using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Edit;
using System;
using System.Collections.ObjectModel;

namespace LagerLista.Home
{
    public interface IHomeViewModel : IViewModel
    {
        ObservableCollection<Panel> LagerList { get; set; }
        ObservableCollection<Workbench> Workbenches { get; set; }

        event EventHandler Started;
        event EventHandler AddNewMaterial;
        event EventHandler<PanelEventArgs> EditSelectedPanel;
        event EventHandler<WorkbenchEventArgs> EditSelectedWorkbench;
        event EventHandler<PanelEventArgs> DeleteMaterial;

        void Start();
    }
}
