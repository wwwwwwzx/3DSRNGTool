using System;
using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    public static class Updater
    {
        public static string CurrentVersion = "1.0.3";

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
                var LatestVersion = new System.Net.WebClient().DownloadString("https://raw.githubusercontent.com/wwwwwwzx/3DSRNGTool/master/version.txt");
                if (HasNewerVersion(LatestVersion))
                    if (FormUtil.Prompt(MessageBoxButtons.YesNo, $"New version (v{LatestVersion}) detected. Start to download?") == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(StringItem.GITHUB + "releases/download/" + LatestVersion + "/3DSRNGTool.exe");
                        Program.mainform.Close();
                    }
            }
            catch (Exception ex)
            {
                FormUtil.Error("Please download manually as an error occured: " + ex.Message);
            }
        }
    }
}