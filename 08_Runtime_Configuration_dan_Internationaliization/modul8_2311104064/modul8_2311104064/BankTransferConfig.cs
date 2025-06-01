using System.Text.Json;

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public string[] methods { get; set; }
    public Confirmation confirmation { get; set; }

    public static BankTransferConfig Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new BankTransferConfig
            {
                lang = "en",
                transfer = new Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = new[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                confirmation = new Confirmation
                {
                    en = "yes",
                    id = "ya"
                }
            };
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<BankTransferConfig>(json);
    }
}

public class Transfer
{
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}
