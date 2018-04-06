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
using Task1.BLL.Services;

namespace Task1.WpfCoordinates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Coordinate> _coordinates;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _coordinates = new List<Coordinate>();


            if (!string.IsNullOrEmpty(textBox.Text))
            {
                _coordinates.Add(Coordinate.Parse(textBox.Text));

                ClearTextBox();

                Display();
            }
        }

        private void ClearTextBox()
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "";
            }
        }

        private void Display()
        {
            listBox.Items.Clear();

            foreach (var coordinate in _coordinates)
            {
                listBox.Items.Add(coordinate);
            }
        }

        private void binaryWR_Click(object sender, RoutedEventArgs e)
        {
            _coordinates = ReaderWriter.CoordinatesFromFile();

                ReaderWriter.CoordinateBenaryWriter(_coordinates);

                _coordinates = ReaderWriter.CoordinateBinaryReader();

                listBox.Items.Clear();

                Display();
        }

        private void ReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            _coordinates = ReaderWriter.CoordinatesFromFile();

            listBox.Items.Clear();

            Display();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
