class Program
{
   static void Main(string[] args){
        ImageProc ip = new ImageProc();
        string pattern = ip.ProcessImageP("./sidiks/1.BMP");
        Console.WriteLine($"pattern: {pattern}");
       
        string text = ip.ProcessImageT("./sidiks/9.BMP");
        
        BM solver = new BM();
        solver.solve(pattern, text);
    }
}
