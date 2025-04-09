using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
            throw new ArgumentException("Judul tidak boleh kosong dan maksimal 100 karakter.");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); // ID acak 5 digit
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 10000000)
            throw new ArgumentOutOfRangeException("Maksimal penambahan play count adalah 10 juta.");

        checked
        {
            try
            {
                this.playCount += count;
            }
            catch (OverflowException)
            {
                Console.WriteLine("ERROR: Play count melebihi batas integer.");
            }
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}