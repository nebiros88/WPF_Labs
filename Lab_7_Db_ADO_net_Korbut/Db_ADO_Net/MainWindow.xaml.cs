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
using System.Collections.ObjectModel;


namespace Db_ADO_Net
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Provider> Providers;

        public MainWindow()
        {
            Providers = new ObservableCollection<Provider>();
            InitializeComponent();
            lBox.DataContext = Providers;
        }

        void FillData() {
            foreach (var provider in Provider.GetAllProviders())
            {
                Providers.Add(provider);
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e) {
            FillData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            var provider = new Provider()
            {
                Company_name = "New Energy Company",
                Number_of_staff = 200,
                Payroll = 1,
                Tax_free_id = 1
            };
            provider.Insert();
            FillData();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            var provider = (Provider)lBox.SelectedItem;
            provider.Company_name = "New Energy Company Changed";
            provider.Update();
            FillData();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e) {
            var id = ((Provider)lBox.SelectedItem).Energy_provider_Id;
            Provider.Delete(id);
            FillData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            while (lBox.Items.Count > 0) {
                Providers.Clear();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
