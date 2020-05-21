using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Home;
using System;

namespace LagerLista.Edit
{
    public interface IEditViewModel : IViewModel
    {
        Panel Panel { get; set; }

        event EventHandler Started;
        event EventHandler Succeeded;
        event EventHandler<PanelEventArgs> CreateNew;
        event EventHandler<PanelEventArgs> Update;

        void Start(HomeViewModelResultType result);
    }
}
