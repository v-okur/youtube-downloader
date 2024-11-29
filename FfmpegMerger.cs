using System.Diagnostics;
using System;


namespace YoutubeDownloaderApp;

public static class FfmpegMerger
{
    public static void Merge(string videoFilePath, string audioFilePath, string outputFilePath)
    {
        var ffmpeg = new ProcessStartInfo("ffmpeg", $"-i \"{videoFilePath}\" -i \"{audioFilePath}\" -c copy \"{outputFilePath}\"")
        {
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process.Start(ffmpeg)?.WaitForExit();
        DeleteTemp.Delete(videoFilePath, audioFilePath);
        Console.WriteLine($"Downloaded: {outputFilePath}");

    }
}
