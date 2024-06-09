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
using System.ComponentModel;
using System.IO;
using TUBES3_CPAGAR;

namespace frontend.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class SearchView : UserControl, INotifyPropertyChanged
    {
        public SearchView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string pathAns;

        private string _selectedImagePath;

        private string _destinationPath;
        public string DestinationPath
        {
            get { return _destinationPath; }
            set
            {
                _destinationPath = value;
                OnPropertyChanged("DestinationPath");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                // Get the file name from the selected image path
                string fileName = System.IO.Path.GetFileName(_selectedImagePath);
                        
                // Define the destination path
                string destinationPath = System.IO.Path.Combine("C:\\Users\\Auralea A S\\Documents\\SEMESTER 4\\TEST3\\Tubes3_CPagar\\frontend\\MVVM\\input", fileName);
                        
                // Define the relative destination path
                string destinationRelativePath = System.IO.Path.Combine("input", fileName);
                        
                // Copy the image to the input folder
                System.IO.File.Copy(_selectedImagePath, destinationPath, true);

                // string pathAns = Function.Find(".\\sidiks\\3.BMP");

                // // string resultDestination = System.IO.Path.Combine("C:\\Users\\Auralea A S\\Documents\\SEMESTER 4\\TEST3\\Tubes3_CPagar\\frontend\\MVVM\\", pathAns);
            
                // OutputTextBlock.Text = pathAns;
                Runner r = new Runner();
                List<(string, List<string>)> s = r.solve("BM", destinationRelativePath);
                string imgPathHasil = s[0].Item1;
                List<string> arrayBiodataHasil = s[0].Item2;

                OutputTextBlock.Text = "Hasil pencarian: " + imgPathHasil;
                ResultsTextBlock.Text = $"imgPath hasil: {imgPathHasil}\n" +
                    "Biodata ditemukan:\n" +
                    $"NIK: {arrayBiodataHasil[0]}\n" +
                    $"Nama: {arrayBiodataHasil[1]}\n" +
                    $"Tempat Lahir: {arrayBiodataHasil[2]}\n" +
                    $"Tanggal Lahir: {arrayBiodataHasil[3]}\n" +
                    $"Jenis Kelamin: {arrayBiodataHasil[4]}\n" +
                    $"Golongan Darah: {arrayBiodataHasil[5]}\n" +
                    $"Alamat: {arrayBiodataHasil[6]}\n" +
                    $"Agama: {arrayBiodataHasil[7]}\n" +
                    $"Status Perkawinan: {arrayBiodataHasil[8]}\n" +
                    $"Pekerjaan: {arrayBiodataHasil[9]}\n" +
                    $"Kewarganegaraan: {arrayBiodataHasil[10]}";
            }
            else
            {
                MessageBox.Show("Please select an algorithm.");
            }
        }


        // private void RunBMAlgorithm(string imagepath)
        // {
        //     string pathAns = Function.Find(imagepath);
              

        //     string resultPath = System.IO.Path.GetFileName(pathAns);
            

        //     string resultDestination = System.IO.Path.Combine("C:\\Users\\Auralea A S\\Documents\\SEMESTER 4\\TEST3\\Tubes3_CPagar\\frontend\\MVVM\\", resultPath);
        

        //     DisplayResultImage(resultDestination);
        // }


        // private void RunBMAlgorithm(string imagepath)
        // {
        //     if (string.IsNullOrEmpty(imagepath))
        //     {
        //         MessageBox.Show("Please select a fingerprint image first.");
        //         return;
        //     }

        //     // FingerprintProcessor processor = new FingerprintProcessor();
        //     // var result = processor.RunFingerprintComparison(_selectedImagePath);
        //     DB db = new DB();
            
        //     ImageProc ip = new ImageProc();
        //     string pattern = "sidiks/3.BMP";
        //     Console.WriteLine($"pattern: {pattern}");

        //     List<(string, string)> sidikJariData = db.GetSidikJariDataList();

        //     if (sidikJariData.Count > 0)
        //     {
        //         double maxval = 0;
        //         string nameAns = "";
        //         string pathAns = "";
        //         foreach ((string nama, string berkasCitra) in sidikJariData)
        //         {
        //             double tmp;

        //             //BM
        //             BM solver = new BM();
        //             string text = ip.ProcessImageT(berkasCitra);
        //             tmp = solver.solveBM(pattern, text);

        //             // //KMP
        //             // KMP solver = new KMP();
        //             // string text = ip.ProcessImageT(berkasCitra);
        //             // tmp = solver.solveKMP(pattern, text);

        //             if (tmp > maxval){
        //                 maxval = tmp;
        //                 nameAns = nama;
        //                 _pathAns = berkasCitra;
        //             }
        //         }
        //         ResultsTextBlock.Text = $"yang paling mirip adalah {nameAns} dengan Tingkat kemiripan  {maxval * 100}%";
        //         string resultDestination = System.IO.Path.Combine("C:\\Users\\Auralea A S\\Documents\\SEMESTER 4\\TEST3\\Tubes3_CPagar\\frontend\\MVVM\\", _pathAns);

        //         DisplayResultImage(resultDestination);
        //     }else{
        //         MessageBox.Show("Database is empty");
        //     }
        //     // ResultsTextBlock.Text = $"Yang paling mirip adalah {result.name} dengan Tingkat kemiripan {result.similarity}%";
        //     // DisplayResultImage(result.pathAns); // Display the input image or any result image as needed
        // }

        private void DisplayResultImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            // ResultImage.Source = bitmap;
        }
    }
}