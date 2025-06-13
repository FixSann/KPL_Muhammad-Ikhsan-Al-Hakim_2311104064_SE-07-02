using modul13;

public class Program
{
    public static void Main(string[] args)
    {
        var data1 = PusatDataSingleton.GetDataSingleton();
        var data2 = PusatDataSingleton.GetDataSingleton();

        data1.AddSebuahData("rizal");
        data1.AddSebuahData("Denis");
        data1.AddSebuahData("Joni");

        Console.WriteLine("Data di data2:");
        data2.PrintSemuaData();

        data2.HapusSebuahData(2);

        Console.WriteLine("\nSetelah penghapusan, data di data1:");
        data1.PrintSemuaData();

        Console.WriteLine($"\nJumlah data di data1: {data1.GetSemuaData().Count}");
        Console.WriteLine($"Jumlah data di data2: {data2.GetSemuaData().Count}");
    }
}
