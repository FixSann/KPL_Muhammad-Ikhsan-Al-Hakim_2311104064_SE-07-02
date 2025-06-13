using System;

namespace modul4_2311104064 // Pastikan namespace ini sesuai dengan project Anda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Demo Table-Driven (KodeBuah) ---");
            KodeBuah tabelBuah = new KodeBuah();

            // Contoh pemanggilan
            string namaBuah = "Apel";
            string kode = tabelBuah.getKodeBuah(namaBuah);
            Console.WriteLine($"Kode untuk buah {namaBuah} adalah: {kode}");

            namaBuah = "Melon";
            kode = tabelBuah.getKodeBuah(namaBuah);
            Console.WriteLine($"Kode untuk buah {namaBuah} adalah: {kode}");

            namaBuah = "Anggur";
            kode = tabelBuah.getKodeBuah(namaBuah);
            Console.WriteLine($"Kode untuk buah {namaBuah} adalah: {kode}");

            // Bagian untuk State-Based akan ditambahkan nanti di bawah ini
            Console.WriteLine("\n--- Tekan tombol apa saja untuk melanjutkan ke demo State-Based ---");
            Console.ReadKey();

            Console.WriteLine("\n--- Demo State-Based (PosisiKarakterGame) ---");
            PosisiKarakterGame gameChar = new PosisiKarakterGame();
            Console.WriteLine($"State awal: {gameChar.CurrentState}");

            // Simulasi untuk menghasilkan output NIM % 3 == 1
            Console.WriteLine("\nMenekan Tombol S (Berdiri -> Jongkok):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);

            Console.WriteLine("\nMenekan Tombol W (Jongkok -> Berdiri):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW); // Akan ada output "posisi standby"

            Console.WriteLine("\nMenekan Tombol S (Berdiri -> Jongkok):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);

            Console.WriteLine("\nMenekan Tombol S (Jongkok -> Tengkurap):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS); // Akan ada output "posisi istirahat"

            Console.WriteLine("\nMenekan Tombol W (Tengkurap -> Jongkok):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);

            Console.WriteLine("\nMenekan Tombol W (Jongkok -> Berdiri):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW); // Akan ada output "posisi standby" lagi

            Console.WriteLine("\nMenekan Tombol W (Berdiri -> Terbang):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);

            Console.WriteLine("\nMenekan Tombol S (Terbang -> Berdiri):");
            gameChar.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS); // Akan ada output "posisi standby" lagi

            Console.WriteLine("\n--- Simulasi Selesai ---");

        }
    }
}
