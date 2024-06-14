using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data.Entity.Infrastructure.Design;

namespace MyWPF
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        private string _selectedImagePath;
        public SearchView()
        {
            InitializeComponent();
        }

        private string result;
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;
                string directoryName = System.IO.Path.GetDirectoryName(_selectedImagePath);
                string parentDirectory = System.IO.Directory.GetParent(directoryName).ToString();
                result = System.IO.Directory.GetParent(parentDirectory).ToString();
                DisplaySelectedImage(_selectedImagePath);
                // ResultsTextBlock.Text = result;
                setImagePath(_selectedImagePath);

            }
        }

        private void setImagePath(string imagepath)
        {
            _selectedImagePath = imagepath;
        }

        private void DisplaySelectedImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            imagePicture.Source = bitmap;
        }


        private void BMButton_Click(object sender, RoutedEventArgs e)
        {
            double startTime = System.Environment.TickCount;
            DB db = new DB();
            db.readDB();
            

            ImageProc ip = new ImageProc();
            string pattern = ip.ProcessImageP(_selectedImagePath);
            Console.WriteLine($"pattern: {pattern}");

            List<(string, string)> sidikJariData = db.GetSidikJariDataList();

            double maxval = 0;
            string nameAns = "";
            string pathAns = "";

            List<(string, List<string>)> ans = new List<(string, List<string>)>();

            if (sidikJariData.Count > 0)
            {

                foreach ((string nama, string berkasCitra) in sidikJariData)
                {
                    double tmp = 0;


                    BM solver = new BM();
                    string text = ip.ProcessImageT(berkasCitra);
                    tmp = solver.solveBM(pattern, text);

                    if (tmp > maxval)
                    {
                        maxval = tmp;
                        nameAns = nama;
                        pathAns = berkasCitra;
                    }
                }

            }
            double endTime = System.Environment.TickCount;
            double timeElapsed = endTime - startTime;
            if (maxval < 0.75)
            {
                ResultsTextBlock.Text = "Sidik Jari Tidak Ditemukan!!!";
            }else{
                string anspath = result + "\\" + "MyWPF\\" + pathAns;
                DisplayResultImage(anspath);

                RegexFunction r = new RegexFunction();
                List<string> arrayBiodataHasil = r.FindBiodata(nameAns);

                if(arrayBiodataHasil.Count == 0){
                    ResultsTextBlock.Text = "Biodata Tidak Ditemukan!!!";
                }else{
                    ResultsTextBlock.Text = "Biodata ditemukan:\n" +
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
                        $"Kewarganegaraan: {arrayBiodataHasil[10]}\n";

                        TimeExec.Text = "Waktu Eksekusi: " + timeElapsed + " ms";

                }


            }

        
        }

        private void DisplayResultImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();
            OutputTextBlock.Source = bitmap;
        }

        private void KMPButton_Click(object sender, RoutedEventArgs e)
        {
            double startTime = System.Environment.TickCount;
            DB db = new DB();
            // db.readDB();

            ImageProc ip = new ImageProc();
            string pattern = ip.ProcessImageP(_selectedImagePath);
            Console.WriteLine($"pattern: {pattern}");

            List<(string, string)> sidikJariData = db.GetSidikJariDataList();

            double maxval = 0;
            string nameAns = "";
            string pathAns = "";

            List<(string, List<string>)> ans = new List<(string, List<string>)>();

            if (sidikJariData.Count > 0)
            {

                foreach ((string nama, string berkasCitra) in sidikJariData)
                {
                    double tmp = 0;


                    KMP solver = new KMP();
                    string text = ip.ProcessImageT(berkasCitra);
                    tmp = solver.solveKMP(pattern, text);

                    if (tmp > maxval)
                    {
                        maxval = tmp;
                        nameAns = nama;
                        pathAns = berkasCitra;
                    }
                }

            }
            double endTime = System.Environment.TickCount;
            double timeElapsed = endTime - startTime;
            if (maxval < 0.75)
            {
                ResultsTextBlock.Text = "Sidik Jari Tidak Ditemukan!!!";
            }
            else
            {
                string anspath = result + "\\" + "MyWPF\\" + pathAns;
                DisplayResultImage(anspath);

                RegexFunction r = new RegexFunction();
                List<string> arrayBiodataHasil = r.FindBiodata(nameAns);

                if (arrayBiodataHasil.Count == 0)
                {
                    ResultsTextBlock.Text = "Biodata Tidak Ditemukan!!!";
                }
                else
                {
                    ResultsTextBlock.Text = "Biodata ditemukan:\n" +
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
                        $"Kewarganegaraan: {arrayBiodataHasil[10]}" +
                        $"Waktu Eksekusi: {timeElapsed} ms";

                }


            }
        }
    }
}
