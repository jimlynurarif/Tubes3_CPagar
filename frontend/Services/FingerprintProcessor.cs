using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Services
{
    internal class FingerprintProcessor
    {
        private readonly DB db;
        private readonly ImageProc ip;

        public FingerprintProcessor()
        {
            db = new DB();
            ip = new ImageProc();
        }

        public (string name, string pathAns, double similarity) RunFingerprintComparison(string imagePath)
        {
            string pattern = ip.ProcessImageP(imagePath);
            Console.WriteLine($"pattern: {pattern}");

            List<(string, string)> sidikJariData = db.GetSidikJariDataList();
            if (sidikJariData.Count == 0)
            {
                Console.WriteLine("No data in the database."); // Added for debugging
                return ("", "", 0);
            }

            double maxval = 0;
            string nameAns = "";
            string pathAns = "";
            foreach ((string nama, string berkasCitra) in sidikJariData)
            {
                double tmp;

                // You can switch between BM and KMP by commenting/uncommenting these sections
                BM solver = new BM();
                string text = ip.ProcessImageT(berkasCitra);
                tmp = solver.solveBM(pattern, text);

                // KMP solver = new KMP();
                // string text = ip.ProcessImageT(berkasCitra);
                // tmp = solver.solveKMP(pattern, text);

                if (tmp > maxval)
                {
                    maxval = tmp;
                    nameAns = nama;
                    pathAns = berkasCitra;
                }
            }
            Console.WriteLine($"Yang paling mirip adalah {nameAns} dengan Tingkat kemiripan {maxval * 100}%");
            Console.WriteLine($"path = {pathAns}");

            return (nameAns, pathAns, maxval * 100);
        }
    }
}
