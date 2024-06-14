using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPF
{
    internal class Runner
    {
        public List<(string, List<string>)> solve(string method, string inputPath)
        {
            DB db = new DB();
            db.readDB();

            ImageProc ip = new ImageProc();
            string pattern = ip.ProcessImageP(inputPath);
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

                    if (method == "BM")
                    {
                        BM solver = new BM();
                        string text = ip.ProcessImageT(berkasCitra);
                        tmp = solver.solveBM(pattern, text);
                    }

                    else if (method == "KMP")
                    {
                        // //KMP
                        KMP solver = new KMP();
                        string text = ip.ProcessImageT(berkasCitra);
                        tmp = solver.solveKMP(pattern, text);
                    }

                    if (tmp > maxval)
                    {
                        maxval = tmp;
                        nameAns = nama;
                        pathAns = berkasCitra;
                    }
                }
                Console.WriteLine($"yang paling mirip adalah {nameAns} dengan Tingkat kemiripan  {maxval * 100}%");
                Console.WriteLine($"path = {pathAns}");
            }
            if (maxval < 0.75)
            {
                return ans;
            }
            string path = pathAns;
            RegexFunction r = new RegexFunction();
            List<string> arrBiodata = r.FindBiodata(nameAns);
            ans.Add((path, arrBiodata));
            return ans;
        }
    }



}
