using System;

class Program
{
    static void Main()
    {
        // Memanggil method generic dengan tiga angka
        Penjumlahan penjumlahan = new Penjumlahan();
        Console.WriteLine("Hasil Penjumlahan: " + penjumlahan.JumlahTigaAngka(23, 11, 10));

        // Menggunakan SimpleDataBase
        SimpleDataBase<int> database = new SimpleDataBase<int>();
        database.AddNewData(23);
        database.AddNewData(11);
        database.AddNewData(10);
        database.PrintAllData();
    }
}