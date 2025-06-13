using System;
using System.Collections.Generic;

public class KodePos
{
    // Tabel data disimpan dalam Dictionary untuk pencarian cepat
    private Dictionary<string, string> kodePosTable = new Dictionary<string, string>()
    {
        {"Batununggal", "40266"},
        {"Kujangsari",  "40287"},
        {"Mengger",     "40267"},
        {"Wates",       "40256"},
        {"Cijaura",     "40287"},
        {"Jatisari",    "40286"},
        {"Margasari",   "40286"},
        {"Sekejati",    "40286"},
        {"Kebonwaru",   "40272"},
        {"Maleer",      "40274"},
        {"Samoja",      "40273"}
    };

    public string getKodePos(string kelurahan)
    {
        if (kodePosTable.ContainsKey(kelurahan))
        {
            return kodePosTable[kelurahan];
        }
        return "Kode Pos tidak ditemukan";
    }
}