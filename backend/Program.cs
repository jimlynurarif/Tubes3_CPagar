using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceDirectory = @"C:\Users\Jimly\Documents\tubes3\Tubes3_CPagar\image";
        string binaryDirectory = @"C:\Users\Jimly\Documents\tubes3\Tubes3_CPagar\image_binary";
        string restoreDirectory = @"C:\Users\Jimly\Documents\tubes3\Tubes3_CPagar\binaryToBmp";

        try
        {
            // Membuat direktori untuk menyimpan file binary jika belum ada
            if (!Directory.Exists(binaryDirectory))
            {
                Directory.CreateDirectory(binaryDirectory);
            }

            // Membuat direktori untuk menyimpan hasil kembali ke gambar BMP jika belum ada
            if (!Directory.Exists(restoreDirectory))
            {
                Directory.CreateDirectory(restoreDirectory);
            }

            // Ambil semua file BMP di folder sumber
            string[] bmpFiles = Directory.GetFiles(sourceDirectory, "*.bmp");

            foreach (string bmpFile in bmpFiles)
            {
                // Membaca gambar dari file BMP
                Bitmap originalImage = ReadImage(bmpFile);

                // Simpan gambar ke dalam format binary
                string binaryFilePath = Path.Combine(binaryDirectory, Path.GetFileNameWithoutExtension(bmpFile) + ".bin");
                SaveImageToBinary(originalImage, binaryFilePath);

                Console.WriteLine($"Konversi {bmpFile} ke binary berhasil.");

                // Mengembalikan gambar dari format binary ke BMP
                string outputImagePath = Path.Combine(restoreDirectory, Path.GetFileName(bmpFile));
                BinaryToImage(binaryFilePath, outputImagePath);
            }

            Console.WriteLine("Proses selesai.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Terjadi kesalahan: " + ex.Message);
        }
    }

    static Bitmap ReadImage(string imagePath)
    {
        using (Bitmap originalImage = new Bitmap(imagePath))
        {
            return new Bitmap(originalImage);
        }
    }

    static void SaveImageToBinary(Bitmap image, string binaryPath)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = ms.ToArray();
            File.WriteAllBytes(binaryPath, imageBytes);
        }
    }

    static void BinaryToImage(string binaryPath, string imagePath)
    {
        byte[] binaryData = File.ReadAllBytes(binaryPath);
        File.WriteAllBytes(imagePath, binaryData);
    }
}
