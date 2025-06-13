using System;

public class PosisiKarakterGame
{
    // Mendefinisikan semua kemungkinan state
    public enum State { Berdiri, Jongkok, Terbang, Tengkurap }
    // Mendefinisikan semua kemungkinan trigger/perintah
    public enum Trigger { TombolW, TombolS, TombolX }

    // Menyimpan state saat ini
    public State CurrentState { get; private set; }

    // Representasi transisi state: Key = State Awal, Value = List dari (Trigger, State Akhir)
    private Transition[,] transitions;

    public class Transition
    {
        public State StateAwal;
        public State StateAkhir;
        public Trigger Pemicu;

        public Transition(State awal, State akhir, Trigger pemicu)
        {
            StateAwal = awal;
            StateAkhir = akhir;
            Pemicu = pemicu;
        }
    }

    public PosisiKarakterGame()
    {
        // State awal adalah Berdiri
        CurrentState = State.Berdiri;

        // Inisialisasi transisi berdasarkan diagram
        Transition[] transisi = {
            new Transition(State.Berdiri, State.Jongkok, Trigger.TombolS),
            new Transition(State.Berdiri, State.Terbang, Trigger.TombolW),
            new Transition(State.Jongkok, State.Berdiri, Trigger.TombolW),
            new Transition(State.Jongkok, State.Tengkurap, Trigger.TombolS),
            new Transition(State.Tengkurap, State.Jongkok, Trigger.TombolW),
            new Transition(State.Terbang, State.Berdiri, Trigger.TombolS),
            new Transition(State.Terbang, State.Jongkok, Trigger.TombolX) // Transisi unik dengan TombolX
        };

        // Untuk implementasi sederhana, kita bisa menggunakan list saja
        // atau jika ingin lebih cepat, bisa menggunakan struktur data yang lebih kompleks.
        // Di sini kita akan buat sederhana dengan array of object.
        this.transitions = new Transition[transisi.Length, 1];
        for (int i = 0; i < transisi.Length; i++)
        {
            this.transitions[i, 0] = transisi[i];
        }
    }

    private State GetNextState(State stateAwal, Trigger pemicu)
    {
        State stateAkhir = stateAwal; // Default tidak berubah state jika transisi tidak ditemukan
        for (int i = 0; i < this.transitions.Length / this.transitions.Rank; i++)
        {
            if (this.transitions[i, 0] != null && this.transitions[i, 0].StateAwal == stateAwal && this.transitions[i, 0].Pemicu == pemicu)
            {
                stateAkhir = this.transitions[i, 0].StateAkhir;
                break;
            }
        }
        return stateAkhir;
    }

    public void ActivateTrigger(Trigger pemicu)
    {
        State stateBerikutnya = GetNextState(CurrentState, pemicu);

        // Kondisi tambahan berdasarkan NIM % 3 == 1
        if (stateBerikutnya == State.Berdiri)
        {
            Console.WriteLine("posisi standby");
        }
        if (stateBerikutnya == State.Tengkurap)
        {
            Console.WriteLine("posisi istirahat");
        }

        CurrentState = stateBerikutnya;
        Console.WriteLine($"State sekarang: {CurrentState}");
    }
}
