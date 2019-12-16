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
    /// Логика взаимодействия для LineColorWindow.xaml
    /// </summary>
    public partial class LineColorWindow : Window
    {
        public LineColorWindow()
        {
            InitializeComponent();
        }

        private void Button_Apply_Click(object sender, RoutedEventArgs e)
        {
            Data.Line_color = Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value);
            this.Close();
        }
    }
}
