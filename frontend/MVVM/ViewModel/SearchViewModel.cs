using frontend.Core;
using frontend.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace frontend.MVVM.ViewModel
{
    internal class SearchViewModel : INotifyPropertyChanged
    {
        private string _selectedImagePath;
        private string _resultText;
        private BitmapImage _resultImage;
        private readonly FingerprintProcessor _fingerprintProcessor;

        public ICommand BrowseCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public BitmapImage ResultImage
        {
            get => _resultImage;
            set
            {
                _resultImage = value;
                OnPropertyChanged(nameof(ResultImage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SearchViewModel()
        {
            BrowseCommand = new RelayCommand(BrowseImage);
            SearchCommand = new RelayCommand(SearchFingerprint);
            _fingerprintProcessor = new FingerprintProcessor();
        }

        private void BrowseImage(object parameter)
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
            ResultImage = bitmap;
        }

        private void SearchFingerprint(object parameter)
        {
            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                ResultText = "Please select a fingerprint image first.";
                return;
            }

            var result = _fingerprintProcessor.RunFingerprintComparison(_selectedImagePath);

            ResultText = $"Yang paling mirip adalah {result.name} dengan Tingkat kemiripan {result.similarity}%";
            DisplayResultImage(result.pathAns); // Assuming you want to display the input image as the result
        }

        private void DisplayResultImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            ResultImage = bitmap;
        }
    }
}
