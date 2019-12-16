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
    [Serializable]
    public class Shape
    {
        public List<string> MyPoints = new List<string>();
        public double Line_thickness { get; set; }
        public string Fill_color { get; set; }
        public string Line_color { get; set; }

    }
}
