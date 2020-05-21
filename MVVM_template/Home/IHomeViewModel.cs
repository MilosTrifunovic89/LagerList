﻿using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Edit;
using System;
using System.Collections.ObjectModel;

namespace LagerLista.Home
{
    public interface IHomeViewModel : IViewModel
    {
        ObservableCollection<Panel> LagerList { get; set; }

        event EventHandler Started;
        event EventHandler AddNewMaterial;
        event EventHandler<PanelEventArgs> EditSelectedMaterial;
        event EventHandler<PanelEventArgs> DeleteMaterial;

        void Start();
    }
}