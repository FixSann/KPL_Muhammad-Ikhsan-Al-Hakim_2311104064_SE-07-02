using System;

public class DoorMachine
{
    // Mendefinisikan semua kemungkinan state
    public enum State { Terkunci, Terbuka }
    // Mendefinisikan semua kemungkinan trigger/perintah
    public enum Trigger { KunciPintu, BukaPintu }

    // Menyimpan state saat ini
    public State CurrentState { get; private set; }

    public DoorMachine()
    {
        // State awal adalah Terkunci
        CurrentState = State.Terkunci;
        Console.WriteLine("Pintu terkunci"); // Output saat state awal
    }

    public void ActivateTrigger(Trigger trigger)
    {
        // Logika transisi state
        switch (CurrentState)
        {
            case State.Terkunci:
                if (trigger == Trigger.BukaPintu)
                {
                    CurrentState = State.Terbuka;
                    Console.WriteLine("Pintu tidak terkunci"); // Output saat masuk ke state Terbuka
                }
                // Jika trigger KunciPintu saat sudah Terkunci, tidak ada perubahan state
                break;
            case State.Terbuka:
                if (trigger == Trigger.KunciPintu)
                {
                    CurrentState = State.Terkunci;
                    Console.WriteLine("Pintu terkunci"); // Output saat masuk ke state Terkunci
                }
                // Jika trigger BukaPintu saat sudah Terbuka, tidak ada perubahan state
                break;
        }
    }
}
