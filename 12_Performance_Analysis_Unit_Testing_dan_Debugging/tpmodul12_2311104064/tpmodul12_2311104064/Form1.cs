using System;
using System.Windows.Forms;

namespace tpmodul12_2311104064
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        public string CariTandaBilangan(int angkaInput)
        {
            if (angkaInput < 0)
            {
                return "Negatif";
            }
            else if (angkaInput > 0)
            {
                return "Positif";
            }
            else
            {
                return "Nol";
            }
        }

        private void cekButton_Click(object sender, EventArgs e)
        {
            try
            {
                string teksDariInput = inputTextBox.Text;

                int angkaUntukDicek = Convert.ToInt32(teksDariInput);

                string hasilPengecekan = CariTandaBilangan(angkaUntukDicek);

                outputLabel.Text = hasilPengecekan;
            }
            catch (FormatException) 
            {
                outputLabel.Text = "Error: Input harus berupa angka yang valid!";
            }
            catch (OverflowException) 
            {
                outputLabel.Text = "Error: Angka terlalu besar atau kecil!";
            }
            catch (Exception ex) 
            {
                outputLabel.Text = "Error tidak diketahui: " + ex.Message;
            }
        }

    }
}