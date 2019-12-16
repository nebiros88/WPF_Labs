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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_5_Graphic_redactor_Korbut
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [Serializable]
    public class PolyLineData {
        public List<Shape> Figures = new List<Shape>();
    }

    [Serializable]
    public class Data
    {
        public static double Line_thickness { get; set; }
        public static Color Fill_color { get; set; }
        public static Color Line_color { get; set; }
    }
    
   
    public partial class MainWindow : Window
    {
        PolyLineData dataStorage = new PolyLineData();
        Data data = new Data();

        public static readonly DependencyProperty MyTitlePropery = DependencyProperty.Register("MyTitle", typeof(string), typeof(MainWindow), new UIPropertyMetadata("Place for loaded fie name"));

        public string MyTitle {
            get {
                return (string)GetValue(MainWindow.MyTitlePropery);
            }
            set {
                SetValue(MyTitlePropery, value);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by Korbut Sergey BSUIR group-80331 in 2019");
        }

        private void Canvas_mouse_move(object sender, MouseEventArgs e)                     // get mouse coordinates 
        {                                                                               
            Point mousePosition = e.GetPosition(Canvas);
            Mouse_coordianates.Text = $"({mousePosition.X}) : ({mousePosition.Y})";
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)                // Create figure by mouse click
        {
            Point mousePosition = e.GetPosition(Canvas);
            Polyline myPolyline = new Polyline();
            myPolyline.Stroke = new SolidColorBrush(Data.Line_color);
            myPolyline.StrokeThickness = Data.Line_thickness;
            myPolyline.Fill = new SolidColorBrush(Data.Fill_color);
            Point point1 = new Point(mousePosition.X, mousePosition.Y);
            Point point2 = new Point(mousePosition.X + 150, mousePosition.Y);
            Point point3 = new Point(mousePosition.X + 125, mousePosition.Y + 80);
            Point point4 = new Point(mousePosition.X + 25, mousePosition.Y + 80);
            Point point5 = new Point(mousePosition.X, mousePosition.Y);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(point1);
            myPointCollection.Add(point2);
            myPointCollection.Add(point3);
            myPointCollection.Add(point4);
            myPointCollection.Add(point5);
            myPolyline.Points = myPointCollection;
            Shape myShape = new Shape();
            foreach (var point in myPointCollection)
            {
                myShape.MyPoints.Add(point.ToString());
            }
            myShape.Line_thickness = Data.Line_thickness;
            myShape.Fill_color = Data.Fill_color.ToString();
            myShape.Line_color = Data.Line_color.ToString();
            Canvas.Children.Add(myPolyline);
            dataStorage.Figures.Add(myShape);
            
        }

        private void MenuItem_Clear_Click(object sender, RoutedEventArgs e)                 // clear canvas
        {
            Canvas.Children.Clear();
        }

        private void MenuItem_Fill_color_Click(object sender, RoutedEventArgs e)            // after click we need to create new window with color changer!!!!
        {
            ColorWindow colorChoice = new ColorWindow();
            colorChoice.Owner = this;
            colorChoice.ShowDialog();
        }

        private void MenuItem_LineThickness_Click(object sender, RoutedEventArgs e)         // window for line thickness choice
        {
            ThicknessWindow thicknessChoice = new ThicknessWindow();
            thicknessChoice.Owner = this;
            thicknessChoice.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)                       // window for line color choice
        {
            LineColorWindow lineColorChoice = new LineColorWindow();
            lineColorChoice.Owner = this;
            lineColorChoice.ShowDialog();
        }

        private void MenuItem_SaveFile_Click(object sender, RoutedEventArgs e)            // file saving dialog window
        {
            if (Canvas.Children.Capacity == 0)
            {
                MessageBox.Show("Saved file can't be empty! Make some shapes and try again.");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Файлы (dat)|*.dat|Все файлы|*.*";
                var result = sfd.ShowDialog();
                if (result == true)
                {
                    string fileName = sfd.FileName;
                    FileStream fs = new FileStream(fileName, FileMode.Create);
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        formatter.Serialize(fs, dataStorage.Figures);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Failed to serialize. Reason " + exc.Message);
                    }
                    fs.Close();
                }
            }
        }

        private void MenuItem_OpenFile_Click(object sender, RoutedEventArgs e)              // open file window
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы (dat)|*.dat|Все файлы|*.*";
            var result = ofd.ShowDialog();
            if (result == true) {
                Canvas.Children.Clear();
                string fileName = ofd.FileName;
                MyTitle = fileName;
                FileStream fs = new FileStream(fileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Shape> shapeStorage = new List<Shape>();
                shapeStorage = bf.Deserialize(fs) as List<Shape>;
                foreach (var item in shapeStorage)
                {
                    Polyline newPolyline = new Polyline();
                    PointCollection pointsCollection = new PointCollection();
                    foreach (var point in item.MyPoints)
                    {
                        string[] coords = point.Split(';');
                        Point myPoint = new Point();
                        myPoint.X = double.Parse(coords[0]);
                        myPoint.Y = double.Parse(coords[1]);
                        pointsCollection.Add(myPoint);
                    }
                    newPolyline.Points = pointsCollection;
                    newPolyline.Stroke = new SolidColorBrush(GetColorFromString(item.Line_color));
                    newPolyline.Fill = new SolidColorBrush(GetColorFromString(item.Fill_color));
                    newPolyline.StrokeThickness = item.Line_thickness;
                    Canvas.Children.Add(newPolyline);
                }
                fs.Close();
            }
        }

        private Color GetColorFromString(string str)                                   
        {  
            Color newColor = (Color)ColorConverter.ConvertFromString(str);
            return newColor;
        }
    }
}
