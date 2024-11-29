using System.IO;

namespace YoutubeDownloaderApp;


public static class DeleteTemp
{
    public static void Delete(string videoFileName, string audioFileName)
    {

        // Delete the temporary video and audio files and temp folder
        if (File.Exists(videoFileName))
        {
            File.Delete(videoFileName);
        }
        if (File.Exists(audioFileName))
        {
            File.Delete(audioFileName);
        }
        if (Directory.Exists("./tmp"))
        {
            Directory.Delete("./tmp");
        }
    }
}