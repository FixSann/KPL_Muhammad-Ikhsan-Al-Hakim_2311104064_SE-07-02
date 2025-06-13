using System;

namespace tpmodul3_2311104064
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Demo Table-Driven (KodePos) ---");
            KodePos tabelKodePos = new KodePos();

            // Contoh pemanggilan
            string kelurahan = "Batununggal";
            string kode = tabelKodePos.getKodePos(kelurahan);
            Console.WriteLine($"Kode Pos untuk kelurahan {kelurahan} adalah: {kode}");

            kelurahan = "Samoja";
            kode = tabelKodePos.getKodePos(kelurahan);
            Console.WriteLine($"Kode Pos untuk kelurahan {kelurahan} adalah: {kode}");

            // Bagian untuk State-Based akan ditambahkan nanti di bawah ini
            Console.WriteLine("\n--- Tekan tombol apa saja untuk melanjutkan ke demo State-Based ---");
            Console.ReadKey();

            Console.WriteLine("\n--- Demo State-Based (DoorMachine) ---");
            DoorMachine door = new DoorMachine();
            Console.WriteLine($"State awal pintu: {door.CurrentState}");

            // Simulasi perubahan state
            Console.WriteLine("\n> Membuka pintu...");
            door.ActivateTrigger(DoorMachine.Trigger.BukaPintu);
            Console.WriteLine($"State sekarang: {door.CurrentState}");

            Console.WriteLine("\n> Mencoba membuka pintu lagi...");
            door.ActivateTrigger(DoorMachine.Trigger.BukaPintu); // State tidak akan berubah
            Console.WriteLine($"State sekarang: {door.CurrentState}");

            Console.WriteLine("\n> Mengunci pintu...");
            door.ActivateTrigger(DoorMachine.Trigger.KunciPintu);
            Console.WriteLine($"State sekarang: {door.CurrentState}");

            Console.WriteLine("\n> Mencoba mengunci pintu lagi...");
            door.ActivateTrigger(DoorMachine.Trigger.KunciPintu); // State tidak akan berubah
            Console.WriteLine($"State sekarang: {door.CurrentState}");

            Console.WriteLine("\n--- Simulasi Selesai ---");
        }
    }
}
