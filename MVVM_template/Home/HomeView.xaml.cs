using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LagerLista.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void OnUpdateMaterialButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is HomeViewModel homeViewModel)
            {
                if (homeViewModel.SelectedMaterial == null && homeViewModel.SelectedWorkbench == null)
                {
                    MessageBox.Show("Најпре одабери материјал који мењаш", "Порука", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                else
                    homeViewModel.EditSelectedMaterialCommand.Execute(null);
            }
        }

        private void OnDeleteMaterialButtonClick_Event(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is HomeViewModel homeViewModel)
            {
                if (homeViewModel.SelectedMaterial == null)
                {
                    MessageBox.Show("Најпре одабери материјал који бришеш", "Порука", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Да ли желите да избришете изабрани материјал?", "Порука", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    homeViewModel.DeleteSelectedMaterialCommand.Execute(null);
            }
        }

        private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                if (scroll.VerticalOffset - e.Delta <= scroll.ExtentHeight - scroll.ViewportHeight)
                {
                    scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
                }
                else
                {
                    scroll.ScrollToBottom();
                }
            }
            else
            {
                if (scroll.VerticalOffset + e.Delta > 0)
                {
                    scroll.ScrollToVerticalOffset(scroll.VerticalOffset - e.Delta);
                }
                else
                {
                    scroll.ScrollToTop();
                }
            }
            e.Handled = true;
        }
    }
}
