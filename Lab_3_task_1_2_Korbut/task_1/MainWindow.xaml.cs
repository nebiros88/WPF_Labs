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

namespace task_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> results; // колекция для хранения результатов вычислений
        Values values;


        public MainWindow()
        {
           
            InitializeComponent();
            values = new Values();
            grid.DataContext = values;
            results = new ObservableCollection<string>();
            lResult.DataContext = results;
            lResult.ItemsSource = results;
            
        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            results.Clear();
            for (double i = values.XStart; i < values.XStop; i += values.Step)
            {
                string result;
                double summ = 0;
                double y = 0;
                for (int k = 0; k <= values.N; k++)
                {
                    summ += (Math.Cos(k * i)) / Factorial(k);
                }
                y = Math.Exp(Math.Cos(i)) * Math.Cos(Math.Sin(i));
                result = "S(x) = " + summ.ToString() + " Y(x) = "  + y.ToString();
                results.Add(result);
            }
        }

        private int Factorial(int val)
        {
            int res = 1;
            for (int i = val; i > 1; i--)
            {
                res *= i;
            }
            return res;
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            results.Clear();
        }
    }
}
