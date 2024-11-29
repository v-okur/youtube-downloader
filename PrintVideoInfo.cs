using System.Diagnostics;
using System;

namespace YoutubeDownloaderApp;

public static class PrintVideoInfo
{

    public static void PrintInfo(YoutubeExplode.Videos.IVideo video)
    {

        //son thumbnail'i al
        var thumbnail = video.Thumbnails[video.Thumbnails.Count - 1].Url;

        //thumbnail'ı terminalde göster
        //curl https://img.youtube.com/vi/PxMdby3G3cc/hqdefault.jpg | catimg  - (Bu komutu çalıştır )

        Process.Start("bash", $"-c \"curl -s {thumbnail} | catimg -\"")?.WaitForExit();

        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Duration: {video.Duration}");
    }
}