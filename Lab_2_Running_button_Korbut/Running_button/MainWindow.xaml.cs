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

namespace Running_button
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private string question = "Do you like your sallary?";

        public MainWindow()
        {
            InitializeComponent();
            Question.Text = question;                                // Задаем вопрос через textbox(вопрос в глобал переменной) texbox прозрачная
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)            // Выход по нажатию на клавишу соглашения
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(this);                  // координаты мыши
            double verticalArea = Negative.Height / 2 + 20;
            double horizontArea = Negative.Width / 2 + 20;
            Point leftTop = new Point(Negative.Margin.Left, Negative.Margin.Top);
            Point buttonCenter = new Point(Negative.Margin.Left + Negative.Width / 2, Negative.Margin.Top + Negative.Height / 2);
            if (mousePosition.Y > buttonCenter.Y - verticalArea && mousePosition.Y < leftTop.Y && (mousePosition.X > leftTop.X && mousePosition.X < leftTop.X + Negative.Width))
            {
                ChangePositionVerticaly(6);

            }
            else if (mousePosition.Y < buttonCenter.Y + verticalArea && mousePosition.Y > leftTop.Y + Negative.Height && (mousePosition.X > leftTop.X && mousePosition.X < leftTop.X + Negative.Width))
            {
                ChangePositionVerticaly(-6);
            }
            else if (mousePosition.X > buttonCenter.X - horizontArea && mousePosition.X < leftTop.X && (mousePosition.Y > leftTop.Y && mousePosition.Y < leftTop.Y + Negative.Height))
            {
                ChangePositionHorizontaly(6);
            }
            else if (mousePosition.X < buttonCenter.X + horizontArea && mousePosition.X > leftTop.X && (mousePosition.Y > leftTop.Y && mousePosition.Y < leftTop.Y + Negative.Height))
            {
                ChangePositionHorizontaly(-6);
            }
        }

        private void ChangePositionVerticaly(double value)
        {
            Point buttonPosition = Negative.TransformToAncestor(this).Transform(new Point(0, 0));
            if (buttonPosition.Y <= 0 && value < 0 || buttonPosition.Y + Negative.Height >= this.Height - 30 && value > 0)
            {
                double moveAmount = this.Width / 2 > buttonPosition.X ? 6:-6;
                
                ChangePositionHorizontaly(moveAmount);
            }
            else
            {
                Negative.Margin = new Thickness(Negative.Margin.Left, Negative.Margin.Top + value, Negative.Margin.Right, Negative.Margin.Bottom - value);
            }
        }

        private void ChangePositionHorizontaly(double value)
        {
            Point buttonPosition1 = Negative.TransformToAncestor(this).Transform(new Point(0, 0));
            if (buttonPosition1.X <= 0 && value < 0 || buttonPosition1.X + Negative.Width >= this.Width - 30 && value > 0)
            {
                double moveAmount = this.Height / 2 > buttonPosition1.Y ? 6 : -6;
                ChangePositionVerticaly(moveAmount);
            }
            else
            {
                Negative.Margin = new Thickness(Negative.Margin.Left + value, Negative.Margin.Top, Negative.Margin.Right - value, Negative.Margin.Bottom);
            }
        }
    }
}
