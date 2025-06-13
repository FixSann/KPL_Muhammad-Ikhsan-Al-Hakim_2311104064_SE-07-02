
using System;
using System.Collections.Generic;
using AljabarLibraries; 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mendemokan Library Aljabar");
        Console.WriteLine("--------------------------");

        List<double> koefisienKuadrat = new List<double> { 1, -3, -10 };
        Console.WriteLine($"\nMencari akar dari persamaan: {koefisienKuadrat[0]}x^2 + ({koefisienKuadrat[1]})x + ({koefisienKuadrat[2]}) = 0");
        try
        {
            List<double> akar = Aljabar.AkarPersamaanKuadrat(koefisienKuadrat);
            Console.Write("Akar-akarnya: ");
            foreach (var a in akar)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        List<double> koefisienLinear = new List<double> { 2, -3 };
        Console.WriteLine($"\nMencari hasil kuadrat dari: ({koefisienLinear[0]})x + ({koefisienLinear[1]})");
        try
        {
            List<double> hasil = Aljabar.HasilKuadrat(koefisienLinear); 
            Console.WriteLine($"Hasil kuadratnya (koefisien a,b,c untuk ax^2+bx+c): {hasil[0]}, {hasil[1]}, {hasil[2]}");
            Console.WriteLine($"Dalam bentuk persamaan: {hasil[0]}x^2 + ({hasil[1]})x + ({hasil[2]})");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\nTekan tombol apa saja untuk keluar...");
        Console.ReadKey();
    }
}