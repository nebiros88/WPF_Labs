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

namespace Lab_5_Graphic_redactor_Korbut
{
    /// <summary>
    /// Логика взаимодействия для ThicknessWindow.xaml
    /// </summary>
    public partial class ThicknessWindow : Window
    {
        public ThicknessWindow()
        {
            InitializeComponent();
        }

        private void Button_Apply_Click(object sender, RoutedEventArgs e)
        {
            Data.Line_thickness = double.Parse(sliderValue.Value.ToString());
            this.Close();
        }
    }
}
