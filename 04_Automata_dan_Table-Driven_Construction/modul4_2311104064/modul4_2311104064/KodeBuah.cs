using System;
using System.Collections.Generic;

public class KodeBuah
{
    // Tabel data disimpan dalam Dictionary
    private Dictionary<string, string> kodeMapping = new Dictionary<string, string>()
    {
        {"Apel",       "A00"},
        {"Aprikot",    "B00"},
        {"Alpukat",    "C00"},
        {"Pisang",     "D00"},
        {"Paprika",    "E00"},
        {"Blackberry", "F00"},
        {"Ceri",       "H00"},
        {"Kelapa",     "I00"}, // 'I' bukan '1'
        {"Jagung",     "J00"},
        {"Kurma",      "K00"},
        {"Durian",     "L00"},
        {"Anggur",     "M00"},
        {"Melon",      "N00"},
        {"Semangka",   "O00"}  // 'O' bukan '0'
    };

    public string getKodeBuah(string namaBuah)
    {
        if (kodeMapping.ContainsKey(namaBuah))
        {
            return kodeMapping[namaBuah];
        }
        return "Kode tidak ditemukan";
    }
}
