using System;
using System.Collections.Generic;
using System.Drawing;
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
using Microsoft.Win32;

namespace NetNinjaApp.View
{
    /// <summary>
    /// Interaction logic for NinjaCreateWindow.xaml
    /// </summary>
    public partial class NinjaCreateWindow : Window
    {
        public NinjaCreateWindow()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                var tempImage = new BitmapImage();
                tempImage.BeginInit();
                tempImage.UriSource = new Uri(op.FileName);
                tempImage.DecodePixelHeight = 150;
                tempImage.DecodePixelWidth = 150;
                tempImage.EndInit();

                Image.Source = tempImage;

            }
        }
    }
}
