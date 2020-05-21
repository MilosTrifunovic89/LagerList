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

namespace LagerLista.Edit
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is EditViewModel editViewModel)
            {
                if (editViewModel.IsLessThenZero())
                    MessageBox.Show("Крајње стање не може бити мање од 0", "Порука", MessageBoxButton.OK);
                else
                    editViewModel.UpdateCommand.Execute(null);
            }
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]-$");
            return reg.IsMatch(str);
        }
    }
}
