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
using System.Windows.Shapes;

namespace PrimeiraAPP.View
{
    /// <summary>
    /// Interaction logic for wMenu.xaml
    /// </summary>
    public partial class wMenu : Window
    {
        public wMenu()
        {
            InitializeComponent();
        }

        private void miFornecedor_Click(object sender, RoutedEventArgs e)
        {
            Window fornecedor = new MainWindow();
            fornecedor.Show();
        }
    }
}
