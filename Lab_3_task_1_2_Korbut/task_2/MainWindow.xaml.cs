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
using System.Collections.ObjectModel;   // подключили коллекцию 
using System.IO;                        // для работы с файлами

namespace task_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Staff staff = new Staff();
        ObservableCollection<string> staffs;
        public ObservableCollection<string> cities;
        public ObservableCollection<string> streets;
        public ObservableCollection<string> positions;
        string path = @"C:\Users\Korbut\Documents\BSUIR\Корбут\СВПП_Вариант_10_Корбут_80331\Lab_3_task_1_2_Korbut\StaffInfo.txt";



        public MainWindow()
        {
            InitializeComponent();
            File.Create(path);                  // Создание файла (каждый запуск программы - новый файл)
            staffs = new ObservableCollection<string>();
            cities = new ObservableCollection<string> { "Minsk", "Grodno", "Vitebsk",};
            streets = new ObservableCollection<string> { "Lenina", "Sovetskaya", "Internacionalnaya"};
            positions = new ObservableCollection<string> { "Manager", "Seller", "Staff"};
            grid.DataContext = staff;           // привязка обьекта класса Staff  к Grid
            lStaffs.DataContext = staffs;       // привязка коллекции к Listbox
            lStaffs.ItemsSource = staffs;
            City.ItemsSource = cities;          // привязка коллекции к Combobox (города)
            Street.ItemsSource = streets;       // --//--
            Position.ItemsSource = positions;   // --//--

        }

        private void Clear_Click(object sender, RoutedEventArgs e)  // очистка заполняемых форм
        {
            Fname.Clear();
            Lname.Clear();
            Sallary.Clear();
            Home.Clear();
            City.SelectedItem = null;
            Street.SelectedItem = null;
            Position.SelectedItem = null;
        }

        private void CreateStaff_Click(object sender, RoutedEventArgs e) // создание нового работника с записью в текстовый файл
        {
            Staff newStaff = new Staff();
            newStaff.fName = Fname.Text.ToString();
            newStaff.lName = Lname.Text.ToString();
            newStaff.sallary = int.Parse(Sallary.Text); 
            newStaff.city = City.Text.ToString();
            newStaff.street = Street.Text.ToString();
            newStaff.home = Home.Text.ToString();
            newStaff.position = Position.Text.ToString();
            if (Fname.Text == "" || Lname.Text == "" || City.Text == "" || Street.Text == "" || Home.Text == "" || Sallary.Text == "" || Position.Text == "")
            {
                MessageBox.Show("Check all your forms (null enable)!");
            }
            else if (!CheckCollection(newStaff.city, newStaff.street, newStaff.position))
            {
                City.SelectedItem = null;
                Street.SelectedItem = null;
                Position.SelectedItem = null;
                MessageBox.Show("Check the name of city, street, position. Unknown name of one of them. Create new!");
            }
            else
            {
                newStaff.WriteToFile(path);
                MessageBox.Show("Staff was successfully created!");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e) // добавление нового города в коллекцию
        {
            string temp = tbAddCity.Text.ToString();
            bool conditionToAdd = true;
            foreach (string var in cities)
            {
                if (var == temp)
                {
                    MessageBox.Show("This city's name is already exists");
                    conditionToAdd = false;
                }
            }
            if (tbAddCity.Text == "")
            {
                MessageBox.Show("City's name can't be empty!");
            }
            else if (conditionToAdd)
            {
                cities.Add(temp);
                MessageBox.Show($"{temp} was successfully added.");
                tbAddCity.Clear();
            }
        }

        private void AddStreet_Click(object sender, RoutedEventArgs e) // добавление улицы в коллекцию
        {
            string temp = tbAddStreet.Text.ToString();
            bool conditionToAdd = true;
            foreach (string var in streets)
            {
                if (var == temp)
                {
                    MessageBox.Show("This streetэ's name is already exists");
                    conditionToAdd = false;
                }
            }
            if (tbAddStreet.Text == "")
            {
                MessageBox.Show("Street's name can't be empty!");
            }
            else if (conditionToAdd)
            {
                streets.Add(temp);
                MessageBox.Show($"{temp} was successfully added.");
                tbAddStreet.Clear();
            }
        }

        private void AddPosition_Click(object sender, RoutedEventArgs e) // добавление должности в коллекцию
        {
            string temp = tbAddPosition.Text.ToString();
            bool conditionToAdd = true;
            foreach (string var in positions)
            {
                if (var == temp)
                {
                    MessageBox.Show("This name of position is already exists");
                    conditionToAdd = false;
                }
            }
            if (tbAddPosition.Text == "")
            {
                MessageBox.Show("Name of position can't be empty!");
            }
            else if (conditionToAdd)
            {
                positions.Add(temp);
                MessageBox.Show($"{temp} was successfully added.");
                tbAddPosition.Clear();
            }
        }

        private void ShowList_Click(object sender, RoutedEventArgs e) // список работников из текстового файла
        {
            staffs.Clear();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    staffs.Add(line);
                }
            }
        }

        public bool CheckCollection(string cityName, string streetName, string positionName) // проверка на совпадение по коллекциям
        {
            bool result = false;
            int cityCheck = 0;
            int streetCheck = 0;
            int positionCheck = 0;
            foreach (string city in cities)
            {
                if (cityName == city)
                {
                    cityCheck = 1;
                }
            }
            foreach (string street in streets)
            {
                if (streetName == street)
                {
                    streetCheck = 1;
                }
            }
            foreach (string position in positions)
            {
                if (positionName == position)
                {
                    positionCheck = 1;
                }
            }
            if (cityCheck == 1 && streetCheck == 1 && positionCheck ==1)
            {
                result = true;
            }
            return result;
        }
    }
}
