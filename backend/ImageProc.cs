using System;
using System.Drawing;
using System.IO;
using System.Text;

public class ImageProc
{
    public string ProcessImageP(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"File not found: {filePath}");
        }

        string fileName = Path.GetFileName(filePath);
        Console.WriteLine($"File Name: {fileName}");

        Bitmap image = new Bitmap(filePath);
        int width = image.Width;
        int height = image.Height;
        int middleRow = height / 2; // Baris tengah gambar

        // Mengambil 32 pixel sejajar pada baris tengah gambar
        int[] binaryData = new int[32];
        for (int i = 0; i < 32; i++)
        {
            Color pixel = image.GetPixel(i, middleRow);
            binaryData[i] = (pixel.R + pixel.G + pixel.B) / 3;
        }

        // Konversi nilai pixel menjadi biner
        StringBuilder binaryString = new StringBuilder();
        foreach (int pixelValue in binaryData)
        {
            binaryString.Append((pixelValue > 127) ? "1" : "0");
        }

        string binaryDataString = binaryString.ToString();
        Console.WriteLine($"Binary Data: {binaryDataString}");

        // Konversi biner ke ASCII
        string asciiString = BinaryStringToAscii(binaryDataString);
        Console.WriteLine($"ASCII Data: {asciiString}");

        return asciiString;
    }

    private string BinaryStringToAscii(string binaryString)
    {
        if (binaryString.Length % 8 != 0)
        {
            throw new ArgumentException("The binary string length must be a multiple of 8.");
        }

        StringBuilder asciiString = new StringBuilder();

        for (int i = 0; i < binaryString.Length; i += 8)
        {
            string byteString = binaryString.Substring(i, 8);
            byte asciiValue = Convert.ToByte(byteString, 2);
            asciiString.Append((char)asciiValue);
        }

        return asciiString.ToString();
    }

    public string ProcessImageT(string filePath){
        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"File not found: {filePath}");
        }

        string fileName = Path.GetFileName(filePath);
        Console.WriteLine($"File Name: {fileName}");

        Bitmap image = new Bitmap(filePath);
        int width = image.Width;
        int height = image.Height;

        int[] binaryData = new int[width*height];
        for (int i = 0; i < height;i++) {

            for (int j = 0; j < width; j++)
            {
                Color pixel = image.GetPixel(j, i);
                binaryData[i* width + j] = (pixel.R + pixel.G + pixel.B) / 3;
            }
        }

        // Konversi nilai pixel menjadi biner
        StringBuilder binaryString = new StringBuilder();
        foreach (int pixelValue in binaryData)
        {
            binaryString.Append((pixelValue > 127) ? "1" : "0");
        }

        string binaryDataString = binaryString.ToString();
        // Console.WriteLine($"Binary Data: {binaryDataString}");


        // Pastikan panjang binaryDataString adalah kelipatan 8
        int length = binaryDataString.Length;
        if (length % 8 != 0)
        {
            int newLength = length - (length % 8);
            binaryDataString = binaryDataString.Substring(0, newLength);
        }
        // Console.WriteLine($"Binary Data (trimmed): {binaryDataString}");

        // Konversi biner ke ASCII
        string asciiString = BinaryStringToAscii(binaryDataString);
        // Console.WriteLine($"ASCII Data: {asciiString}");

        return asciiString;
    }

}
