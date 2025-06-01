using System;

class Program
{
    static void Main(string[] args)
    {
        string nim = "2311104064";
        Console.WriteLine($"Project: tpmodul8_{nim}");

        CovidConfig config = new CovidConfig();

        RunCheck(config);

        Console.WriteLine("\nMelakukan perubahan satuan suhu...");
        config.UbahSatuan();

        Console.WriteLine("\nMenjalankan pemeriksaan lagi setelah UbahSatuan():");
        RunCheck(config);

        Console.WriteLine("\nProgram selesai.");

    }

    static void RunCheck(CovidConfig config)
    {
        Console.WriteLine($"\n--- Pemeriksaan dengan satuan: {config.satuan_suhu} ---");

        double suhuBadan;
        int hariDemam;

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        while (!double.TryParse(Console.ReadLine(), out suhuBadan))
        {
            Console.Write($"Input tidak valid. Masukkan angka untuk suhu: ");
        }

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        while (!int.TryParse(Console.ReadLine(), out hariDemam) || hariDemam < 0)
        {
            Console.Write("Input tidak valid. Masukkan angka non-negatif untuk jumlah hari: ");
        }

        bool kondisiSuhuOk = false;
        if (config.satuan_suhu.ToLower() == "celcius")
        {
            if (suhuBadan >= 36.5 && suhuBadan <= 37.5)
            {
                kondisiSuhuOk = true;
            }
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            if (suhuBadan >= 97.7 && suhuBadan <= 99.5)
            {
                kondisiSuhuOk = true;
            }
        }

        bool kondisiHariDemamOk = hariDemam < config.batas_hari_demam;

        if (kondisiSuhuOk && kondisiHariDemamOk)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}