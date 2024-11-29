using YoutubeExplode.Videos.Streams;
using System.Threading.Tasks;
using System;

namespace YoutubeDownloaderApp;

public static class Downloader
{
    public static async Task DownloadStreamAsync(IStreamInfo stream, string fileName)
    {
        var youtube = new YoutubeExplode.YoutubeClient();
        await youtube.Videos.Streams.DownloadAsync(stream, fileName);
    }
}
