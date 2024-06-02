using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    public static class Updater
    {
        public static string CurrentVersion = "1.0.6";

        public static void CheckUpdate()
        {
            if (TestInternet())
                TryDownload();
        }
        private static bool TestInternet()
        {
            try
            {
                new System.Net.NetworkInformation.Ping().Send("github.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static bool HasNewerVersion(string Latest) => new Version(Latest).CompareTo(new Version(CurrentVersion)) > 0;
        private static void TryDownload()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://raw.githubusercontent.com/wwwwwwzx/3DSRNGTool/master/version.txt").Result;
                response.EnsureSuccessStatusCode();
                string latestVersion = response.Content.ReadAsStringAsync().Result;

                if (!HasNewerVersion(latestVersion))
                    return;
                if (FormUtil.Prompt(MessageBoxButtons.YesNo, $"New version (v{latestVersion}) detected. Start to download?") != DialogResult.Yes)
                    return;

                System.Diagnostics.Process.Start($"{StringItem.GITHUB}releases/download/{latestVersion}/3DSRNGTool.exe");
                Program.mainform.Close();
            }
            catch (Exception ex)
            {
                FormUtil.Error("Please download manually as an error occured: " + ex.Message);
            }
        }
    }
}