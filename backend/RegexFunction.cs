using System.Text.RegularExpressions;
using System.Reflection;
public class RegexFunction{
    public string ConvertAlayToNormal(string input)
    {
        input = input.ToLower();
        var patterns = new Dictionary<string, string>
        {
            { "13", "b" },
            { "4", "a" },
            { "3", "e" },
            { "1", "i" },
            { "0", "o" },
            { "5", "s" },
            { "7", "t" },
            { "6", "g" },
            { "2", "z" },
        };
        foreach (var pattern in patterns)
        {
            input = Regex.Replace(input, pattern.Key, pattern.Value);
        }
        return input;
    }


    public bool CheckRegex(string input, string check)
    {
        // input = input.ToLower();
        int inputLength = input.Length;

        string pattern = @"^(";

        for (int i = 0; i < inputLength; i++)
        {
            if(input[i].ToString() == " "){
                pattern += "[";
                pattern += "\\s";
                pattern += "]*";
            }
            else{
                pattern += "[";
                pattern += input[i].ToString();
                pattern += "]?";
            }
        }
        pattern += ")$"; 

        // Console.WriteLine(pattern);

        bool match = Regex.IsMatch(check, pattern);

        if (match)
        {
            Console.WriteLine("String sesuai dengan pola.");
            return true;
        }
        Console.WriteLine("String tidak sesuai dengan pola.");
        return false;
    }

    public List<String> FindBiodata(string nameAns){
            DB db = new DB();
            List<string> namaList = db.GetAllBiodataNama();
            List<string> normalNamaList = new List<string>();
            foreach(var nama in namaList){
                normalNamaList.Add(ConvertAlayToNormal(nama));
            }
            bool cek = false;
            List<string> biodata = new List<string>();
            for(int i=0;i<normalNamaList.Count;i++){
                Console.WriteLine($"normal nama: {normalNamaList[i]}");
                cek = CheckRegex(nameAns.ToLower(), normalNamaList[i]);
                if(cek){
                    biodata = db.GetBiodataByNama(namaList[i]);
                    if (biodata.Count > 0)
                    {
                        Console.WriteLine("Biodata ditemukan:");
                        Console.WriteLine($"NIK: {biodata[0]}");
                        Console.WriteLine($"Nama: {biodata[1]}");
                        Console.WriteLine($"Tempat Lahir: {biodata[2]}");
                        Console.WriteLine($"Tanggal Lahir: {biodata[3]}");
                        Console.WriteLine($"Jenis Kelamin: {biodata[4]}");
                        Console.WriteLine($"Golongan Darah: {biodata[5]}");
                        Console.WriteLine($"Alamat: {biodata[6]}");
                        Console.WriteLine($"Agama: {biodata[7]}");
                        Console.WriteLine($"Status Perkawinan: {biodata[8]}");
                        Console.WriteLine($"Pekerjaan: {biodata[9]}");
                        Console.WriteLine($"Kewarganegaraan: {biodata[10]}");
                    }
                    else
                    {
                        Console.WriteLine("Biodata tidak ditemukan.");
                    }
                    break;
                }
            }
            if(!cek){
                Console.WriteLine("Biodata tidak ditemukan.");
            }
        return biodata;
    }
}