﻿using Domain;
using LagerLista.Base.ViewModel;
using LagerLista.Edit;
using LagerLista.Home;
using System;

namespace LagerLista.Main
{
    public class MainViewModel : ContainerViewModelBase, IMainViewModel
    {
        private IHomeViewModel _homeViewModel;
        private IEditViewModel _editViewModel;
        private LagerListContext _context;

        public MainViewModel(IHomeViewModel homeViewModel, IEditViewModel editViewModel)
        {
            _context = new LagerListContext();

            _homeViewModel = homeViewModel;
            _homeViewModel.Started += homeViewModel_Started;
            _homeViewModel.AddNewMaterial += homeViewModel_AddNewMaterial;
            _homeViewModel.EditSelectedMaterial += homeViewModel_EditSelectedMaterial;
            _homeViewModel.DeleteMaterial += homeViewModel_DeleteSelectedMaterial;

            _editViewModel = editViewModel;
            _editViewModel.Started += editViewModel_Started;
            _editViewModel.Succeeded += editViewModel_Succeeded;
            _editViewModel.CreateNew += editViewModel_CreateNew;
            _editViewModel.Update += editViewModel_Update;


            setHomePageCurrent();
        }

        #region EditViewModel
        private void editViewModel_Succeeded(object sender, EventArgs e)
        {
            _homeViewModel.Start();
            //CurrentViewModel = _homeViewModel;
        }

        private void editViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _editViewModel;
        }

        private void editViewModel_Update(object sender, PanelEventArgs e)
        {

        }

        private void editViewModel_CreateNew(object sender, PanelEventArgs e)
        {
            _context.Panels.Add(e.Panel);
            _context.SaveChanges();
            _homeViewModel.LagerList.Add(e.Panel);
        }
        #endregion

        #region HomeViewModel
        private void homeViewModel_DeleteSelectedMaterial(object sender, PanelEventArgs e)
        {
            var panel = _context.Panels.Find(e.Panel.Id);
            _context.Panels.Remove(panel);
            _context.SaveChanges();
            _homeViewModel.LagerList.Remove(e.Panel);
        }

        private void homeViewModel_EditSelectedMaterial(object sender, PanelEventArgs e)
        {
            _editViewModel.Panel = e.Panel;
            _editViewModel.Start(HomeViewModelResultType.EditExisting);
        }

        private void homeViewModel_AddNewMaterial(object sender, EventArgs e)
        {
            _editViewModel.Start(HomeViewModelResultType.AddNew);
        }

        private void homeViewModel_Started(object sender, EventArgs e)
        {
            CurrentViewModel = _homeViewModel;
        }
        #endregion
        private void setHomePageCurrent()
        {
            CurrentViewModel = null;
            _homeViewModel.Start();
        }
    }
}