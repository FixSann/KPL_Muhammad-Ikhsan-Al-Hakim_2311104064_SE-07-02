using System;
using System.Windows.Forms;

namespace modul12_2311104064
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int CariNilaiPangkat(int a, int b)
        {
            if (b == 0)
            {
                return 1;
            }

            if (b < 0)
            {
                return -1;
            }

            if (b > 10 || a > 100)
            {
                return -2;
            }

            long hasilPangkat = 1; 
            try
            {
                checked
                {
                    for (int i = 0; i < b; i++)
                    {
                        hasilPangkat = hasilPangkat * a;
                        
                        if (hasilPangkat > int.MaxValue)
                        {
                            return -3;
                        }
                    }
                }
            }
            catch (OverflowException) 
            {
                return -3;
            }

            if (hasilPangkat > int.MaxValue || hasilPangkat < int.MinValue)
            {
                return -3;
            }

            return (int)hasilPangkat; 
        }

        private void buttonHitung_Click(object sender, EventArgs e)
        {
            try
            {
                int nilaiA = Convert.ToInt32(textBoxA.Text);

                int nilaiB = Convert.ToInt32(textBoxB.Text);

                int hasil = CariNilaiPangkat(nilaiA, nilaiB);

                labelOutput.Text = "Hasil: " + hasil.ToString();
            }
            catch (FormatException) 
            {
                labelOutput.Text = "Error: Input a dan b harus berupa angka yang valid!";
            }
            catch (OverflowException) 
            {
                labelOutput.Text = "Error: Angka input terlalu besar atau kecil!";
            }
            catch (Exception ex) 
            {
                labelOutput.Text = "Error tidak diketahui: " + ex.Message;
            }
        }

    } 
} 