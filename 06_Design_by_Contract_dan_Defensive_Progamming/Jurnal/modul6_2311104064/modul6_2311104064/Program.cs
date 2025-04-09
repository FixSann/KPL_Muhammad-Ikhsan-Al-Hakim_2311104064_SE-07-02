using System;

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user = new SayaTubeUser("Ikhsan");

        for (int i = 1; i <= 10; i++)
        {
            string judul = $"Review Film {i} oleh Ikhsan";
            SayaTubeVideo video = new SayaTubeVideo(judul);
            video.IncreasePlayCount(1000000 * i); // Uji increase
            user.AddVideo(video);
        }

        Console.WriteLine("=================================");
        user.PrintAllVideoPlaycount();

        Console.WriteLine("=================================");
        Console.WriteLine("Total Play Count: " + user.GetTotalVideoPlayCount());

        // Uji exception (overflow)
        try
        {
            SayaTubeVideo testOverflow = new SayaTubeVideo("Overflow Test");
            for (int i = 0; i < 10; i++)
            {
                testOverflow.IncreasePlayCount(250000000); // Melebihi batas
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception tertangkap: " + ex.Message);
        }
    }
}