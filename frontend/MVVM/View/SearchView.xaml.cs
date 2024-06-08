using Microsoft.Win32;
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
using frontend.Services;


namespace frontend.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        private string _selectedImagePath;

        public SearchView()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;
                DisplaySelectedImage(_selectedImagePath);
            }
        }

        private void DisplaySelectedImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            imagePicture.Source = bitmap;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (BMButton.IsChecked == true)
            {
                RunBMAlgorithm();
            }
            else
            {
                MessageBox.Show("Please select an algorithm.");
            }
        }

        private void RunBMAlgorithm()
        {
            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                MessageBox.Show("Please select a fingerprint image first.");
                return;
            }

            FingerprintProcessor processor = new FingerprintProcessor();
            var result = processor.RunFingerprintComparison(_selectedImagePath);

            ResultsTextBlock.Text = $"Yang paling mirip adalah {result.name} dengan Tingkat kemiripan {result.similarity}%";
            DisplayResultImage(result.pathAns); // Display the input image or any result image as needed
        }

        private void DisplayResultImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            ResultImage.Source = bitmap;
        }
    }
}



