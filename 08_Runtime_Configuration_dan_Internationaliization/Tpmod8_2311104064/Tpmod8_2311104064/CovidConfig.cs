using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    // Default values (sesuai dokumen)
    private const string DefaultSatuanSuhu = "celcius";
    private const int DefaultBatasHariDemam = 14;
    private const string DefaultPesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    private const string DefaultPesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    private const string ConfigFileName = "covid_config.json";
    private string _fullPathToConfig;

    // Properti untuk konfigurasi
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public CovidConfig()
    {
        _fullPathToConfig = Path.GetFullPath(ConfigFileName);

        SetDefaults();
        LoadConfig();
    }

    private void SetDefaults()
    {
        satuan_suhu = DefaultSatuanSuhu;
        batas_hari_demam = DefaultBatasHariDemam;
        pesan_ditolak = DefaultPesanDitolak;
        pesan_diterima = DefaultPesanDiterima;

    }

    private void LoadConfig()
    {
        try
        {
            if (File.Exists(_fullPathToConfig))
            {
                string jsonString = File.ReadAllText(_fullPathToConfig);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    Console.WriteLine($"[WARNING] File konfigurasi '{_fullPathToConfig}' ada tapi kosong. Menggunakan dan menyimpan nilai default.");
                    SaveChanges();
                    return;
                }

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                CovidConfig? loadedConfig = JsonSerializer.Deserialize<CovidConfig>(jsonString, options);

                if (loadedConfig != null)
                {
                    satuan_suhu = !string.IsNullOrEmpty(loadedConfig.satuan_suhu) ? loadedConfig.satuan_suhu : DefaultSatuanSuhu;
                    batas_hari_demam = loadedConfig.batas_hari_demam > 0 ? loadedConfig.batas_hari_demam : DefaultBatasHariDemam;
                    pesan_ditolak = !string.IsNullOrEmpty(loadedConfig.pesan_ditolak) ? loadedConfig.pesan_ditolak : DefaultPesanDitolak;
                    pesan_diterima = !string.IsNullOrEmpty(loadedConfig.pesan_diterima) ? loadedConfig.pesan_diterima : DefaultPesanDiterima;
                    Console.WriteLine($"[INFO] Konfigurasi berhasil dimuat dari file: {_fullPathToConfig}");
                }
                else
                {
                    Console.WriteLine($"[WARNING] Gagal mengurai isi file konfigurasi '{_fullPathToConfig}' (hasil null). Menggunakan dan menyimpan nilai default.");
                    SaveChanges();
                }
            }
            else
            {
                Console.WriteLine($"[INFO] File konfigurasi '{_fullPathToConfig}' tidak ditemukan. Membuat file dengan nilai default.");
                SaveChanges();
            }
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"[ERROR] Format JSON di '{_fullPathToConfig}' tidak valid: {jsonEx.Message}. Menggunakan nilai default.");
            SetDefaults();
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"[ERROR] Gagal membaca file konfigurasi '{_fullPathToConfig}': {ioEx.Message}. Menggunakan nilai default.");
            SetDefaults();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Terjadi kesalahan tak terduga saat memuat konfigurasi: {ex.Message}. Menggunakan nilai default.");
            if (!(ex is StackOverflowException))
            {
                SetDefaults();
            }
        }
    }

    private void SaveChanges()
    {
        try
        {
            var configDataToSave = new
            {
                satuan_suhu = this.satuan_suhu,
                batas_hari_demam = this.batas_hari_demam,
                pesan_ditolak = this.pesan_ditolak,
                pesan_diterima = this.pesan_diterima
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(configDataToSave, options);
            File.WriteAllText(_fullPathToConfig, jsonString);
            Console.WriteLine($"[INFO] Konfigurasi berhasil disimpan ke: {_fullPathToConfig}");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"[ERROR] Gagal menyimpan file konfigurasi (IOException): {ioEx.Message}. Periksa izin folder atau masalah disk.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Gagal menyimpan konfigurasi karena kesalahan tak terduga: {ex.Message}");
        }
    }

    public void UbahSatuan()
    {
        if (satuan_suhu.ToLower() == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else
        {
            satuan_suhu = "celcius";
        }
        Console.WriteLine($"[INFO] Satuan suhu telah diubah menjadi: {satuan_suhu}");
        SaveChanges();
    }
}