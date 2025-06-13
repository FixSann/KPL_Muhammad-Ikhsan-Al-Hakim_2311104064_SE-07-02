
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text; 

namespace MatematikaLibraries 
{
    public static class OperasiMatematika
    {
        public static int FPB(int input1, int input2)
        {
            input1 = Math.Abs(input1); 
            input2 = Math.Abs(input2); 

            while (input2 != 0)
            {
                int temp = input2;
                input2 = input1 % input2;
                input1 = temp;
            }
            return input1;
        }

        public static int KPK(int input1, int input2)
        {
            if (input1 == 0 || input2 == 0)
            {
                return 0; 
            }
            input1 = Math.Abs(input1);
            input2 = Math.Abs(input2);
            return (input1 * input2) / FPB(input1, input2);
        }

        public static string Turunan(int[] persamaan)
        {
            if (persamaan == null || persamaan.Length == 0)
            {
                return "0"; 
            }

            StringBuilder sb = new StringBuilder();
            int n = persamaan.Length; 

            for (int i = 0; i < n - 1; i++) 
            {
                int pangkatAwal = n - 1 - i;
                if (pangkatAwal == 0) continue; 

                int koefisienAwal = persamaan[i];
                int koefisienTurunan = koefisienAwal * pangkatAwal;
                int pangkatTurunan = pangkatAwal - 1;

                if (koefisienTurunan == 0) continue; 

                if (sb.Length > 0 && koefisienTurunan > 0)
                {
                    sb.Append("+");
                }

                if (koefisienTurunan == -1 && pangkatTurunan != 0)
                {
                    sb.Append("-"); 
                }
                else if (koefisienTurunan != 1 || pangkatTurunan == 0)
                {

                    if (koefisienTurunan == -1 && pangkatTurunan == 0)
                    {
                        sb.Append(koefisienTurunan);
                    }
                    else if (koefisienTurunan != 1 || pangkatTurunan == 0)
                    {
                        if (koefisienTurunan == 1 && pangkatTurunan == 0)
                        {
                            sb.Append(koefisienTurunan);
                        }
                        else if (koefisienTurunan != 1)
                        {
                            sb.Append(koefisienTurunan);
                        }
                    }

                }


                if (pangkatTurunan > 0)
                {
                    sb.Append("x");
                    if (pangkatTurunan > 1)
                    {
                        sb.Append("^").Append(pangkatTurunan);
                    }
                }
            }

            if (sb.Length == 0) return "0"; 

            if (sb.Length > 0 && sb[0] == '+')
            {
                return sb.ToString(1, sb.Length - 1);
            }

            return sb.ToString();
        }


        public static string Integral(int[] persamaan)
        {
            if (persamaan == null || persamaan.Length == 0)
            {
                return "C"; 
            }

            StringBuilder sb = new StringBuilder();
            int n = persamaan.Length;

            for (int i = 0; i < n; i++)
            {
                int pangkatAwal = n - 1 - i;
                int koefisienAwal = persamaan[i];

                if (koefisienAwal == 0 && pangkatAwal != 0) continue; 


                int pangkatIntegral = pangkatAwal + 1;
               
                int koefisienIntegral = koefisienAwal / pangkatIntegral;
              
                if (koefisienAwal == 0 && pangkatAwal == 0 && i == n - 1 && n == 1 && persamaan[0] == 0)
                {
                    
                }
                else if (koefisienIntegral == 0 && koefisienAwal != 0)
                {
                   
                }


                if (koefisienIntegral == 0 && koefisienAwal == 0 && i == n - 1)
                {
                    
                }
                else if (koefisienIntegral != 0 || (koefisienIntegral == 0 && koefisienAwal == 0))
                { 
                    if (sb.Length > 0 && koefisienIntegral > 0)
                    {
                        sb.Append("+");
                    }
                    else if (sb.Length > 0 && koefisienIntegral == 0 && koefisienAwal == 0 && pangkatAwal == 0 && persamaan[i] == 0)
                    {
                        
                    }

                    if (koefisienIntegral == -1 && pangkatIntegral != 0) 
                    {
                        sb.Append("-");
                    }

                    else if (koefisienIntegral != 1 && koefisienIntegral != 0)
                    {
                        sb.Append(koefisienIntegral);
                    }
                    else if (koefisienIntegral == 1 && pangkatIntegral == 0)
                    { 

                    }
                    else if (koefisienIntegral == 0 && koefisienAwal == 0 && pangkatAwal == 0)
                    {

                    }
                    else if (koefisienIntegral == 1 && pangkatIntegral != 0)
                    {
                        
                    }
                    else if (koefisienIntegral != 0)
                    { 
                        sb.Append(koefisienIntegral);
                    }

                    if (pangkatIntegral > 0) 
                    {
                        sb.Append("x");
                        if (pangkatIntegral > 1)
                        {
                            sb.Append("^").Append(pangkatIntegral);
                        }
                    }
                }
            }

            if (sb.Length == 0) 
            {
                return "C";
            }
            else
            {
                string resultString = sb.ToString();
                if (resultString.StartsWith("+"))
                {
                    resultString = resultString.Substring(1);
                }

                if (string.IsNullOrWhiteSpace(resultString) && persamaan.All(c => c == 0))
                {
                    return "C";
                }
                else if (string.IsNullOrWhiteSpace(resultString) && !persamaan.All(c => c == 0))
                {
                    return "C"; 
                }

                bool onlyZeros = true;
                foreach (int kfs in persamaan)
                {
                    if (kfs != 0)
                    {
                        onlyZeros = false;
                        break;
                    }
                }
                if (onlyZeros && resultString == "C")
                { 
                    return "C";
                }

                if (!string.IsNullOrWhiteSpace(resultString))
                {
                    sb.Append("+C");
                }
                else
                { 
                    return "C";
                }
            }
            
            string finalResult = sb.ToString();
            if (finalResult.StartsWith("+") && !finalResult.Contains("C+")) 
            {
                if (finalResult.Length > 1 && finalResult[1] == 'C')
                { 
                  
                }
                else
                {
                    finalResult = finalResult.Substring(1);
                }
            }
            
            if (finalResult == "+C") return "C";


            return finalResult;
        }
    }
}