using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 200)
            throw new ArgumentException("Judul tidak boleh null dan maksimal 200 karakter");

        this.title = title;
        this.id = new Random().Next(10000, 99999);
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
            throw new ArgumentException("Count harus antara 0 dan 25.000.000");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Terjadi overflow: " + e.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }
}