using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


namespace YoutubeDownloaderApp;

public static class YoutubeHandler
{
    private static readonly YoutubeClient Youtube = new();

    public static async Task<Video> GetVideoAsync(string url)
    {
        return await Youtube.Videos.GetAsync(url);
    }

    public static async Task<StreamManifest> GetStreamManifestAsync(string videoId)
    {
        return await Youtube.Videos.Streams.GetManifestAsync(videoId);
    }

    // Bu method argumant olarak ya video Stream ya da Audio Stream  alabilir.
    public static void DisplayStreamOptions(List<VideoOnlyStreamInfo> streams)
    {

        int index = 0;

        foreach (var stream in streams)
        {
            Console.WriteLine($"{index++} - {stream.VideoQuality} - {stream.Container} - Size: {stream.Size}");
        }
    }

    public static void DisplayStreamOptions(List<AudioOnlyStreamInfo> streams)
    {

        int index = 0;

        foreach (var stream in streams)
        {
            Console.WriteLine($"{index++} - {stream.Container} - Size: {stream.Size}");
        }
    }


    public static int GetStreamSelection(int maxIndex)
    {
        int selection;
        while (true)
        {
            Console.Write("Enter your selection: ");
            if (int.TryParse(Console.ReadLine(), out selection) && selection >= 0 && selection < maxIndex)
            {
                return selection;
            }
            Console.WriteLine("Invalid selection. Try again.");
        }
    }
}
