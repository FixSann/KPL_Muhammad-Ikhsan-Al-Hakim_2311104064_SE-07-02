using System;
using System.Collections.Generic;

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        if (username == null || username.Length > 100)
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter");

        this.Username = username;
        this.id = new Random().Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentException("Video tidak boleh null");

        if (video.GetPlayCount() >= int.MaxValue)
            throw new ArgumentException("PlayCount video sudah maksimum");

        this.uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        int count = 0;
        foreach (var video in uploadedVideos)
        {
            if (count >= 8) break;
            Console.WriteLine($"Video {count + 1} judul: {video.GetTitle()}");
            count++;
        }
    }
}