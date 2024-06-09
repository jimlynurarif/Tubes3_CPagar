using System.Reflection;
using System.Text.RegularExpressions;

class Program
{
   static void Main(string[] args){
        // Runner r = new Runner();
        List<(string, List<string>)> s = Runner.solve("BM", "./sidiks/10.BMP");
        if(s.Count == 0){
            Console.WriteLine("Sidik Jari Tidak Ditemukan");
        }
        else{
            string imgPathHasil = s[0].Item1;
            List<string> biodataHasil = s[0].Item2;
            if (biodataHasil.Count != 0){
                Console.WriteLine($"imgPath hasil: {imgPathHasil}");
                Console.WriteLine("Biodata ditemukan:");
                Console.WriteLine($"NIK: {biodataHasil[0]}");
                Console.WriteLine($"Nama: {biodataHasil[1]}");
                Console.WriteLine($"Tempat Lahir: {biodataHasil[2]}");
                Console.WriteLine($"Tanggal Lahir: {biodataHasil[3]}");
                Console.WriteLine($"Jenis Kelamin: {biodataHasil[4]}");
                Console.WriteLine($"Golongan Darah: {biodataHasil[5]}");
                Console.WriteLine($"Alamat: {biodataHasil[6]}");
                Console.WriteLine($"Agama: {biodataHasil[7]}");
                Console.WriteLine($"Status Perkawinan: {biodataHasil[8]}");
                Console.WriteLine($"Pekerjaan: {biodataHasil[9]}");
                Console.WriteLine($"Kewarganegaraan: {biodataHasil[10]}");
            }
            else{
                Console.WriteLine("Biodata tidak ditemukan");
            }
        }
        
}
}

// db.readDB();

// string text = ip.ProcessImageT("./sidiks/10.BMP");
// db.InsertSidikJariData(text, "sidik10");

// List<(string, string)> sidikJariData = db.GetSidikJariDataList();

// // Check if there's any data returned
// if (sidikJariData.Count > 0)
// {
//     Console.WriteLine("Sidik Jari Data:");
//     Console.WriteLine("-----------------");

//     // Iterate over the list of tuples and display each pair
//     foreach ((string nama, string berkasCitra) in sidikJariData)
//     {
//         Console.WriteLine($"Nama: {nama}");
//     }
// }
// else
// {
//     Console.WriteLine("No Sidik Jari data found.");
// }

// Console.ReadLine();