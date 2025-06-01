Console.OutputEncoding = System.Text.Encoding.UTF8;

string configPath = "bank_transfer_config.json";
var config = BankTransferConfig.Load(configPath);

// 1. Input transfer amount
Console.WriteLine(config.lang == "id"
    ? "Masukkan jumlah uang yang akan di-transfer:"
    : "Please insert the amount of money to transfer:");

int amount = int.Parse(Console.ReadLine());

// 2. Calculate fee
int fee = amount <= config.transfer.threshold
    ? config.transfer.low_fee
    : config.transfer.high_fee;

int total = amount + fee;

// 3. Output fee
if (config.lang == "id")
{
    Console.WriteLine($"Biaya transfer = {fee}");
    Console.WriteLine($"Total biaya = {total}");
}
else
{
    Console.WriteLine($"Transfer fee = {fee}");
    Console.WriteLine($"Total amount = {total}");
}

// 4. Transfer methods
Console.WriteLine(config.lang == "id"
    ? "Pilih metode transfer:"
    : "Select transfer method:");

for (int i = 0; i < config.methods.Length; i++)
{
    Console.WriteLine($"{i + 1}. {config.methods[i]}");
}

Console.ReadLine(); // Method selection (not used further)

// 5. Confirmation input
string confirmText = config.lang == "id" ? config.confirmation.id : config.confirmation.en;

Console.WriteLine(config.lang == "id"
    ? $"Ketik \"{confirmText}\" untuk mengkonfirmasi transaksi:"
    : $"Please type \"{confirmText}\" to confirm the transaction:");

string userConfirm = Console.ReadLine();

// 6. Final response
if (userConfirm == confirmText)
{
    Console.WriteLine(config.lang == "id"
        ? "Proses transfer berhasil"
        : "The transfer is completed");
}
else
{
    Console.WriteLine(config.lang == "id"
        ? "Transfer dibatalkan"
        : "Transfer is cancelled");
}
