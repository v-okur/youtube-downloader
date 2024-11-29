

namespace YoutubeDownloaderApp;


class Program
{
    static async Task Main(string[] args)

    {
        Console.Write("Enter the URL or ID of the video you want to download: ");
        string url = Console.ReadLine() ?? string.Empty;
        while (string.IsNullOrEmpty(url))
        {
            Console.Write("URL is empty. Please enter a URL or ID: ");
            url = Console.ReadLine() ?? string.Empty;
        }

        var video = await YoutubeHandler.GetVideoAsync(url);

        PrintVideoInfo.PrintInfo(video);

        var streamManifest = await YoutubeHandler.GetStreamManifestAsync(video.Id);

        var videoStreams = streamManifest.GetVideoOnlyStreams().ToList();
        var audioStreams = streamManifest.GetAudioOnlyStreams().ToList();

        Console.WriteLine("\nAvailable Video Streams:");
        YoutubeHandler.DisplayStreamOptions(videoStreams);

        int videoSelection = YoutubeHandler.GetStreamSelection(videoStreams.Count);
        var selectedVideoStream = videoStreams[videoSelection];

        Console.WriteLine("\nAvailable Audio Streams:");
        YoutubeHandler.DisplayStreamOptions(audioStreams);

        int audioSelection = YoutubeHandler.GetStreamSelection(audioStreams.Count);
        var selectedAudioStream = audioStreams[audioSelection];

        Directory.CreateDirectory("./tmp");
        string videoFileName = $"tmp/{video.Title}-vidonly.{selectedVideoStream.Container.Name}";
        string audioFileName = $"tmp/{video.Title}-audonly.{selectedAudioStream.Container.Name}";
        string outputFileName = $"{video.Title}.mp4";

        await Downloader.DownloadStreamAsync(selectedVideoStream, videoFileName);
        await Downloader.DownloadStreamAsync(selectedAudioStream, audioFileName);

        FfmpegMerger.Merge(videoFileName, audioFileName, outputFileName);
    }
}
