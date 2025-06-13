using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CovidConfig
{
    [JsonPropertyName("satuan_suhu")]
    public string SatuanSuhu { get; set; }

    [JsonPropertyName("batas_hari_deman")]
    public int BatasHariDemam { get; set; }

    [JsonPropertyName("pesan_ditolak")]
    public string PesanDitolak { get; set; }

    [JsonPropertyName("pesan_diterima")]
    public string PesanDiterima { get; set; }

    private const string FilePath = "covid_config.json";

    public static CovidConfig LoadConfig()
    {
        if (File.Exists(FilePath))
        {
            string jsonString = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<CovidConfig>(jsonString);
        }

        var defaultConfig = new CovidConfig
        {
            SatuanSuhu = "celcius",
            BatasHariDemam = 14,
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
        };

        defaultConfig.SaveConfig();
        return defaultConfig;
    }

    public void SaveConfig()
    {
        var jsonString = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, jsonString);
    }

    public void ToggleSatuanSuhu()
    {
        SatuanSuhu = SatuanSuhu?.ToLower() == "celcius" ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}