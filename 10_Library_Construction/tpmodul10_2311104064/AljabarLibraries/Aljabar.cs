
using System;
using System.Collections.Generic; 

namespace AljabarLibraries 
{
    public static class Aljabar 
    {
        public static List<double> AkarPersamaanKuadrat(List<double> koefisien) 
        {
            if (koefisien == null || koefisien.Count != 3)
            {
                throw new ArgumentException("Input harus berupa daftar berisi 3 koefisien (a, b, c).");
            }

            double a = koefisien[0];
            double b = koefisien[1];
            double c = koefisien[2];

            List<double> akar = new List<double>(); 
            if (a == 0)
            {
                if (b != 0)
                {
                    akar.Add(-c / b);
                }
            }
            else 
            {
                double diskriminan = (b * b) - (4 * a * c); 

                if (diskriminan > 0)
                {
                   
                    double akar1 = (-b + Math.Sqrt(diskriminan)) / (2 * a);
                    double akar2 = (-b - Math.Sqrt(diskriminan)) / (2 * a);
                    akar.Add(akar1);
                    akar.Add(akar2);
                }
                else if (diskriminan == 0)
                {
                    double akarTunggal = -b / (2 * a);
                    akar.Add(akarTunggal);
                }
            }
            return akar;
        }
        public static List<double> HasilKuadrat(List<double> koefisien) 
        {
            if (koefisien == null || koefisien.Count != 2)
            {
                throw new ArgumentException("Input harus berupa daftar berisi 2 koefisien (A, B) dari Ax+B.");
            }

            double A = koefisien[0]; 
            double B = koefisien[1]; 

            double koef_x2 = A * A;         
            double koef_x = 2 * A * B;      
            double konstanta = B * B;       

            return new List<double> { koef_x2, koef_x, konstanta }; 
        }
    }
}