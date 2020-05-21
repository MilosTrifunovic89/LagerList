using LagerLista.Common;
using LagerLista.Main;
using System.Windows;

namespace LagerLista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ServiceProvider.Instance.GetService(typeof(IMainViewModel));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Да ли желите да напустите апликацију", "ИЗЛАЗ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
