using System;

class Program
{
    static void Main()
    {
        var config = CovidConfig.LoadConfig();

        Console.WriteLine("==== Aplikasi Pengecekan Kesehatan ====");
        Console.WriteLine($"Satuan suhu saat ini: {config.SatuanSuhu}");

        Console.Write($"Berapa suhu badan Anda saat ini? Dalam satuan {config.SatuanSuhu}\n>> ");
        if (!double.TryParse(Console.ReadLine(), out double suhu))
        {
            Console.WriteLine("Input suhu tidak valid.");
            return;
        }

        Console.WriteLine();

        Console.Write("Berapa hari yang lalu (perkiraan) Anda terakhir memiliki gejala demam?\n>> ");
        if (!int.TryParse(Console.ReadLine(), out int hari))
        {
            Console.WriteLine("Input hari tidak valid.");
            return;
        }

        Console.WriteLine();

        bool suhuNormal = false;
        if (config.SatuanSuhu.ToLower() == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.SatuanSuhu.ToLower() == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hari < config.BatasHariDemam;

        Console.WriteLine("Hasil:");
        if (suhuNormal && hariValid)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
    }
}