class Program
{
   static void Main(string[] args){
        DB db = new DB();
        
        ImageProc ip = new ImageProc();
        string pattern = ip.ProcessImageP("./sidiks/10.BMP");
        Console.WriteLine($"pattern: {pattern}");

        List<(string, string)> sidikJariData = db.GetSidikJariDataList();

        if (sidikJariData.Count > 0)
        {
            double maxval = 0;
            string nameAns = "";
            foreach ((string nama, string berkasCitra) in sidikJariData)
            {
                double tmp;
                BM solver = new BM();
                tmp = solver.solveBM(pattern, berkasCitra);

                if (tmp > maxval){
                    maxval = tmp;
                    nameAns = nama;
                }
            }
            Console.WriteLine($"yang paling mirip adalah {nameAns} dengan Tingkat kemiripan  {maxval * 100}%");
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