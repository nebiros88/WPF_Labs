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

namespace Lab_8_sol
{
    /// <summary>
    /// Логика взаимодействия для ProviderCreation.xaml
    /// </summary>
    public partial class ProviderCreation : Window
    {
        public ProviderCreation()
        {
            InitializeComponent();
        }

        private void Button_btOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
