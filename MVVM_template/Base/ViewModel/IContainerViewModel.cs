﻿namespace LagerLista.Base.ViewModel
{
    public interface IContainerViewModel : IViewModel
    {
        IViewModel CurrentViewModel { get; }
    }
}
