
using System;
using System.Collections.Generic; 
using MatematikaLibraries;     

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Mendemokan Library Matematika ===");
        Console.WriteLine("-------------------------------------");

        int bil1_fpb = 60;
        int bil2_fpb = 45;
        Console.WriteLine($"\nFPB dari {bil1_fpb} dan {bil2_fpb}:");
        try
        {
            int hasilFPB = OperasiMatematika.FPB(bil1_fpb, bil2_fpb);
            Console.WriteLine($"Hasil: {hasilFPB}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat menghitung FPB: {ex.Message}");
        }

        int bil1_kpk = 12;
        int bil2_kpk = 8;
        Console.WriteLine($"\nKPK dari {bil1_kpk} dan {bil2_kpk}:");
        try
        {
            int hasilKPK = OperasiMatematika.KPK(bil1_kpk, bil2_kpk);
            Console.WriteLine($"Hasil: {hasilKPK}"); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat menghitung KPK: {ex.Message}");
        }

        int[] persamaanTurunan = { 1, 4, -12, 9 };
        Console.WriteLine($"\nTurunan dari persamaan dengan koefisien {{{string.Join(", ", persamaanTurunan)}}} (x^3 + 4x^2 - 12x + 9):");
        try
        {
            string hasilTurunan = OperasiMatematika.Turunan(persamaanTurunan);
            Console.WriteLine($"Hasil: \"{hasilTurunan}\""); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat menghitung Turunan: {ex.Message}");
        }

        int[] persamaanIntegral = { 4, 6, -12, 9 };
        Console.WriteLine($"\nIntegral dari persamaan dengan koefisien {{{string.Join(", ", persamaanIntegral)}}} (4x^3 + 6x^2 - 12x + 9):");
        try
        {
            string hasilIntegral = OperasiMatematika.Integral(persamaanIntegral);
            Console.WriteLine($"Hasil: \"{hasilIntegral}\""); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saat menghitung Integral: {ex.Message}");
        }

        Console.WriteLine("\n-------------------------------------");
        Console.WriteLine("Pengujian selesai. Tekan tombol apa saja untuk keluar...");
        Console.ReadKey();
    }
}