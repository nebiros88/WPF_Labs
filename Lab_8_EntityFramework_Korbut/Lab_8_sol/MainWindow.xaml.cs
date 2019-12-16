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
using System.Data.Entity;

namespace Lab_8_sol
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProviderContext db;
        public MainWindow()
        {
            InitializeComponent();

            UpdateData();
            this.Closing += MainWindow_Closing;

        }

        public void UpdateData() {
            db = new ProviderContext();
            db.Providers.Load();
            providersGrid.ItemsSource = db.Providers.Local.ToBindingList();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            db.Dispose();
        }

        private void providersGrid_LoadingRow(object sender, DataGridRowEventArgs e) {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProviderCreation pcWindow = new ProviderCreation();
            var result = pcWindow.ShowDialog();
            if (result == false)
            {
                pcWindow.Close();
            }
            else {
                try
                {
                    Provider newProvider = new Provider();
                    newProvider.Name = pcWindow.tbName.Text;
                    newProvider.Power = int.Parse(pcWindow.tbPower.Text);
                    newProvider.Subscribers = int.Parse(pcWindow.tbSubscribers.Text);
                    db.Providers.Add(newProvider);
                    db.SaveChanges();
                    MessageBox.Show("New provider was successfully created");
                }
                catch (Exception ex) {
                    MessageBox.Show($"Not successfully! Reason is: -{ex.Message}");
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (providersGrid.SelectedIndex > -1)
            {
                ProviderCreation editWindow = new ProviderCreation(); 
                Provider editProvider = providersGrid.SelectedItem as Provider;
                editWindow.tbName.Text = editProvider.Name;
                editWindow.tbPower.Text = editProvider.Power.ToString();
                editWindow.tbSubscribers.Text = editProvider.Subscribers.ToString();
                var result = editWindow.ShowDialog();
                if (result == false)
                {
                    editWindow.Close();
                }
                else
                {
                    try
                    {
                        Provider provider = db.Providers.Find(editProvider.Id);
                        provider.Name = editWindow.tbName.Text;
                        provider.Power = int.Parse(editWindow.tbPower.Text.ToString());
                        provider.Subscribers = int.Parse(editWindow.tbSubscribers.Text.ToString());
                        db.SaveChanges();
                        UpdateData();
                        MessageBox.Show("The data was successfully changed!");
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Not successfully! Reason is: -{ex.Message}");
                    }
                }
            }
            else {
                MessageBox.Show("No selected row!");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (providersGrid.SelectedIndex > -1) {
                var result = MessageBox.Show("Are you sure?", "Delete this data?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) {
                    Provider delProvider = providersGrid.SelectedItem as Provider;
                    db.Providers.Remove(delProvider);
                    db.SaveChanges();
                    UpdateData();
                    MessageBox.Show("The provider was successfully deleted");
                }
            }
            else
            {
                MessageBox.Show("No selected row!");
            }
        }
    }
}
