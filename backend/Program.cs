using TUBES3_CPAGAR;
class Program
{
   static void Main(string[] args){
        DB db = new DB();
        db.readDB();
        string fileName = ".\\sidiks\\3.BMP";
        string pathAns = Function.Find(fileName);
        Console.WriteLine($"path nya= {pathAns}");
    }
}

// // // db.readDB();

// // // string text = ip.ProcessImageT("./sidiks/10.BMP");
// // // db.InsertSidikJariData(text, "sidik10");

// // // List<(string, string)> sidikJariData = db.GetSidikJariDataList();

// // // // Check if there's any data returned
// // // if (sidikJariData.Count > 0)
// // // {
// // //     Console.WriteLine("Sidik Jari Data:");
// // //     Console.WriteLine("-----------------");

// // //     // Iterate over the list of tuples and display each pair
// // //     foreach ((string nama, string berkasCitra) in sidikJariData)
// // //     {
// // //         Console.WriteLine($"Nama: {nama}");
// // //     }
// // // }
// // // else
// // // {
// // //     Console.WriteLine("No Sidik Jari data found.");
// // // }

// // // Console.ReadLine();