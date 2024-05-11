using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceDirectory = @"imageoriginal";
        string binaryDirectory = @"imageInBinary";
        string restoreDirectory = @"imageFromBinary";
        string asciiDirectory = @"C:\Users\Jimly\Documents\tubes3\Tubes3_CPagar\backend\ascii";

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

            // Membuat direktori untuk menyimpan hasil konversi ke ASCII jika belum ada
            if (!Directory.Exists(asciiDirectory))
            {
                Directory.CreateDirectory(asciiDirectory);
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

                // Konversi binary ke ASCII dan simpan ke file teks
                string asciiFilePath = Path.Combine(asciiDirectory, Path.GetFileNameWithoutExtension(binaryFilePath) + ".txt");
                ConvertBinaryToAscii(binaryFilePath, asciiFilePath);

                Console.WriteLine($"Konversi {binaryFilePath} ke ASCII berhasil. Hasil disimpan di {asciiFilePath}");
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

    static void ConvertBinaryToAscii(string binaryFilePath, string asciiFilePath)
    {
        byte[] binaryData = File.ReadAllBytes(binaryFilePath);

        // Membuat string builder untuk menyimpan karakter ASCII
        System.Text.StringBuilder asciiBuilder = new System.Text.StringBuilder();

        // Konversi setiap byte menjadi karakter ASCII
        foreach (byte b in binaryData)
        {
            char asciiChar = (char)b;
            asciiBuilder.Append(asciiChar);
        }

        // Menyimpan string ASCII ke file teks
        File.WriteAllText(asciiFilePath, asciiBuilder.ToString());
    }
}