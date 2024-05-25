class Program
{
   static void Main(string[] args){
        DB db = new DB();
        
        ImageProc ip = new ImageProc();
        string pattern = ip.ProcessImageP("./sidiks/3.BMP");
        Console.WriteLine($"pattern: {pattern}");

        List<(string, string)> sidikJariData = db.GetSidikJariDataList();

        if (sidikJariData.Count > 0)
        {
            double maxval = 0;
            string nameAns = "";
            string pathAns = "";
            foreach ((string nama, string berkasCitra) in sidikJariData)
            {
                double tmp;

                //BM
                // BM solver = new BM();
                // string text = ip.ProcessImageT(berkasCitra);
                // tmp = solver.solveBM(pattern, text);

                // //KMP
                KMP solver = new KMP();
                string text = ip.ProcessImageT(berkasCitra);
                tmp = solver.solveKMP(pattern, text);

                if (tmp > maxval){
                    maxval = tmp;
                    nameAns = nama;
                    pathAns = berkasCitra;
                }
            }
            Console.WriteLine($"yang paling mirip adalah {nameAns} dengan Tingkat kemiripan  {maxval * 100}%");
            Console.WriteLine($"path = {pathAns}");
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