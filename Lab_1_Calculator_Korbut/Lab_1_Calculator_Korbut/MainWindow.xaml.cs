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

namespace Lab_1_Calculator_Korbut
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string lop;
        private string rop;
        private Func<double, double, double> op = null;
        private Func<double, double> op1 = null;

        const string Minus = "-";
        const string Summ = "+";
        const string Mult = "*";
        const string Devide = "/";
        const string Cos = "cos";
        const string Sin = "sin";
        const string Tan = "tan";
        const string Sqrt = "sqrt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_button_number(object sender, RoutedEventArgs e)      //Событие возникающие при нажатии на цифровую клавишу
        {
            Button b = (Button)sender;
            string val = b.Content.ToString();
            if (op == null)
            {
                lop += val;
            }
            else
            {
                rop += val;
            }
            Result_Screen.Text += val;      //Отображение на экране данных приведенных к строковому типу
        }

        private void Click_Button_Operator(object sender, RoutedEventArgs e)
        {
            if (op != null) Calculate();
            Result_Screen.Clear();
            Button b = (Button)sender;
            switch (b.Tag)
            {
                case Minus:
                    op = (l, r) => l - r;
                    break;
                case Summ:
                    op = (l, r) => l + r;
                    break;
                case Mult:
                    op = (l, r) => l * r;
                    break;
                case Devide:
                    op = (l, r) => l / r;
                    break;
            }
        }

        private void Click_Button_Operator1(object sender, RoutedEventArgs e)
        {
            Result_Screen.Clear();
            Button b = (Button)sender;
            double val = double.Parse(lop);
            switch (b.Tag)
            {
                case Cos:
                    op = (l, r) => Math.Cos(l / Math.PI * 180);
                    break;
                case Sin:
                    op = (l, r) => Math.Sin(l / Math.PI * 180);
                    break;
                case Tan:
                    op = (l, r) => Math.Tan(l / Math.PI * 180);
                    break;
                case Sqrt:
                    op = (l, r) =>
                    {
                        if (Is_positive(l))
                            return Math.Sqrt(l);
                        else throw new Exception("Error!");
                    };
                    break;
            }
        }

        private void Click_Button_Result(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Click_Button_Clear(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Result_Screen.Clear();
            op = null;
            op1 = null;
            lop = null;
            rop = null;
        }

        private bool Is_positive(double val)
        {
            return val > 0;
        }

        private void Calculate()
        {
            try
            {
                double lp = string.IsNullOrEmpty(lop) ? 0 : double.Parse(lop);
                double rp = string.IsNullOrEmpty(rop) ? 0 : double.Parse(rop);
                double result;
                if (op == null) return;
                result = op(lp, rp);
                lop = result.ToString();
                rop = null;
                Result_Screen.Text = result.ToString();
                op = null;
            }
            catch (Exception ex)
            {
                Result_Screen.Text = ex.Message;
            }
        }

        private void Button_Click_Off(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
