using System;

class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – [Muhammad iKhsan Al Hakim]");
        video.PrintVideoDetails();

        try
        {
            video.IncreasePlayCount(5000000);
            video.PrintVideoDetails();

            video.IncreasePlayCount(1000000000); // Tes overflow
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}